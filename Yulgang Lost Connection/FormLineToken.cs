using System.Diagnostics;
using Yulgang_Lost_Connection.Properties;

namespace Yulgang_Lost_Connection
{
    public partial class FormLineToken : Form
    {
        public FormLineToken()
        {
            InitializeComponent();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {

            Settings.Default.LineToken = textBoxLineToken.Text;
            Settings.Default.Save();

            Close();
        }

        private void FormLineToken_Load(object sender, EventArgs e)
        {
            textBoxLineToken.Text = Settings.Default.LineToken;
        }

        private void buttonTest_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("TEST1");
            
            var line = new LineNotify(textBoxLineToken.Text);
            line.test();
        }
    }
}
