using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _6
{
    /*
     <Path.Data>
                <GeometryGroup FillRule="EvenOdd">
                    <LineGeometry StartPoint="30,30" EndPoint="430,330"/>
                    <RectangleGeometry Rect="30,30,400,300"/>
                    <EllipseGeometry RadiusX="60" RadiusY="60" Center="300,300"/>
                </GeometryGroup>
     */
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    }
}
