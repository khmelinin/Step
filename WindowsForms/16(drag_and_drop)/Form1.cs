using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _16_drag_and_drop_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
            listBox1.AllowDrop = true;

            textBox1.MouseDown += TextBox1_MouseDown;

            listBox1.DragEnter += ListBox1_DragEnter;
            listBox1.DragDrop += ListBox1_DragDrop;
            pictureBox1.MouseDown += PictureBox1_MouseDown;
        }

        private void PictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox1.DoDragDrop(pictureBox1.Image, DragDropEffects.Copy);
        }

        private void ListBox1_DragDrop(object sender, DragEventArgs e)
        {
            listBox1.Items.Add(e.Data.GetData(DataFormats.StringFormat).ToString());
        }

        private void ListBox1_DragEnter(object sender, DragEventArgs e)
        {
            if(e.Data.GetDataPresent(DataFormats.StringFormat))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void TextBox1_MouseDown(object sender, MouseEventArgs e)
        {
            textBox1.DoDragDrop(textBox1.Text, DragDropEffects.Copy);
        }
    }
}
