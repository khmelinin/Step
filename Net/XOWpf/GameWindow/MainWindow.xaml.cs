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

namespace GameWindow
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TcpListener listener;
        TcpClient client;
        StreamReader reader;
        StreamWriter writer;
        List<Button> buttons;
        Task receiveTask;
        CancellationTokenSource source;
        int[] gameboard = new int[9];
        public MainWindow()
        {
            InitializeComponent();
            buttons = new List<Button>() { btn_0, btn_1, btn_2, btn_3, btn_4, btn_5, btn_6, btn_7, btn_8 };
        }

        private async void MenuItemCreate_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new CreateServerDialog();
            var result = dlg.ShowDialog();
            if (result == null || result.Value == false)
            {
                return;
            }
            var localEP = new IPEndPoint(dlg.IPAddress, dlg.Port);
            listener = new TcpListener(localEP);
            listener.Start();
            client = await listener.AcceptTcpClientAsync();
            CreateReceiveTask();
            //listener.Stop();
        }

        private async void MenuItemConnect_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new CreateServerDialog() { Title = "Connect to server" };
            var result = dlg.ShowDialog();
            if (result == null || result.Value == false)
            {
                return;
            }
            var tcpClient = new TcpClient(AddressFamily.InterNetwork);
            await tcpClient.ConnectAsync(dlg.IPAddress, dlg.Port);
            if (tcpClient.Connected)
            {
                client = tcpClient;
                CreateReceiveTask();
            }
        }

        private void Receved(CancellationToken token)
        {
            while (true)
            {
                if(token.IsCancellationRequested)
                {
                    break;
                }
                var buffer = new byte[1024];
                var amount = client.Client.Receive(buffer);//

                //var amount = reader.ReadAsync(buffer, 0, buffer.Length).Result; //
                var s = Encoding.UTF8.GetString(buffer, 0, amount);
                var ss = s.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                var pt = (PackageType)Convert.ToInt32(ss[0]);
                switch (pt)
                {
                    case PackageType.Start:
                        ClearButton();
                        EnableButtons(ss[1] == "1");
                        break;
                    case PackageType.Turn:
                        App.Current.Dispatcher.Invoke(() =>
                        {
                            buttons[Convert.ToInt32(ss[1])].Content = "0";
                        });
                        break;
                    case PackageType.Check:
                        {
                            var gr = (GameResult)Convert.ToInt32(ss[1]);
                            if (gr == GameResult.lose)
                            {
                                MessageBox.Show("You lose!!");
                                return;
                            }
                        }
                        break;
                    case PackageType.Next:
                        EnableButtons(true);
                        break;
                    default:
                        break;
                }
            }
            
        }

        private async void MenuItemStart_Click(object sender, RoutedEventArgs e)
        {
            var rnd = new Random((int)DateTime.Now.Ticks);
            var start = rnd.Next() % 2;
            var p = $"{Convert.ToInt32(PackageType.Start)};{start}";
            
                await writer.WriteAsync(p);
            

            ClearButton();
            EnableButtons(start == 0);
        }

        private void ClearButton()
        {
            for (int i = 0; i < gameboard.Length; i++)
            {
                gameboard[i] = 0;
            }

            foreach (var item in buttons)
            {
                App.Current.Dispatcher.Invoke(() => { item.Content = null; });
            }
        }

        private void EnableButtons(bool enable)
        {
            foreach (var item in buttons)
            {
                App.Current.Dispatcher.Invoke(() => { item.IsEnabled = enable && item.Content == null; });
            }
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            var index = buttons.IndexOf(btn);
            btn.Content = "X";
            gameboard[index] = 1;
            var p = $"{Convert.ToInt32(PackageType.Turn)};{index}";
            await writer.WriteAsync(p);
            var gr = CheckGame();
            p = $"{Convert.ToInt32(PackageType.Check)};{Convert.ToInt32(gr == GameResult.win ? GameResult.lose : gr)}";
            await writer.WriteAsync(p);
            if (gr == GameResult.win)
            {
                MessageBox.Show("You win!!");
                return;
            }
            else if (gr == GameResult.end)
            {
                MessageBox.Show("Game end!!");
            }

            p = $"{Convert.ToInt32(PackageType.Next)};";
            await writer.WriteAsync(p);
            EnableButtons(false);

        }

        private GameResult CheckGame()
        {
            if ((gameboard[0] == 1 && gameboard[1] == 1 && gameboard[2] == 1)
                || (gameboard[3] == 1 && gameboard[4] == 1 && gameboard[5] == 1)
                || (gameboard[6] == 1 && gameboard[7] == 1 && gameboard[8] == 1)
                || (gameboard[0] == 1 && gameboard[3] == 1 && gameboard[6] == 1)
                || (gameboard[1] == 1 && gameboard[4] == 1 && gameboard[7] == 1)
                || (gameboard[2] == 1 && gameboard[5] == 1 && gameboard[8] == 1)
                || (gameboard[0] == 1 && gameboard[4] == 1 && gameboard[8] == 1)
                || (gameboard[2] == 1 && gameboard[4] == 1 && gameboard[6] == 1))
            {
                return GameResult.win;
            }

            var c = (from i in gameboard where i == 0 select i).Count();
            return c == 0 ? GameResult.end : GameResult.none;
        }

        private void CreateReceiveTask()
        {
            var ns = client.GetStream();
            //reader = new StreamReader(ns);
            writer = new StreamWriter(ns);
            writer.AutoFlush = true;
            source = new CancellationTokenSource();
            receiveTask = Task.Run(() => { Receved(source.Token); });
        }
    }
}