using RestSharp;
using System.Collections;
using System.Diagnostics;
using System.Reflection;
using Yulgang_Lost_Connection.Properties;

namespace Yulgang_Lost_Connection
{
    public partial class FormMain : Form
    {
        private bool _botWorking = false;
        private LineNotify _lineNotify;
        private ArrayList _lineAlreadySentProcess;
        private int _botListIndex = -1;
        private bool _botForceStop = false;

        public FormMain()
        {
            InitializeComponent();
        }

        private async void FormMain_LoadAsync(object sender, EventArgs e)
        {
            Text = Text + @" " + Assembly.GetExecutingAssembly().GetName().Version.ToString();

            checkedListBoxProcess.DisplayMember = "Text";
            checkedListBoxProcess.ValueMember = "Value";

            //check update
            bool update = await CheckUpdateFromGithub();
            if(update)
            {
                Log(@"��Ǩ������������� ����ö������Ŵ���� https://github.com/meawmuay/yulgang-lost-connection");
            }
            else
            {
                Log("�س��ҹ����������������ش����");
            }
        }

        private async void buttonLoadProcess_Click(object sender, EventArgs e)
        {
            Log(@"���ѧ��Ŵ�����Ũ��� �Ҩ�����Ҷ֧ 1 �ҷ������ҡ����...");

            buttonLoadProcess.Enabled = false;

            List<ProcessInstanceItem> listInstanceNames;
            try
            {
                listInstanceNames = await getInstanceNames();
            }
            catch (Exception ex)
            {
                Log(@"�Դ��ͼԴ��Ҵ�ҧ��С�÷������Ŵ��¡�úҧ��¡���������� ���ҡ�������ӧҹ ��顴��Ŵ�������������ա����!");

                return;
            }

            Process[] processList = Process.GetProcesses();

            checkedListBoxProcess.Items.Clear();
            bool found = false;
            foreach (Process process in processList)
            {
                //Debug.WriteLine("Process: {0} ID: {1}", process.ProcessName, process.Id);

                if (process.ProcessName == "YGOnline")
                {
                    Debug.WriteLine("Process:" + process.Id);

                    //���� instance name �� process id
                    string instanceName = "";
                    foreach (ProcessInstanceItem item in listInstanceNames)
                    {
                        if (item.Id == process.Id)
                        {
                            instanceName = item.Name;
                        }
                    }

                    if (instanceName == "")
                    {
                        Debug.WriteLine("Instance Name:" + instanceName);

                        Log(@"�Դ��ͼԴ��Ҵ�ҧ��С�÷������Ŵ��¡�úҧ��¡���������� ���ҡ�������ӧҹ ��顴��Ŵ�������������ա����!");
                        return;
                    }
                    else
                    {
                        Debug.WriteLine("Instance Name:" + instanceName);
                    }

                    checkedListBoxProcess.Items.Insert(checkedListBoxProcess.Items.Count, new ListBoxProcessItem(
                        process.MainWindowTitle + " " + instanceName.Replace("YGOnline",""),
                        process,
                        instanceName
                        ));

                    //Set checked after insert
                    int index = checkedListBoxProcess.Items.Count - 1;
                    checkedListBoxProcess.SetItemChecked(index, true);

                    found = true;
                }
            }

            if (!found)
            {
                Log(@"��辺���� ��س��Դ�� Yulgang ��͹!");
            }
            else
            {
                Log(@"��Ŵ�����Ũ����������º��������");
            }

            buttonLoadProcess.Enabled = true;
            buttonStart.Enabled = true;
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            timerBot.Enabled = true;
            buttonStop.Enabled = true;
            buttonLineNotify.Enabled = false;
            buttonLoadProcess.Enabled = false;
            buttonStart.Enabled = false;
            checkedListBoxProcess.Enabled = false;

            _botListIndex = 0;
            _botForceStop = false;
            _lineAlreadySentProcess = new ArrayList();

            if (!String.IsNullOrEmpty(Settings.Default.LineToken))
            {
                _lineNotify = new LineNotify(Settings.Default.LineToken);
            }
            else
            {
                _lineNotify = null;
            }
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            timerBot.Enabled = false;
            buttonStart.Enabled = true;
            buttonLineNotify.Enabled = true;
            buttonLoadProcess.Enabled = true;
            buttonStart.Enabled = true;
            buttonStop.Enabled = false;
            checkedListBoxProcess.Enabled = true;

            _botListIndex = -1;
            _botForceStop = true;
        }

        private void timerBot_Tick(object sender, EventArgs e)
        {
            if (!_botWorking)
            {
                Debug.WriteLine("Bot working...");
                Bot();
            }
        }

        private async Task<List<ProcessInstanceItem>> getInstanceNames()
        {
            List<ProcessInstanceItem> list = new List<ProcessInstanceItem>();

            await Task.Run(() =>
            {
                Debug.WriteLine("Load instance names");

                PerformanceCounterCategory cat = new PerformanceCounterCategory("Process");

                string[] instances = cat.GetInstanceNames();

                Debug.WriteLine("Load instance names finished");

                foreach (string instance in instances)
                {
                    if (instance.StartsWith("YGOnline"))
                    {
                        using (PerformanceCounter cnt = new PerformanceCounter("Process", "ID Process", instance, true))
                        {
                            try
                            {
                                int pid = (int)cnt.RawValue;

                                list.Add(new ProcessInstanceItem(pid, instance));
                            }
                            catch (Exception ex)
                            {
                                Debug.WriteLine(ex.ToString());
                            }
                        }
                    }
                }
            });

            return list;
        }

        private async Task Bot()
        {
            _botWorking = true;

            int index = 0;
            bool found = false;
            bool last = false;
            Process process = null;
            String instanceName = "";
            foreach (var item in checkedListBoxProcess.CheckedItems)
            {
                if (_botListIndex == index)
                {
                    process = (item as ListBoxProcessItem)?.Process;
                    instanceName = (item as ListBoxProcessItem).InstanceName;
                    found = true;
                }

                index++;
            }

            if ((checkedListBoxProcess.CheckedItems.Count - 1) <= _botListIndex)
            {
                last = true;
            }

            if (!found)
            {
                _botListIndex = -1;
            }
            else
            {
                Log(@"������ӧҹ˹�Ҩ�: " + process.MainWindowTitle + " " + instanceName.Replace("YGOnline",""));
                bool processMissing = false;

                try
                {
                    if (process != null && !ProcessExists(process.Id))
                    {
                        processMissing = true;
                    }
                }
                catch (ArgumentException)
                {
                    processMissing = true;
                }

                if (process != null && !processMissing)
                {
                    if (instanceName != "")
                    {
                        Log(@"������Ѻ����Ѻ�觢������ 10 �Թҷ�");

                        float bytesIO = await GetIOBytesFromInstanceName(instanceName);

                        Debug.WriteLine($"Process ID: {process.Id}");
                        Debug.WriteLine($"Instance Name: {instanceName}");
                        Debug.WriteLine($"Bytes IO: {bytesIO}");
                        if (!_botForceStop)
                        {
                            if (bytesIO > 0)
                            {
                                Log($"������Ѻ�觢����� {bytesIO} Bytes � 10 �Թҷ�");
                            }
                            else
                            {
                                Log(@"��辺����Ѻ�觢������ 10 �Թҷ�");

                                if (_lineAlreadySentProcess.IndexOf(process.MainWindowHandle) == -1 && _lineNotify != null)
                                {
                                    Log(@"������͹价�� Line Notify");
                                    bool sentSuccess = await _lineNotify.send("���� " + process.MainWindowTitle + " �Ҵ������͵������ 10 �Թҷ� ��س��礷��������ͤ������");
                                    if (sentSuccess)
                                    {
                                        _lineAlreadySentProcess.Add(process.MainWindowHandle);
                                        Log(@"������͹���������");
                                    }
                                    else
                                    {
                                        Log(@"������͹�������� ���ͧ������ͺ�Ѵ�!");
                                    }
                                }
                                else if (_lineAlreadySentProcess.IndexOf(process.MainWindowHandle) > -1 && _lineNotify != null)
                                {
                                    Log(@"���觡������͹����� �������������͹˹�Ҩ͹��");
                                }
                                else if (_lineNotify != null)
                                {
                                    Log(@"������駤�� Line Notify �������������͹˹�Ҩ͹��");
                                }
                            }
                        }
                    }
                    else
                    {
                        //��辺 instanceName
                        Debug.WriteLine("instanceName is empty");

                        Log(@"�Դ��ͼԴ��Ҵ ��辺�����Ţͧ˹�Ҩ͹�� ��س���ش��÷ӧҹ������Ŵ�������������ա����!");
                    }
                }
                else
                {
                    //������͹��Ҩ����
                    Log(@"��˹�Ҩ͹������");

                    if (_lineAlreadySentProcess.IndexOf(process.MainWindowHandle) == -1 && _lineNotify != null)
                    {
                        Log("������͹价�� Line Notify");
                        bool sentSuccess = await _lineNotify.send("���� " + process.MainWindowTitle + " ���� ��س��礷��������ͤ������");
                        if (sentSuccess)
                        {
                            _lineAlreadySentProcess.Add(process.MainWindowHandle);
                            Log(@"������͹���������");
                        }
                        else
                        {
                            Log(@"������͹�������� ���ͧ������ͺ�Ѵ�!");
                        }
                    }
                    else if (_lineAlreadySentProcess.IndexOf(process.MainWindowHandle) > -1 && _lineNotify != null)
                    {
                        Log(@"���觡������͹����� �������������͹˹�Ҩ͹��");
                    }
                    else if (_lineNotify != null)
                    {
                        Log(@"������駤�� Line Notify �������������͹˹�Ҩ͹��");
                    }
                }

                Log(@"����÷ӧҹ˹�Ҩ͹��");
            }

            if (last)
            {
                _botListIndex = -1;
            }
            else
            {
                _botListIndex++;
            }

            _botWorking = false;
        }
        private async Task<float> GetIOBytesFromInstanceName(string instanceName, int seconds = 10)
        {
            return await Task.Run(() =>
            {
                float bytesIOAll = 0;

                for (int i = 0; i < seconds; i++)
                {
                    //stop loop when bot force stop
                    if (_botForceStop)
                    {
                        continue;
                    }

                    // Define the performance counter for Bytes IO/sec
                    PerformanceCounter bytesIOCounter = new PerformanceCounter("Process", "IO Data Bytes/sec", instanceName);

                    // Retrieve the initial value
                    float initialBytesIO = bytesIOCounter.NextValue();

                    Debug.WriteLine($"Monitoring network Bytes IO/sec for Process ({instanceName})...");

                    // Wait for a short duration (e.g., 1 second) and then check again
                    System.Threading.Thread.Sleep(1000);

                    // Retrieve the updated value
                    float currentBytesIO = bytesIOCounter.NextValue();

                    // Calculate the Bytes IO/sec
                    float bytesIOPerSec = currentBytesIO - initialBytesIO;

                    Debug.WriteLine($"Bytes IO/sec: {bytesIOPerSec}");

                    bytesIOAll += bytesIOPerSec;
                }


                return bytesIOAll;
            });
        }

        private bool ProcessExists(int pid)
        {
            return Process.GetProcesses().Any(x => x.Id == pid);
        }

        private void Log(string text)
        {
            DateTime tempDate = DateTime.Now;

            if(textBoxLog.Lines.Count() > 200)
            {
                textBoxLog.Text = "";
            }

            if (textBoxLog.Lines.Count() == 0)
            {
                textBoxLog.AppendText(tempDate.ToString("HH:mm:ss") + " : " + text);
            }
            else
            {
                textBoxLog.AppendText("\r\n" + tempDate.ToString("HH:mm:ss") + " : " + text);
            }
        }

        private void ToolStripMenuItemAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("�����������ҧ�� �������\n�ҡ�س���ѭ�� ��سҵԴ�������������", "����ǡѺ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ToolStripMenuItemUpdate_Click(object sender, EventArgs e)
        {
            Process myProcess = new Process();

            try
            {
                myProcess.StartInfo.UseShellExecute = true;
                myProcess.StartInfo.FileName = "https://github.com/meawmuay/yulgang-lost-connection";
                myProcess.Start();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private void buttonLineNotify_Click(object sender, EventArgs e)
        {
            FormLineToken formLineToken = new FormLineToken();
            formLineToken.ShowDialog();
        }

        private class GithubLatestReleasesAPI
        {
            public string name { get; set; }
        }

        private async Task<bool> CheckUpdateFromGithub()
        {
            return await Task.Run(async () =>
            {
                try
                {
                    var client = new RestClient(new RestClientOptions("https://api.github.com"));
                    var request = new RestRequest("/repos/meawmuay/yulgang-lost-connection/releases/latest", Method.Get);

                    request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };

                    var response = await client.ExecuteGetAsync<GithubLatestReleasesAPI>(request);

                    Debug.WriteLine("API GITHUB");
                    Debug.WriteLine(response.Content);
                    var version = "";

                    if (response.Data != null)
                    {
                        if (!String.IsNullOrEmpty(response.Data.name))
                        {
                            version = response.Data.name;
                            version = version.Replace("v", "");
                            if (Assembly.GetExecutingAssembly().GetName().Version.ToString() != version)
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                        else
                        {
                            return false;
                        }
                    }

                }
                catch (NullReferenceException ex)
                {
                    Debug.WriteLine(ex.ToString());
                }

                return false;
            });
        }
    }
}