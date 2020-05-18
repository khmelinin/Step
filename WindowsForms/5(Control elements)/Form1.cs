using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace _5_Control_elements_
{
    public partial class Form1 : Form
    {
        private Label _myLabel;
        public Form1()
        {
            InitializeComponent();
            labelName.Text = "Bogdan";
            _myLabel = new Label();
            // позиция
            _myLabel.Location = new Point(10, 30);
            // размер
            _myLabel.Size = new Size(400, 150);
            // значение текста
            _myLabel.Text = "Hello guys";
            // изменение шрифта
            _myLabel.Font = new Font("Arial", 20);
            // подписываем обработчик
            _myLabel.MouseClick += RemoveOnRightClick;
            // добавление 
            this.Controls.Add(_myLabel);
            CreateLabelWithImage();
        }
        private void RemoveOnRightClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                this.Controls.Remove(sender as Control);
            }
            else
            {
                MessageBox.Show("No no", "Title", MessageBoxButtons.OK, MessageBoxIcon.Hand);

            }
        }
        private void CreateLabelWithImage()
        {
            Label img_label = new Label();
            // img creation
            Image img = Image.FromFile(@"C:\Users\AdmiN\Pictures\car.gif");
            img_label.Size = new Size(img.Width, img.Height);
            // img installation
            img_label.Image = img;
            // possition
            img_label.Location = new Point(400, 200);
            this.Controls.Add(img_label);
        }


        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                textBox1.Cut();
            if (e.KeyCode == Keys.F2)
                textBox1.Paste();
            if (e.KeyCode == Keys.Delete)
                textBox1.Clear();
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            Text = $"x: {e.X}\ty: {e.Y}";
        }
    }
}
