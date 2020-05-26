using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _10_tool_tip_
{
    public partial class Form1 : Form
    {
        ToolTip toolTip1 = new ToolTip();
        public enum DateTimeFormat { ShortFormat, LongFormat};
        bool ok = true;

        public Form1()
        {
            InitializeComponent();
            toolTip1.InitialDelay = 100;
            this.toolTip1.SetToolTip(this.button1,"don't tuch this");
            this.toolTip1.SetToolTip(this.textBox1, "Some text");
            this.toolTip1.ToolTipIcon = ToolTipIcon.Info;
            
            timer1.Interval = 1000;

            this.trackBarRED.Scroll += UpdateColor;
            this.trackBarGREEN.Scroll += UpdateColor;
            this.trackBarBLUE.Scroll += UpdateColor;

            this.trackBarImageX.Scroll += UpdateImgSize;
            this.trackBarImageY.Scroll += UpdateImgSize;

            //this.pictureBox2.Load(@"https://media1.tenor.com/images/f6e669c6a6c7cb68fe906e03f5e1e979/tenor.gif?itemid=12900710");
            
            /*
            Image img = new Bitmap(@"https://media1.tenor.com/images/f6e669c6a6c7cb68fe906e03f5e1e979/tenor.gif?itemid=12900710");
            Bitmap bm = new Bitmap(img, 100, 100);
            pictureBox2.Image = bm;
            */
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0 && textBox1.Text!="default")
            {
                try
                {
                    Image img = new Bitmap(textBox1.Text);
                    Bitmap bm = new Bitmap(img, 100, 100);
                    pictureBox1.Image = bm;
                }
                catch(Exception excep)
                {
                    MessageBox.Show(excep.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            string str = DateTime.Now.ToLongDateString();
            this.toolStripStatusLabel1.Text = str;
            str = DateTime.Now.DayOfWeek.ToString();
            dayOfWeekToolStripMenuItem.Text = str;

            str = DateTime.Now.ToShortTimeString();
            toolStripStatusLabel2.Text = str;

            if(this.format == DateTimeFormat.ShortFormat)
            {
                this.toolStripStatusLabel1.Text = DateTime.Now.ToShortDateString();
                format = DateTimeFormat.LongFormat;
            }
            else if(this.format == DateTimeFormat.LongFormat)
            {
                this.toolStripStatusLabel1.Text = DateTime.Now.ToLongDateString();
                format = DateTimeFormat.ShortFormat;
            }
        }

        private void UpdateColor(object sender, EventArgs e)
        {
            Color color = Color.FromArgb(this.trackBarRED.Value, this.trackBarGREEN.Value, this.trackBarBLUE.Value);
            this.labelRGB.Text = $"RGB: ({color.R}, {color.G}, {color.B})";
            this.BackColor = color;
            foreach (var control in this.Controls)
            {
                (control as Control).BackColor = color;
            }
        }
        private void UpdateImgSize(object sender, EventArgs e)
        {
            pictureBox1.Size = new Size(trackBarImageX.Value, trackBarImageY.Value);
            label1.Text = $@"Size: {trackBarImageX.Value} ,{trackBarImageY.Value}";
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            if (ok)
            {
                textBox1.Clear();
                ok = false;
            }
        }
    }
}
