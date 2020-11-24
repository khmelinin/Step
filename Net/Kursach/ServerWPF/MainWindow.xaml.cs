using System;
using System.Collections.Generic;
using System.Linq;
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

namespace ServerWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        RoomObject currentRoom;
        List<RoomObject> rooms;
        List<Thread> listenThreads;
        public MainWindow()
        {
            InitializeComponent();
            int default_room = 8888;
            rooms = new List<RoomObject>();
            listenThreads = new List<Thread>();
            menuRooms.Items.Add(new MenuItem() { Header = $"{default_room}" });
            
            try
            {
                //rooms.Add(new RoomObject(room_port));
                var tmp = new RoomObject(default_room);
                currentRoom = tmp;
                rooms.Add(tmp);
                listenThreads.Add(new Thread(new ThreadStart(rooms[rooms.Count - 1].Listen)));
                listenThreads[listenThreads.Count - 1].Start();
            }
            catch (Exception ex)
            {
                rooms[rooms.Count - 1].Disconnect();
                Console.WriteLine(ex.Message);
            }
        }

        private void menuAddRoom_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            txtBlockChatWindow.Text = $"Online users in chat = {currentRoom.Clients.Count}\n";
            for (int i = 0; i < currentRoom.Clients.Count; i++)
            {
                txtBlockChatWindow.Text += ("\n" + currentRoom.Clients[i].UserName + "   |   " + currentRoom.Clients[i].Id);
            }
        }

        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            var command = txtChat.Text.Split(' ');
            switch (command[0])
            {
                case "/ban":
                    currentRoom.BlacklistAdd(command[1]);
                    break;
                case "/unban":
                    currentRoom.BlacklistRemove(command[1]);
                    break;
                case "/banlist":
                    currentRoom.BlacklistList();
                    break;
                default:
                    break;
            }
            txtChat.Text = string.Empty;
        }

        private void menuCommands_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(
                "Ban users: /ban userId\n" +
                "Unban users: /unban userId\n");
        }
    }
}
