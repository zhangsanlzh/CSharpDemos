using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Button
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            button1.Paint += Button_Paint;
            button2.Paint += Button_Paint;

            checkBox1.Paint += CheckBox1_Paint;
            checkBox1.Click += CheckBox1_Click;
        }

        private void CheckBox1_Click(object sender, EventArgs e)
        {
            isCheck = !isCheck;
            (sender as CheckBox).Invalidate();
        }

        bool isCheck = false;
        /// <summary>
        /// 是否选中
        /// </summary>
        public bool Checked
        {
            set { isCheck = value; this.Invalidate(); }
            get { return isCheck; }
        }

        private void CheckBox1_Paint(object sender, PaintEventArgs e)
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.Selectable, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.BackColor = Color.Transparent;

            Bitmap bitMapOn = global::Button.Properties.Resources.open;
            Bitmap bitMapOff = global::Button.Properties.Resources.close;

            Graphics g = e.Graphics;
            Rectangle rec = new Rectangle(0, 0, (sender as CheckBox).Size.Width, (sender as CheckBox).Size.Height);
            if (isCheck)
            {
                g.DrawImage(bitMapOn, rec);
            }
            else
            {
                g.DrawImage(bitMapOff, rec);
            }

        }

        private void Button_Paint(object sender, PaintEventArgs e)
        {
            GraphicsPath buttonPath = new GraphicsPath();
            Rectangle newRectangle = (sender as ButtonBase).ClientRectangle;
            newRectangle.Inflate(-5, -5);

            e.Graphics.DrawEllipse(Pens.Black, newRectangle);
            newRectangle.Inflate(1, 1);
            buttonPath.AddEllipse(newRectangle);

            (sender as ButtonBase).Region = new Region(buttonPath);
        }
    }
}
