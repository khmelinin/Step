using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _12_text_editor_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "all (*.*)|*.*|txt (*.txt)|*.txt|cpp (*.cpp)|*.cpp|h (*.h)|*.h|cs (*.cs)|*.cs||";
            open.FilterIndex = 1;
            if(open.ShowDialog()==DialogResult.OK)
            {
                using (StreamReader sr = new StreamReader(open.FileName))
                {
                    textBox1.Text = sr.ReadToEnd();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            if(save.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(save.FileName))
                {
                    sw.Write(textBox1.Text);
                }
            }
        }
    }
}
