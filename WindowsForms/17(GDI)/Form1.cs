using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _17_GDI_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Paint += Form1_Paint;
        }

        void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen pen = new Pen(Brushes.Red, 5);
            pen.DashStyle = DashStyle.Dot;
            g.DrawEllipse(pen, 50, 200, 170, 40);

            // gradient
            // LinearGradientBrush

            // fill
            // HatchBrush

            // fill by image
            //TextureBrush
            Rectangle recrImage = this.ClientRectangle;
            Image img = new Bitmap(Properties.Resources.fire1);
            g.DrawImage(img, recrImage);

            Rectangle rect = new Rectangle(20, 20, 200, 40);
            LinearGradientBrush lgBrush = new LinearGradientBrush(rect, Color.Yellow, Color.Black, 0.0f, true);
            g.FillRectangle(lgBrush, rect);

            Rectangle rect2 = new Rectangle(20, 80, 200, 40);
            HatchBrush hBrush = new HatchBrush(HatchStyle.Cross, Color.DeepPink, Color.Orange);
            g.FillRectangle(hBrush, rect2);

            Rectangle rect3 = new Rectangle(20, 140, 200, 40);
            TextureBrush tBrush = new TextureBrush(new Bitmap(Properties.Resources._4c6faeb30858abc9fea9924e369e927b_1400));
            g.FillRectangle(tBrush, rect3);

            Font f = new Font("Arial", 14, FontStyle.Bold);
            g.DrawString("Ohayo", f, Brushes.Brown, 30, 250);

            Font f1 = new Font("Arial", 14, FontStyle.Bold | FontStyle.Italic);
            g.DrawString("Ohayo, but Italic", f1, Brushes.Brown, 30, 270);

            

            g.Dispose();
        }
    }
}
