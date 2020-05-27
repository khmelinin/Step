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
    public partial class Form1 : Form
    {
        bool sort = false;
        bool ok = true;
        public Form1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            listBox1.Items.Remove(listBox1.SelectedItem);
        }



        private void textBox1_Click(object sender, EventArgs e)
        {
            if (ok)
            {
                ok = false;
                textBox1.Clear();
            }
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            try
            {
                Child ch = new Child();
                ch.ShowDialog();
                listBox1.Items.Add(ch.TbText);
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            var path = "1.txt";
            if (textBox1.Text.Length > 0 && textBox1.Text != "default")
            {
                path = textBox1.Text;
            }
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        listBox1.Items.Add(line);
                    }
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message, "File Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            var path = "1.txt";
            if (textBox1.Text.Length > 0 && textBox1.Text != "default")
            {
                path = textBox1.Text;
            }
            try
            {
                using (StreamWriter sr = new StreamWriter(path))
                {
                    foreach (var item in listBox1.Items)
                    {
                        sr.WriteLine(item);
                    }
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message, "File Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                Child ch = new Child();
                ch.ShowDialog();
                listBox1.Items[listBox1.SelectedIndex] = ch.TbText;
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonRead_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show(listBox1.SelectedItem.ToString(), $@"Item index: {listBox1.SelectedIndex}", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception ee)
            {
                MessageBox.Show(ee.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        private void buttonSort_Click(object sender, EventArgs e)
        {
            if (sort)
                sort = false;
            else
                sort = true;
            listBox1.Sorted = sort;
            label2.Text = sort.ToString();
        }
    }
}

