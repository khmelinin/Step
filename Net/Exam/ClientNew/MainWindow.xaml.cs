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

namespace Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<string> coordinates;
        List<string> game_coordinates;
        int ship_parts = 0;
        int enemy_ship_parts = 2;
        const int max_ship_parts = 20;
        bool is_battle = false;

        TcpListener listener;
        TcpClient client;
        //StreamReader reader;
        StreamWriter writer;
        List<Button> buttons;
        Task receiveTask;
        CancellationTokenSource source;

        public MainWindow()
        {
            InitializeComponent();
            game_coordinates = new List<string>();
            coordinates = new List<string>() { 
                "A0", "A1", "A2", "A3", "A4", "A5" , "A6", "A7", "A8", "A9",
                "B0", "B1", "B2", "B3", "B4", "B5" , "B6", "B7", "B8", "B9",
                "C0", "C1", "C2", "C3", "C4", "C5" , "C6", "C7", "C8", "C9",
                "D0", "D1", "D2", "D3", "D4", "D5" , "D6", "D7", "D8", "D9",
                "E0", "E1", "E2", "E3", "E4", "E5" , "E6", "E7", "E8", "E9",
                "F0", "F1", "F2", "F3", "F4", "F5" , "F6", "F7", "F8", "F9",
                "G0", "G1", "G2", "G3", "G4", "G5" , "G6", "G7", "G8", "G9",
                "H0", "H1", "H2", "H3", "H4", "H5" , "H6", "H7", "H8", "H9",
                "I0", "I1", "I2", "I3", "I4", "I5" , "I6", "I7", "I8", "I9",
                "J0", "J1", "J2", "J3", "J4", "J5" , "J6", "J7", "J8", "J9",
            };
            buttons = new List<Button>() {
                btn_a0, btn_a1, btn_a2, btn_a3, btn_a4, btn_a5, btn_a6, btn_a7, btn_a8, btn_a9,
                btn_b0, btn_b1, btn_b2, btn_b3, btn_b4, btn_b5, btn_b6, btn_b7, btn_b8, btn_b9,
                btn_c0, btn_c1, btn_c2, btn_c3, btn_c4, btn_c5, btn_c6, btn_c7, btn_c8, btn_c9,
                btn_d0, btn_d1, btn_d2, btn_d3, btn_d4, btn_d5, btn_d6, btn_d7, btn_d8, btn_d9,
                btn_e0, btn_e1, btn_e2, btn_e3, btn_e4, btn_e5, btn_e6, btn_e7, btn_e8, btn_e9,
                btn_f0, btn_f1, btn_f2, btn_f3, btn_f4, btn_f5, btn_f6, btn_f7, btn_f8, btn_f9,
                btn_g0, btn_g1, btn_g2, btn_g3, btn_g4, btn_g5, btn_g6, btn_g7, btn_g8, btn_g9,
                btn_h0, btn_h1, btn_h2, btn_h3, btn_h4, btn_h5, btn_h6, btn_h7, btn_h8, btn_h9,
                btn_i0, btn_i1, btn_i2, btn_i3, btn_i4, btn_i5, btn_i6, btn_i7, btn_i8, btn_i9,
                btn_j0, btn_j1, btn_j2, btn_j3, btn_j4, btn_j5, btn_j6, btn_j7, btn_j8, btn_j9 
            };
            //menuReady.Background = Brushes.White;
            //menuReady.IsEnabled = false;
            for (int i = 0; i < buttons.Count; i++)
            {
                buttons[i].Content = coordinates[i];
                buttons[i].Background = Brushes.White;
            }
        }
        private void NewGame()
        {
            foreach (var item in buttons)
            {
                item.IsEnabled = true;
            }
                ship_parts = 0;
                enemy_ship_parts = 2;
                is_battle = false;
                game_coordinates = new List<string>();
                coordinates = new List<string>() {
                "A0", "A1", "A2", "A3", "A4", "A5" , "A6", "A7", "A8", "A9",
                "B0", "B1", "B2", "B3", "B4", "B5" , "B6", "B7", "B8", "B9",
                "C0", "C1", "C2", "C3", "C4", "C5" , "C6", "C7", "C8", "C9",
                "D0", "D1", "D2", "D3", "D4", "D5" , "D6", "D7", "D8", "D9",
                "E0", "E1", "E2", "E3", "E4", "E5" , "E6", "E7", "E8", "E9",
                "F0", "F1", "F2", "F3", "F4", "F5" , "F6", "F7", "F8", "F9",
                "G0", "G1", "G2", "G3", "G4", "G5" , "G6", "G7", "G8", "G9",
                "H0", "H1", "H2", "H3", "H4", "H5" , "H6", "H7", "H8", "H9",
                "I0", "I1", "I2", "I3", "I4", "I5" , "I6", "I7", "I8", "I9",
                "J0", "J1", "J2", "J3", "J4", "J5" , "J6", "J7", "J8", "J9",
            };
                buttons = new List<Button>() {
                btn_a0, btn_a1, btn_a2, btn_a3, btn_a4, btn_a5, btn_a6, btn_a7, btn_a8, btn_a9,
                btn_b0, btn_b1, btn_b2, btn_b3, btn_b4, btn_b5, btn_b6, btn_b7, btn_b8, btn_b9,
                btn_c0, btn_c1, btn_c2, btn_c3, btn_c4, btn_c5, btn_c6, btn_c7, btn_c8, btn_c9,
                btn_d0, btn_d1, btn_d2, btn_d3, btn_d4, btn_d5, btn_d6, btn_d7, btn_d8, btn_d9,
                btn_e0, btn_e1, btn_e2, btn_e3, btn_e4, btn_e5, btn_e6, btn_e7, btn_e8, btn_e9,
                btn_f0, btn_f1, btn_f2, btn_f3, btn_f4, btn_f5, btn_f6, btn_f7, btn_f8, btn_f9,
                btn_g0, btn_g1, btn_g2, btn_g3, btn_g4, btn_g5, btn_g6, btn_g7, btn_g8, btn_g9,
                btn_h0, btn_h1, btn_h2, btn_h3, btn_h4, btn_h5, btn_h6, btn_h7, btn_h8, btn_h9,
                btn_i0, btn_i1, btn_i2, btn_i3, btn_i4, btn_i5, btn_i6, btn_i7, btn_i8, btn_i9,
                btn_j0, btn_j1, btn_j2, btn_j3, btn_j4, btn_j5, btn_j6, btn_j7, btn_j8, btn_j9
            };
                //menuReady.Background = Brushes.White;
                //menuReady.IsEnabled = false;
                for (int i = 0; i < buttons.Count; i++)
                {
                    buttons[i].Content = coordinates[i];
                    buttons[i].Background = Brushes.White;
                }
        }
       
        int[] gameboard = new int[100];

        private async void MenuCreate_Click(object sender, RoutedEventArgs e)
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

            //
            is_battle = false;
        }
        //private async void MenuDisconnect_Click(object sender, RoutedEventArgs e)
        //{
        //    //menuNew.IsEnabled = true;
        //    //menuStart.IsEnabled = true;
        //    Disconnect();
        //}

        private async void MenuConnect_Click(object sender, RoutedEventArgs e)
        {
            //menuNew.IsEnabled = false;
            //menuStart.IsEnabled = false;
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

            //
            is_battle = false;
        }

        private void Receved(CancellationToken token)
        {
            while (true)
            {
                if (token.IsCancellationRequested)
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
                    case PackageType.New:
                        EnableButtons(true);
                        App.Current.Dispatcher.Invoke(() =>
                        {
                            NewGame();
                        });
                        //EnableButtons(true);
                        break;
                    case PackageType.Start:
                        App.Current.Dispatcher.Invoke(() =>
                        {
                            foreach (var item in buttons)
                            {
                                item.Background = Brushes.White;
                            }
                            ClearButton();
                            hp_bar.Maximum = ship_parts;
                            hp_bar.Width = ship_parts * 10;
                            hp_bar.Value = ship_parts;
                            enemy_ship_parts = Convert.ToInt32(ss[2]);
                            EnableButtons(ss[1] == "1");
                            is_battle = true;
                        });
                        break;
                    case PackageType.Turn:
                        App.Current.Dispatcher.Invoke(() =>
                        {
                            //if ((buttons[Convert.ToInt32(ss[1])].Content as string).Contains("X"))
                            enemy_ship_parts = Convert.ToInt32(ss[2]);
                            hp_bar.Value = ship_parts;
                            if (game_coordinates[Convert.ToInt32(ss[1])].Contains("X"))
                            {
                                ship_parts -= 1;
                                //MessageBox.Show("You have been hitted");
                                
                            }
                            //buttons[Convert.ToInt32(ss[1])].Content = "0";
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
                        App.Current.Dispatcher.Invoke(() =>
                        {
                            EnableButtons(true);
                            hp_bar.Value = ship_parts;
                        });
                        break;
                    default:
                        break;
                }
            }

        }

        private async void MenuStart_Click(object sender, RoutedEventArgs e)
        {
            var rnd = new Random((int)DateTime.Now.Ticks);
            var start = rnd.Next() % 2;
            var p = $"{Convert.ToInt32(PackageType.Start)};{start};{ship_parts}";
            foreach (var item in buttons)
            {
                item.Background = Brushes.White;
            }
            hp_bar.Maximum = ship_parts;
            hp_bar.Width = ship_parts * 10;
            hp_bar.Value = ship_parts;
            await writer.WriteAsync(p);


            ClearButton();
            EnableButtons(start == 0);

            //

            is_battle = true;
        }

        private async void MenuNew_Click(object sender, RoutedEventArgs e)
        {
            NewGame();
            var p = $"{Convert.ToInt32(PackageType.New)};";
            await writer.WriteAsync(p);
            

        }

        private void ClearButton()
        {
            for (int i = 0; i < gameboard.Length; i++)
            {
                gameboard[i] = 0;
            }

            foreach (var item in buttons)
            {
                App.Current.Dispatcher.Invoke(() =>
                {
                    game_coordinates.Add(item.Content as string);
                    item.Content = null;
                });
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
            if (!is_battle)
            {
                var btn = sender as Button;
                var index = buttons.IndexOf(btn);
                if (!(btn.Content as string).Contains("X") && ship_parts < max_ship_parts)
                {
                    btn.Content += "X";
                    btn.Background = Brushes.Blue;
                    ship_parts += 1;
                    //gameboard[index] = 1;
                }
            }
            else
            {
                var btn = sender as Button;
                btn.Background = Brushes.Gray;
                var index = buttons.IndexOf(btn);
                var p = $"{Convert.ToInt32(PackageType.Turn)};{index};{ship_parts}";
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
            

        }
        //private void Disconnect()
        //{
        //    writer.Close();
        //    writer.Dispose();
        //    source.Cancel();
        //    source.Dispose();
        //    client.Close();
        //    client.Dispose();
        //}

        private GameResult CheckGame()
        {
            if (enemy_ship_parts<=0)
            {
                return GameResult.win;
            }

            return GameResult.none;
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
