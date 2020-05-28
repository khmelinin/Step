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
    public partial class Editor : Form
    {
        bool isAddNew;
        Product _prod;
       
        public Editor()
        {
            InitializeComponent();
        }

        public Editor(bool isAddNew, Product prod)
        {
            InitializeComponent();
            this.isAddNew = isAddNew;
            this._prod = prod;
            if (isAddNew == false)
            {
                textBoxName.Text = prod.Name;
                textBoxMadeIn.Text = prod.Made_in;
                numericUpDownPrice.Value = Convert.ToDecimal(prod.Price);
                this.Text = "Product redactor";
            }
            else
            {
                this.Text = "Product Creator";
            }
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text) ||
                string.IsNullOrWhiteSpace(textBoxName.Text) ||
                string.IsNullOrEmpty(textBoxMadeIn.Text) ||
                string.IsNullOrWhiteSpace(textBoxMadeIn.Text) ||
                numericUpDownPrice.Value == 0)
            {
                MessageBox.Show("Fill all fields", "Data Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                if (_prod == null)
                {
                    _prod = new Product();
                }
                    _prod.Name = textBoxName.Text;
                    _prod.Made_in = textBoxMadeIn.Text;
                    _prod.Price = Convert.ToDouble(numericUpDownPrice.Value);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            this.DialogResult = DialogResult.OK;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
