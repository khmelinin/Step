using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using WpfAppADO_l3.Models;

namespace WpfAppADO_l3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private Warehouse warehouse;
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        public ObservableCollection<Article> Articles { get; private set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void CreateConnection_Click(object sender, RoutedEventArgs e)
        {
            var connection = ConnectDialog.ShowConnectDialog();
            if(connection != null)
            {
                warehouse = new Warehouse(connection);
            }
        }

        private void LoadData_Click_1(object sender, RoutedEventArgs e)
        {
            warehouse.LoadData();
            Articles = warehouse.Articles;
            var handler = PropertyChanged;
            if(handler!=null)
            {
                handler.Invoke(this, new PropertyChangedEventArgs("Articles"));
            }
        }
    }
}
