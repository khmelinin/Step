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

namespace _17_DZ_
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
            Rectangle[,] rect = new Rectangle[8, 8];
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    rect[i, j] = new Rectangle(i * 30, j * 30, 30, 30);
                    
                    
                    if (i % 2 == 0 && j % 2 == 0 || i % 2 == 1 && j % 2 == 1)
                    {
                        g.FillRectangle(Brushes.Black, rect[i, j]);
                    }
                    
                    else
                    {
                        g.FillRectangle(Brushes.White, rect[i, j]);
                    }
                }

            }

            Pen penB = new Pen(Brushes.Blue, 3);
            Pen penW = new Pen(Brushes.Red, 3);
            penB.DashStyle = DashStyle.Solid;
            penW.DashStyle = DashStyle.Solid;

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (j < 2)
                        if (i % 2 == 0 && j % 2 == 0 || i % 2 == 1 && j % 2 == 1)
                        {
                            g.DrawEllipse(penW, i * 30, j * 30, 30, 30);
                        }
                    if (j > 5)
                            if (i % 2 == 0 && j % 2 == 0 || i % 2 == 1 && j % 2 == 1)
                            {
                                g.DrawEllipse(penB, i * 30, j * 30, 30, 30);
                            }
                }
            }
            g.Dispose();
        }
    }
}
