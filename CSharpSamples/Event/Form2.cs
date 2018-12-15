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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();

            Load += Form2_Load;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Form1 fm = new Form1();
            fm.BtnClickEvent += Fm_BtnClickEvent;

            fm.Show();
        }

        private void Fm_BtnClickEvent(object sender, BtnClickEventArgs e)
        {
            label1.Text = e.Value;
        }
    }
}
