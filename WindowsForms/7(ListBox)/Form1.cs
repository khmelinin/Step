using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _7_ListBox_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        private void buttonClearListBox_MouseClick(object sender, MouseEventArgs e)
        {
            listBox1.Items.Clear();
        }

        private void buttonClearSelected_Click(object sender, EventArgs e)
        {
            if(listBox1.SelectedItems.Count>0)
            {
                for (var i = 0; i < listBox1.SelectedItems.Count; i++)
                {
                    listBox1.Items.Remove(listBox1.SelectedItems[i]);
                    i--;
                }
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                if (!listBox1.Items.Contains(textBox1.Text))
                {
                    listBox1.Items.Add(textBox1.Text);
                    textBox1.Clear();
                }
                else
                {
                    MessageBox.Show("Textbox text must be unique", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Empty textbox", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void buttonCopy_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItems.Count > 0)
            {
                listBox2.Items.Clear();
                for (int i = 0; i < listBox1.SelectedItems.Count; i++)
                {
                    listBox2.Items.Add(listBox1.SelectedItems[i]);
                }
            }
            else
            {
                MessageBox.Show("Empty selected items", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonClearList2_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
        }

        private void buttonClearSelected2_Click(object sender, EventArgs e)
        {
            if (listBox2.SelectedItems.Count > 0)
            {
                for (var i = 0; i < listBox2.SelectedItems.Count; i++)
                {
                    listBox2.Items.Remove(listBox2.SelectedItems[i]);
                    i--;
                }
            }
            else
            {
                MessageBox.Show("Empty selected items", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCopySelected_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItems.Count > 0)
            {
                for (int i = 0; i < listBox1.SelectedItems.Count; i++)
                {
                    listBox2.Items.Add(listBox1.SelectedItems[i]);
                }
            }
            else
            {
                MessageBox.Show("Empty selected items", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
