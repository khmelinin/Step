using System;
using System.Collections.Generic;
using System.Linq;
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

namespace ServerWPF
{
    public class ClientObject
    {
        //protected internal string Id { get; private set; }
        protected internal string Id { get => userId; set => userId = value; }
        protected internal NetworkStream Stream { get; private set; }
        

        string userName;
        string userId = Guid.NewGuid().ToString();
        TcpClient client;
        RoomObject room;

        public string UserName { get => userName; }

        public ClientObject(TcpClient tcpClient, RoomObject serverObject)
        {
            //Id = Guid.NewGuid().ToString();
            client = tcpClient;
            room = serverObject;
            serverObject.AddConnection(this);
        }

        public void Process()
        {
            try
            {
                Stream = client.GetStream();

                string message = GetMessage();
                userName = message;
                message = userName + $" entered the chat";

                //room.BroadcastMessage(message, this.Id);
                room.BroadcastMessage(message, userId);
                //Console.WriteLine(message);

                while (true)
                {
                    try
                    {
                        message = GetMessage();
                        message = String.Format("{0}: {1}", userName, message);
                        //Console.WriteLine(message);
                        //room.BroadcastMessage(message, this.Id);
                        room.BroadcastMessage(message, userId);
                    }
                    catch
                    {
                        message = String.Format("{0}: left the chat", userName);
                        //Console.WriteLine(message);
                        //room.BroadcastMessage(message, this.Id);
                        room.BroadcastMessage(message, userId);
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message+$"\r\nRoomId = {room.RoomId}");
            }
            finally
            {

                room.RemoveConnection(this.Id);
                Close();
            }
        }

        private string GetMessage()
        {
            byte[] data = new byte[64]; 
            StringBuilder builder = new StringBuilder();
            int bytes = 0;
            do
            {
                bytes = Stream.Read(data, 0, data.Length);
                builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
            }
            while (Stream.DataAvailable);

            return builder.ToString();
        }

        protected internal void Close()
        {
            if (Stream != null)
                Stream.Close();
            if (client != null)
                client.Close();
        }




        public void CloseAndRemove()
        {
            room.RemoveConnection(this.Id);
            Close();
        }
    }
}
