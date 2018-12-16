using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Pipes;
using System.Threading;
using System.IO;
using System.Security.Principal;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SendMessages();
        }

        void SendMessages()
        {
            IntPtr intPtr = Process.GetProcessesByName("ProcessA")[0].MainWindowHandle;
            int data = Convert.ToInt32(label1.Text);
            SendMessage(intPtr, 0x0100, (IntPtr)data, (IntPtr)0);
        }

        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        private extern static int SendMessage(IntPtr wnd, int msg, IntPtr wP, IntPtr lP);

    }
}
