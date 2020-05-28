using _12_shop_.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _12_shop_
{
    public partial class Form1 : Form
    {
        Product _product;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _product = new Product();
            Editor ed = new Editor(true, _product);
            if(ed.ShowDialog()==DialogResult.OK)
            {
                listBox1.Items.Add(_product);
            }
            else
            {
                MessageBox.Show("Cancelled", "Abort", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(listBox1.SelectedIndex==-1)
            {
                MessageBox.Show("Choose one of products", "Choose", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            var selectedIndex = listBox1.SelectedIndex;
            _product = (Product)listBox1.Items[selectedIndex];
            Editor ed = new Editor(false, _product);
            if(ed.ShowDialog() == DialogResult.OK)
            {
                listBox1.Items.RemoveAt(selectedIndex);
                listBox1.Items.Insert(selectedIndex, _product);
                listBox1.SelectedIndex = selectedIndex;
            }
            else
            {
                MessageBox.Show("Cancelled", "Abort", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != 1)
            {
                var result = MessageBox.Show("Delete?", "delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    listBox1.Items.RemoveAt(listBox1.SelectedIndex);
                }

            }
            else
            {
                MessageBox.Show("Choose one of products", "Choose", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != 1)
            {
                MessageBox.Show($"{(Product)listBox1.Items[listBox1.SelectedIndex]}");

            }
            else
            {
                MessageBox.Show("Choose one of products", "Choose", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Clear ALL?", "clear", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                listBox1.Items.Clear();
            }
            else
            {
                MessageBox.Show("Cancelled", "Abort", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
