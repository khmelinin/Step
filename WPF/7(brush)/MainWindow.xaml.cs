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

namespace _7_brush_
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool clicked = false;
        public MainWindow()
        {
            InitializeComponent();
            //textBlock1.Background = new SolidColorBrush(Color.FromRgb(0, 0, 0));
        }

        /*
         <Style x:Key="Style3" BasedOn="{StaticResource Style2}">
            <Setter Property="Control.Background" Value="Red"/>
            <EventSetter Event="Click" Handler="Button_Click1"/>
        </Style>
         */

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            if (clicked == false)
            {
                button1.Width = 140;
                button1.Height = 140;
                clicked = true;
            }
            else
            {
                button1.Width = 100;
                button1.Height = 100;
                clicked = false;
            }
        }
    }
}
