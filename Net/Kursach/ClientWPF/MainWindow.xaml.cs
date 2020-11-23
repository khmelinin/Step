using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
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

namespace ClientWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IPAddress ip;
        private int port = 8888;
        TcpClient client;
        NetworkStream stream;

        List<Contact> contacts;

        public MainWindow()
        {
            InitializeComponent();
            contacts = new List<Contact>();

            // disabling
            txtChat.IsEnabled = false;
            // disabling
        }

        private void menuConnect_Click(object sender, RoutedEventArgs e)
        {

            var dlg = new ConnectionWindow() { Title = "Connect to server" };
            var result = dlg.ShowDialog();
            if (result == null || result.Value == false)
            {
                return;
            }

            /*
            var tcpClient = new TcpClient(AddressFamily.InterNetwork);
            await tcpClient.ConnectAsync(dlg.IPAddress, dlg.Port);
            if (tcpClient.Connected)
            {
                client = tcpClient;
            }
            */

            ////////////////////////////////////////////// 

            client = new TcpClient();
            try
            {
                // enabling
                txtChat.IsEnabled = true;
                txtChat.Text = string.Empty;
                // enabling 

                ip = dlg.IPAddress;
                port = dlg.Port;
                client.Connect(ip.ToString(), port); //client connect
                stream = client.GetStream();

                //string message = userName;
                string message = txtUsername.Text;
                byte[] data = Encoding.Unicode.GetBytes(message);
                stream.Write(data, 0, data.Length);

                Thread receiveThread = new Thread(new ThreadStart(ReceiveMessage));
                receiveThread.Start();
                //SendMessage();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void SendMessage()
        {

            //while (true)
            //{
                if (txtChat.IsEnabled)
                {
                    string message = txtChat.Text;
                    byte[] data = Encoding.Unicode.GetBytes(message);
                    stream.Write(data, 0, data.Length);
                }
            //}
        }
        
        async void ReceiveMessage()
        {
            while (true)
            {
                try
                {
                    byte[] data = new byte[64];
                    StringBuilder builder = new StringBuilder();
                    int bytes = 0;
                    do
                    {
                        bytes = await stream.ReadAsync(data, 0, data.Length);
                        builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                    }
                    while (stream.DataAvailable);

                    string message = builder.ToString();
                    App.Current.Dispatcher.Invoke(() => {
                        txtBlockChatWindow.Text += ("\n" + message);
                    });
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message + " Connection interrupted!");
                    Disconnect();
                }
            }
        }

        void Disconnect()
        {
            if (stream != null)
                stream.Close();
            if (client != null)
                client.Close();
            Environment.Exit(0);
        }

        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            SendMessage();
            txtChat.Text = string.Empty;
        }

        private void txtChat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                SendMessage();
                txtChat.Text = string.Empty;
            }
        }

        private void menuAddContact_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new AddContactWindow() { Title = "Add contact" };
            var result = dlg.ShowDialog();
            if (result == null || result.Value == false)
            {
                return;
            }
            var tmp = new MenuItem() { Header = dlg.userName + " " + dlg.userId };

            menuContacts.Items.Add(tmp);
            contacts.Add(new Contact(dlg.userId, dlg.userName));
            comboboxContacts.Items.Add(dlg.userName);
        }
        private void menuAddGroup_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
    