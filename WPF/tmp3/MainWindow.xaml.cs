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

namespace tmp3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Line> lines = new List<Line>();
        Brush bruh = Brushes.Black;
        bool is_tmp = false;
        double thickness = 1;
        
        public MainWindow()
        {
            InitializeComponent();
            Point one = new Point(100, 100);
            Point two = new Point(200, 100);
            this.MouseLeftButtonDown += MainWindow_MouseLeftButtonDown;
            this.MouseRightButtonDown += MainWindow_MouseRightButtonDown;
            //this.MouseMove += MainWindow_MouseMove;
            
        }

        private void MainWindow_MouseMove(object sender, MouseEventArgs e)
        {
            
        }

        private void MainWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            
            if (is_tmp==false)
            {
                lines.Add(new Line());
                lines[lines.Count - 1].X1 = e.GetPosition(Stack1).X;
                lines[lines.Count - 1].Y1 = e.GetPosition(Stack1).Y;
                lines[lines.Count - 1].Stroke = bruh;
                is_tmp = true;
            }
            else
            {
                lines[lines.Count - 1].X2 = e.GetPosition(Stack1).X;
                lines[lines.Count - 1].Y2 = e.GetPosition(Stack1).Y;
                is_tmp = false;
                lines[lines.Count - 1].StrokeThickness = thickness;
                Stack1.Children.Add(lines[lines.Count - 1]);
            }
        }
        private void MainWindow_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch(colorsComboBox.SelectedIndex)
            {
                case 0:
                    bruh = Brushes.Red;
                    break;
                case 1:
                    bruh = Brushes.Green;
                    break;
                case 2:
                    bruh = Brushes.Blue;
                    break;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Stack1.Children.Count > 0)
            {
                Stack1.Children.RemoveAt(Stack1.Children.Count-1);
            }
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            thickness = (sender as Slider).Value;
        }
    }
}
