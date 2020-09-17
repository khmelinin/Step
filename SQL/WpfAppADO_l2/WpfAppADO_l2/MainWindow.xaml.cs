using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace WpfAppADO_l2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private SqlConnection sqlConnection = null;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            sqlConnection = ConnectDialog.ShowConnectDialog();
        }

        private async void BtnReader_Click(object sender, RoutedEventArgs e)
        {
            var cmd = sqlConnection.CreateCommand();
            cmd.CommandText = txtQuery.Text;
            var reader = await cmd.ExecuteReaderAsync();
            bool next = false;
            List<QueryResult> results = new List<QueryResult>();
            do
            {
                List<string> result = new List<string>();
                while (await reader.ReadAsync())
                {
                    StringBuilder row = new StringBuilder();
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        if (reader.IsDBNull(i))
                        {
                            row.Append("null;");
                        }
                        else
                        {
                            row.Append(reader.GetValue(i).ToString());
                        }
                    }

                    result.Add(row.ToString());
                }

                results.Add(new QueryResult() { DisplayName = "Result", Value = result });
                next = await reader.NextResultAsync();
            }
            while (next);

            DataContext = results;
        }

        private void BtnScalar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnNoQuery_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
