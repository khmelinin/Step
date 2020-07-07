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

namespace tmp2
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

        private void Mouse_Enter(object sender, MouseEventArgs e)
        {
            if (statusBar.Items.Count > 0)
                statusBar.Items.Clear();
            statusBar.Items.Add(((Button)sender).Content + " button");
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.Background = ((MenuItem)sender).Background;
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Vasya Pupkin\r\n+99999999\r\nKyiv","Developer info");
        }

        private void MenuItem_MouseEnter(object sender, MouseEventArgs e)
        {
            if (statusBar.Items.Count > 0)
                statusBar.Items.Clear();
            string tmp = ((MenuItem)sender).Header.ToString() + " menu_item";
            statusBar.Items.Add(tmp);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            this.Background = ((Button)sender).Background;
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {

        }
    }
}
