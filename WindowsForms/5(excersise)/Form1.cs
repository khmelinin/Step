using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _5_excersise_
{
    
    public partial class Form1 : Form
    {
        private List<Label> label = new List<Label>();
        private TextBox textBox1 = new TextBox();
        public Form1()
        {
            InitializeComponent();

            textBox1.Size = new Size(100, 30);
            textBox1.Location = new Point(100, 100);
            textBox1.MouseMove += textBox1_MouseMove;

            label.Add(new Label());
            for (int i = 0; i < label.Count; i++)
            {
                label[i].MouseClick += CreateNumber;
            }
            //когда добавляеться текстбокс, то не работают предыдущие задания; убегает не всегда
            //this.Controls.Add(textBox1);

        }
        private void CreateNumber(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Label tmp = new Label();
                tmp.Size = new Size(20, 20);
                tmp.Location = new Point(e.X, e.Y);
                tmp.Text = $"{label.Count}";
                tmp.MouseClick += HideNumber;
                label.Add(tmp);
            }
        }
        private void ShowLebels(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.F1)
            this.Controls.AddRange(label.ToArray());
        }
        private void HideNumber(object sender, MouseEventArgs e)
        {
            if(e.Button==MouseButtons.Right)
                this.Controls.Remove(sender as Control);
        }

        
        
        private void textBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.X < textBox1.Location.X && e.X > textBox1.Location.X-10 ||
                e.X > textBox1.Location.X && e.X < textBox1.Location.X + 10 ||
                e.Y < textBox1.Location.X && e.Y > textBox1.Location.Y + 10 ||
                e.Y > textBox1.Location.X && e.Y < textBox1.Location.Y - 10)
            {
                if (textBox1.Location.X < 0 || textBox1.Location.X > this.Location.X || textBox1.Location.Y < 0 || textBox1.Location.Y > this.Location.Y)
                {
                    textBox1.Location = new Point(100, 100);
                }
                else
                {
                    this.Controls.Remove(textBox1);
                    textBox1.Location = new Point(e.Location.X + 30, e.Location.Y + 30);
                    this.Controls.Add(textBox1);
                }
            }
        }
        
        
    }
}
