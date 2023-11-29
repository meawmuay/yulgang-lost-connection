using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yulgang_Lost_Connection
{
    internal class ListBoxProcessItem
    {
        public ListBoxProcessItem(string text, Process process, String instanceName)
        {
            this.Process = process;
            this.Value = process.MainWindowTitle;
            this.Text = text;
            this.InstanceName = instanceName;
        }
        public string Text { get; set; }
        public string Value { get; set; }

        public Process Process { get; set; }

        public String InstanceName { get; set; }
    }
}
