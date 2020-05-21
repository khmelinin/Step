using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _8_CheckedListBox_
{
    public partial class Form1 : Form
    {
        private List<string> nameslist;
        public Form1()
        {
            InitializeComponent();
            nameslist = new List<string> { "Masha", "Katya", "Dasha" };
        }

        private void button1_Click(object sender, EventArgs e)
        {
            checkedListBox1.Items.AddRange(nameslist.ToArray());
            
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            checkedListBox1.Items.Clear();
        }

        private void ClearSelectedButton_Click(object sender, EventArgs e)
        {
            checkedListBox1.Items.Remove(checkedListBox1.SelectedItem);
        }

        private void InsertButton_Click(object sender, EventArgs e)
        {
            int index = Convert.ToInt32(numericUpDown1.Value);
            checkedListBox1.Items.Insert(index, textBox1.Text);
        }

        private void Remove_Click(object sender, EventArgs e)
        {
            checkedListBox1.Items.Remove(textBox1.Text);
        }

        private void RemoveAtButton_Click(object sender, EventArgs e)
        {
            checkedListBox1.Items.RemoveAt(Convert.ToInt32(numericUpDown1.Value));
        }

        private void ClearButton_Click_1(object sender, EventArgs e)
        {
            checkedListBox1.Items.Clear();
        }

        private void ShowCheckedButton_Click(object sender, EventArgs e)
        {
            string str = "Checked items:\n";
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                if(checkedListBox1.GetItemChecked(i))
                {
                    str += $"Index: {i}\t {checkedListBox1.Items[i]}\n";
                }
            }
            MessageBox.Show(str);
        }
    }
}
