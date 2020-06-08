using System;
using System.Drawing;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _17_region_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Paint += Form1_Paint;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            Rectangle rect1 = new Rectangle(40, 40, 140, 140);
            Rectangle rect2 = new Rectangle(100, 100, 140, 140);

            Region rgn1 = new Region(rect1);
            Region rgn2 = new Region(rect2);

            g.DrawRectangle(Pens.Red, rect1);
            g.DrawRectangle(Pens.Black, rect2);

            rgn1.Intersect(rgn2);
            g.FillRegion(Brushes.Yellow, rgn1);
            g.Dispose();
        }
    }
}
