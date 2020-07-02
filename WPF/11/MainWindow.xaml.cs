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

namespace _11
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool ok = false;
        public class Text_text_button:FrameworkElement
        {
            
            public static readonly DependencyObject Text_text_button1;
            static Text_text_button()
            {
                //Text_text_button1 = DependencyProperty.Register();
            }
        }
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_pink(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("ok?");
        }

        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            if (ok == false)
            {
                pinkButton.HorizontalAlignment = HorizontalAlignment.Left;
                ok = true;
            }

            else
            {
                pinkButton.HorizontalAlignment = HorizontalAlignment.Right;
                ok = false;
            }
        }
    }
}
