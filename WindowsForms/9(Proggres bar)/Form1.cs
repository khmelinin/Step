using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _9_Proggres_bar_
{
    public partial class Form1 : Form
    {
        private VScrollBar vScroll;
        private HScrollBar hScroll;
        private List<string> tmp = new List<string>();
        public Form1()
        {
            InitializeComponent();
            
            button2.Enabled = false;

            vScroll = new VScrollBar();
            vScroll.Dock = DockStyle.Right;
            vScroll.Scroll += vs_scroll;
            this.Controls.Add(vScroll);
            
            hScroll = new HScrollBar();
            hScroll.Dock = DockStyle.Bottom;
            hScroll.Scroll += vs_scroll;
            this.Controls.Add(hScroll);

            
        }

        

        void LoadFromTxt(string p)
        {
            var path = "1.txt";
            
            if (p.Length > 0)
            {
                path = p;
            }
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    string line;

                    for (int i = 0; (line = sr.ReadLine()) != null; i++)
                    {
                        tmp.Add(line);
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "File Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void Read(string p)
        {
            LoadFromTxt(p);
            progressBar2.Maximum = tmp.Count-1;
            progressBar2.PerformStep();
            for (int i = progressBar2.Minimum; i <= progressBar2.Maximum; i += progressBar2.Step)
            {
                textBox2.Text += tmp[i];
                textBox2.Text += Environment.NewLine;
                progressBar2.PerformStep();
                this.Update();
                Thread.Sleep(100);
            }
            
        }

        private void vs_scroll(object sender, EventArgs e)
        {
            this.Text = $"VS: {vScroll.Value}; HS: {hScroll.Value}";
        }

        private bool Validation()
        {
            if (numericUpDown1.Value < numericUpDown2.Value && numericUpDown3.Value < numericUpDown2.Value - numericUpDown1.Value && numericUpDown3.Value>numericUpDown1.Value)
            {
                progressBar1.Minimum = Convert.ToInt32(numericUpDown1.Value);
                progressBar1.Maximum = Convert.ToInt32(numericUpDown2.Value);
                progressBar1.Step = Convert.ToInt32(numericUpDown3.Value);
                return true;
            }
            else
            {
                MessageBox.Show("ProgressBar min,max,step incorrect value", "Value Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            button2.Enabled = false;
            if (Validation())
            {
                progressBar1.PerformStep();
                for (int i = progressBar1.Minimum; i <= progressBar1.Maximum; i += progressBar1.Step)
                {
                    progressBar1.PerformStep();

                    label1.Text = $@"Value = {progressBar1.Value}";
                    this.Update();
                    Thread.Sleep(progressBar1.Step * 1000);
                }
                button2.Enabled = true;
            }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            progressBar1.Value = progressBar1.Minimum;
            label1.Text = "Value = 0";
            this.Update();
            button2.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button3.Enabled = false;
            progressBar2.Value = 0;
            progressBar2.Minimum = 0;
            progressBar2.Step = 1;
            Read(textBox1.Text);
            button3.Enabled = true;
        }
    }
}
