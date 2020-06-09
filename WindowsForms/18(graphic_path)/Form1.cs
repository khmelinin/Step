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

namespace _18_graphic_path_
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
            Point[] points =
            {
                new Point(5,10),
                new Point(23,130),
                new Point(130,57)
            };

            GraphicsPath path = new GraphicsPath();
            //first traectory
            path.StartFigure();
            path.AddEllipse(170, 170, 100, 50);
            //fill
            e.Graphics.FillPath(Brushes.Blue, path);
            //second traectory
            path.StartFigure();
            path.AddCurve(points, 0.5f);
            path.AddArc(100, 50, 100, 100, 0, 120);
            path.AddLine(50, 150, 50, 220);
            path.CloseFigure();
            //third traectory
            path.StartFigure();
            path.AddArc(180, 30, 60, 60, 0, -170);
            //path.CloseFigure();
            e.Graphics.DrawPath(new Pen(Color.Violet, 3), path);

            //editing start of coordinatesv                                                                           
            e.Graphics.TranslateTransform(300, 100);

            Point a = new Point(0, 0);
            Point b = new Point(120, 120);
            e.Graphics.DrawLine(new Pen(Brushes.Blue, 3), a, b);
        }
    }
}
