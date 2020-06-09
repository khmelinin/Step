using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _18_DZ_
{
    public partial class Form1 : Form
    {
        List<Point> _points;
        GraphicsPath _path;
        public Form1()
        {
            InitializeComponent();
            
            _points = new List<Point>();
            _path = new GraphicsPath();
            MouseClick += Form1_MouseClick;
            Paint += Form1_Paint;
            KeyDown += Form1_KeyDown;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                this.Invalidate();
            }
            if(e.KeyCode == Keys.C)
            {
                _path.Dispose();
                _path = new GraphicsPath();
                _points.Clear();
                this.Invalidate();
            }
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            _points.Add(new Point(e.X, e.Y));
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            _path.StartFigure();
            for(int i = 0; i<_points.Count-1;i++)
            {
                _path.AddLine(_points[i], _points[i + 1]);
            }
            e.Graphics.DrawPath(new Pen(Color.Black, 3), _path);
        }
    }
}
