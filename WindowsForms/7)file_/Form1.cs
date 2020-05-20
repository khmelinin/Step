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

namespace _7_file_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

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
                    while((line=sr.ReadLine())!=null)
                    {
                        listBoxStudents.Items.Add(line);
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "File Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void SaveTxt(string p)
        {
            var path = "1.txt";
            if (p.Length > 0)
            {
                path = p;
            }
            try
            {
                using (StreamWriter sr = new StreamWriter(path))
                {
                    foreach(var item in listBoxStudents.Items)
                    {
                        sr.WriteLine(item);
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "File Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            if (listBoxStudents.SelectedItems.Count==1)
            {
                textBox1.Text += (listBoxStudents.SelectedItems[0].ToString());
                listBoxStudents.Items.Remove(listBoxStudents.SelectedItems[0]);
            }
            else
            {
                MessageBox.Show("Select one item", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if(AutoSaveChackBox.Checked)
            {
                SaveTxt(textBoxPath.Text);
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                if (!listBoxStudents.Items.Contains(textBox1.Text))
                {
                    listBoxStudents.Items.Add(textBox1.Text);
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
            if (AutoSaveChackBox.Checked)
            {
                SaveTxt(textBoxPath.Text);
            }
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            if (listBoxStudents.SelectedItems.Count > 0)
            {
                for (var i = 0; i < listBoxStudents.SelectedItems.Count; i++)
                {
                    listBoxStudents.Items.Remove(listBoxStudents.SelectedItems[i]);
                    i--;
                }
            }
            else
            {
                MessageBox.Show("Empty selected items", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (AutoSaveChackBox.Checked)
            {
                SaveTxt(textBoxPath.Text);
            }

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AddButton_Click(sender, e);
            }
        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            LoadFromTxt(textBoxPath.Text);
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            SaveTxt(textBoxPath.Text);
        }
    }
}
