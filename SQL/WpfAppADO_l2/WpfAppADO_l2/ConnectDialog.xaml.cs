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
using System.Windows.Shapes;

namespace WpfAppADO_l2
{
    /// <summary>
    /// Interaction logic for ConnectDialog.xaml
    /// </summary>
    public partial class ConnectDialog : Window
    {
        public ConnectDialog()
        {
            InitializeComponent();
        }

        public static SqlConnection ShowConnectDialog()
        {
            var dlg = new ConnectDialog();
            var result = dlg.ShowDialog();
            return result.HasValue & result.Value ? dlg.Connection : null;
        }

        public SqlConnection Connection { get; private set; }

        private async void Connect_Click(object sender, RoutedEventArgs e)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            SqlConnection sqlConnection = null;
            if (string.IsNullOrWhiteSpace(txtServerName.Text))
            {
                return;
            }

            builder.DataSource = txtServerName.Text;
            if (string.IsNullOrWhiteSpace(txtInitialCatalog.Text))
            {
                return;
            }

            builder.InitialCatalog = txtInitialCatalog.Text;
            if (rbWindows.IsChecked.HasValue && rbWindows.IsChecked.Value)
            {
                builder.IntegratedSecurity = true;
                sqlConnection = new SqlConnection(builder.ConnectionString);
            }
            else if (rbSqlServer.IsChecked.HasValue && rbSqlServer.IsChecked.Value)
            {
                var sqlCredential = new SqlCredential(txtLogin.Text, txtPassword.SecurePassword);
                sqlConnection = new SqlConnection(builder.ConnectionString, sqlCredential);
            }

            try
            {
                await sqlConnection.OpenAsync();
                Connection = sqlConnection;
                DialogResult = true;
                Close();
            }
            catch (SqlException se)
            {
                MessageBox.Show(se.Message);
            }
            catch(InvalidOperationException ioe)
            {
                MessageBox.Show(ioe.Message);
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
