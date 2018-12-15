using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Event
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public event EventHandler<BtnClickEventArgs> BtnClickEvent;

        private void button1_Click(object sender, EventArgs e)
        {
            EventHandler<BtnClickEventArgs> temp = BtnClickEvent;
            if (temp != null)
            {
                BtnClickEventArgs ee = new BtnClickEventArgs();
                ee.Value = label1.Text;

                temp(sender, ee);
            }
        }
    }

    public class BtnClickEventArgs:EventArgs
    {
        public string Value { get; set; }
    }
}
