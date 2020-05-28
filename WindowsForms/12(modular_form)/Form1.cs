using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _12_modular_form_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Label l = new Label();
            l.Text = "ku";
            l.Font = new Font("Arial",50);
            l.Dock = DockStyle.Fill;
            this.Controls.Add(l);
        }
    }
}
