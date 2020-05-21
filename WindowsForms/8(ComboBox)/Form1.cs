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

namespace _8_ComboBox_
{
    public partial class Form1 : Form
    {
        List<string> autos = new List<string> { "Nissan", "Honda", "Mitsubishi", "Dodge", "Ford", "Lamborghini" };
        List<string> fruits = new List<string> { "Apple", "Pineapple", "Lemon" };
        List<string> students = new List<string> { "Vasya Pupkin", "Ivan Ivanov", "Pavel Levap" };
        List<string> cities = new List<string> { "Kyiv", "Ekaterinburg", "New-York" };
        public Form1()
        {
            InitializeComponent();
        }

        private void comboBox2_SelectedValueChanged(object sender, EventArgs e)
        {
            switch(comboBox2.SelectedItem)
            {
                case "Autos":
                    checkedListBox1.Items.Clear();
                    checkedListBox1.Items.AddRange(autos.ToArray());
                    break;
                case "Fruits":
                    checkedListBox1.Items.Clear();
                    checkedListBox1.Items.AddRange(fruits.ToArray());
                    break;
                case "Students":
                    checkedListBox1.Items.Clear();
                    checkedListBox1.Items.AddRange(students.ToArray());
                    break;
                case "Cities":
                    checkedListBox1.Items.Clear();
                    checkedListBox1.Items.AddRange(cities.ToArray());
                    break;
                default:
                    checkedListBox1.Items.Clear();
                    break;
            }
        }

        private void SortButton_Click(object sender, EventArgs e)
        {
            checkedListBox1.Sorted = true;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            checkedListBox1.Sorted = false;
            checkedListBox1.Items.Add(textBox1.Text);
        }

        private void CopyCheckedButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox1.CheckedItems.Count; i++)
            {
                listBox1.Items.Add(checkedListBox1.CheckedItems[i]);
            }
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
                    while ((line = sr.ReadLine()) != null)
                    {
                        listBox1.Items.Add(line);
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
                    foreach (var item in listBox1.Items)
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

        private void SaveButton_Click(object sender, EventArgs e)
        {
            SaveTxt("");
        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            LoadFromTxt("");
        }
    }
}
