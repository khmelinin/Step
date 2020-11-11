using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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

namespace WebWpf
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

        private async void btnGet_Click(object sender, RoutedEventArgs e)
        {
            var request = WebRequest.CreateHttp(txtURL.Text);
            var response = (HttpWebResponse)(await request.GetResponseAsync());
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                var s = await reader.ReadToEndAsync();
                App.Current.Dispatcher.Invoke(() =>
                 {
                     txtResult.Text = s;
                 });
            }

        }
    }
}
