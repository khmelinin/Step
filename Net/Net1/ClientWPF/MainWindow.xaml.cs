using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
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

namespace ClientWPF
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

        private void BtnSend_Click(object sender, RoutedEventArgs e)
        {
            btnSend.IsEnabled = false;
            Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 10000);
            //await client.ConnectAsync(ep);
            //client.Connect(ep); for VS 2015
            client.BeginConnect(ep, ConnectCallBack, client);

        }

        private async void ConnectCallBack(IAsyncResult ar)
        {
            var client = ar.AsyncState as Socket;
            client.EndConnect(ar);
            string text = await App.Current.Dispatcher.InvokeAsync(() => { return this.txtSend.Text; });
            var so = new StateObject() { socket = client, buffer = Encoding.Unicode.GetBytes(text) };
            client.BeginSend(so.buffer, 0, so.buffer.Length, SocketFlags.None, SendCallBack, so);
        }

        private void SendCallBack(IAsyncResult ar)
        {
            var so = ar.AsyncState as StateObject;
            var client = so.socket;
            client.EndSend(ar);
            so.buffer = new byte[1024];
            client.BeginReceive(so.buffer, 0, so.buffer.Length, SocketFlags.None, ReceiveCallBack, so);
        }

        private async void ReceiveCallBack(IAsyncResult ar)
        {
            var so = ar.AsyncState as StateObject;
            var client = so.socket;
            var amount = client.EndReceive(ar);
            string text = Encoding.Unicode.GetString(so.buffer, 0, amount);
            client.Shutdown(SocketShutdown.Both);
            client.Close();
            client.Dispose();
            await App.Current.Dispatcher.InvokeAsync(()=>
            {
                txtReceive.Text = text;
                btnSend.IsEnabled = true;
            });
        }
    }
    class StateObject
    {
        public Socket socket { get; set; }
        public byte[] buffer { get; set; }
    }
}
