using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _11_modal_windows_
{
    public partial class Child : Form
    {
        
        public string TbText
        {
            set => textBox2.Text = value;
            get => textBox2.Text;
        }


        public Child()
        {
            InitializeComponent();
            
        }
        
        

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
        public DialogResult ShowDialog(string message)
        {
            
            return ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

       
    }
}
