using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace tmp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void buttonCenter_Click(object sender, RoutedEventArgs e)
        {
            rectCenterRotate.Angle += 20;
            rectCenterRotate1.Angle += 20;
        }
        private void buttonLeft_Click(object sender, RoutedEventArgs e)
        {
            rectLeftRotate.Angle += 20;
        }
        private void buttonRight_Click(object sender, RoutedEventArgs e)
        {
            rectRightRotate.Angle += 20;
        }
    }
}
