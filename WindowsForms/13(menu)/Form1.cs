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

namespace _13_menu_
{
    public partial class Form1 : Form
    {
        Color _bgColor;
        SaveFileDialog _sd;
        ColorDialog _cdf;
        ColorDialog _cdb;
        public Form1()
        {
            InitializeComponent();
            for (int i = 0; i < 30; i++)
            {
                TextSizetoolStripComboBoxEng.Items.Add(i + 1 * 2);
                TextSizetoolStripComboBoxRu.Items.Add(i + 1 * 2);
            }
            //TextSizetoolStripComboBoxEng.
            _bgColor = this.BackColor;
            button1.Text = "Eng";
            menuStripRu.Visible = false;

            красныйToolStripMenuItem.Click += redToolStripMenuItem_Click;
            цветШрифтаToolStripMenuItem1.Click += textColorToolStripMenuItem_Click;

            копироватьToolStripMenuItem.Click += copyToolStripMenuItem_Click;
            отменитьДействиеToolStripMenuItem.Click += undoToolStripMenuItem_Click;
            вставитьToolStripMenuItem.Click += pasteToolStripMenuItem_Click;
            вырезаьToolStripMenuItem.Click += cutToolStripMenuItem_Click;
            выделитьВсеToolStripMenuItem.Click += selectAllToolStripMenuItem_Click;

            открытьToolStripMenuItem.Click += openToolStripMenuItem_Click;
            закрытьToolStripMenuItem.Click += closeToolStripMenuItem_Click;
            создатьНовыйToolStripMenuItem.Click += newToolStripMenuItem_Click;
            сохранитьToolStripMenuItem.Click += saveToolStripMenuItem_Click;
            сохранитьКакToolStripMenuItem.Click += saveAsToolStripMenuItem_Click;


        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0)
            {
                MessageBox.Show("Do you want to save this file?", "Warning", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (DialogResult == DialogResult.Yes)
                {
                    Save();
                    this.Close();
                }
                else
                if (DialogResult == DialogResult.No)
                {
                    this.Close();
                }
            }
        }

        private void redToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem it = (ToolStripMenuItem)sender;
            if (it.Checked == true)
            {
                this.BackColor = Color.Red;
            }
            else
            {
                this.BackColor = _bgColor;
            }
            this.Text = $"{this.BackColor.R.ToString()}, {this.BackColor.G.ToString()}, {this.BackColor.B.ToString()}";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text.CompareTo("Eng") == 0)
            {
                button1.Text = "Ru";
                menuStripEng.Visible = false;
                menuStripRu.Visible = true;
                this.MainMenuStrip = menuStripRu;
            }
            else if (button1.Text.CompareTo("Ru") == 0)
            {
                button1.Text = "Eng";
                menuStripEng.Visible = true;
                menuStripRu.Visible = false;
                this.MainMenuStrip = menuStripEng;
            }
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Copy();
        }
        void Open()
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "all (*.*)|*.*|txt (*.txt)|*.txt|cpp (*.cpp)|*.cpp|h (*.h)|*.h|cs (*.cs)|*.cs||";
            open.FilterIndex = 1;
            if (open.ShowDialog() == DialogResult.OK)
            {
                using (StreamReader sr = new StreamReader(open.FileName))
                {
                    textBox1.Text = sr.ReadToEnd();
                }
            }
        }
        void Save()
        {
            _sd = new SaveFileDialog();
            if (_sd.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(_sd.FileName))
                {
                    sw.Write(textBox1.Text);
                }
            }
        }
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (textBox1.Text.Length > 0)
            {
                MessageBox.Show("Do you want to save this file?", "Warning", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (DialogResult == DialogResult.Yes)
                {
                    Save();
                    Open();
                }
                else
                if (DialogResult == DialogResult.No)
                {
                    Open();
                }
            }


        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_sd == null)
            {
                Save();
            }
            else
            {
                using (StreamWriter sw = new StreamWriter(_sd.FileName))
                {
                    sw.Write(textBox1.Text);
                }
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0)
            {
                MessageBox.Show("Do you want to save this file?", "Warning", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (DialogResult == DialogResult.Yes)
                {
                    Save();
                    textBox1.Clear();
                }
                else
                    if (DialogResult == DialogResult.No)
                {
                    textBox1.Clear();
                }
            }
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Undo();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Cut();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Paste();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.SelectAll();
        }

        

        private void textColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _cdf = new ColorDialog();
            _cdf.ShowDialog();
            textBox1.ForeColor = _cdf.Color;
        }

        private void textBackgroundColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _cdb = new ColorDialog();
            _cdb.ShowDialog();
            textBox1.BackColor = _cdf.Color;
        }

        private void TextSizetoolStripComboBoxEng_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                textBox1.Font = new Font("Arial", float.Parse(TextSizetoolStripComboBoxEng.SelectedItem.ToString()), FontStyle.Regular);
            }
            catch(Exception ee)
            {
                MessageBox.Show(ee.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TextSizetoolStripComboBoxRu_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                textBox1.Font = new Font("Arial", float.Parse(TextSizetoolStripComboBoxRu.SelectedItem.ToString()), FontStyle.Regular);
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
