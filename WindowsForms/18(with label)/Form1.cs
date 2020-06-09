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

namespace _18_with_label_
{
    public partial class Form1 : Form
    {
        int _paintCount;
        List<Point> _points;
        public Form1()
        {
            InitializeComponent();
            Paint += Form1_Paint;

            _paintCount = 0;

            /*
            Graphics g = this.CreateGraphics();
            SolidBrush redBrush = new SolidBrush(Color.Red);
            Rectangle rect = new Rectangle(0, 0, 250, 140);
            g.FillRectangle(redBrush, rect);
            g.Dispose();
            */

            _points = new List<Point>();
            this.MouseClick += Form1_MouseClick;

        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            _points.Add(new Point(e.X, e.Y));
            // repaint client area
            this.Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {

            /*
            if(e.ClipRectangle.Top<140&&e.ClipRectangle.Left<250)
            {
                SolidBrush redBrush = new SolidBrush(Color.Red);
                Rectangle rect = new Rectangle(0, 0, 250, 140);
                e.Graphics.FillRectangle(redBrush, rect);
                label1.Text = $"{++_paintCount}";
            }
            */

            int x = 23;
            int y = 33;
            int height = 60;
            int width = 60;

            Pen pn = new Pen(Color.Brown, 4);
            pn.DashStyle = DashStyle.Dash;

            Point strPt = new Point(10, 10);
            Size sz = new Size(160, 160);

            Rectangle rect = new Rectangle(strPt, sz);
            Rectangle rect2 = new Rectangle(x, y, width, height);

            e.Graphics.FillEllipse(Brushes.Black, rect);
            e.Graphics.DrawEllipse(pn, rect2);

            Pen bluePen = new Pen(Color.Blue, 6);
            bluePen.StartCap = LineCap.RoundAnchor;
            bluePen.EndCap = LineCap.ArrowAnchor;
            bluePen.DashStyle = DashStyle.DashDot;
            bluePen.DashCap = DashCap.Round;
            e.Graphics.DrawLine(bluePen, 250, 100, 500, 100);
            bluePen.Dispose();

            foreach(var point in _points)
            {
                e.Graphics.FillEllipse(Brushes.Black, point.X, point.Y, 10f, 10f);
            }
        }
    }
}
