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

namespace _3_controls_
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //Button5.Height = 50;
            //Button5.Click += Button5_Click;
        }

        private void Button5_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Hello from Button5");
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            Button1.Content = "Push me";
        }
        private void Click_Button2(object sender, RoutedEventArgs e)
        {
            Button1.Content = "ABC";
        }
        private void Click_Button3(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Hello from Button3");
        }
        int i = 0;
        private void RepeatButton1_Click(object sender, RoutedEventArgs e)
        {
            i++;
            RepeatButton1.Content = i;

        }
        private void Check_CheckBox1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Checked1");
        }
        private void Uncheck_CheckBox1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Unchecked1");
        }
    }
}
