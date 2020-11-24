using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
    class Program
    {
        static List<RoomObject> rooms;
        static List<Thread> listenThreads;
        static void Main(string[] args)
        {
            rooms = new List<RoomObject>();
            listenThreads = new List<Thread>();
            //while (true)
            //{
                //var tmp = Console.ReadLine();
                //var room_port = Convert.ToInt32(tmp.Split(' ')[1]);
                //if (tmp.Contains("add_room"))
                //{
                    try
                    {
                        //rooms.Add(new RoomObject(room_port));
                        rooms.Add(new RoomObject(8888));
                        listenThreads.Add(new Thread(new ThreadStart(rooms[rooms.Count - 1].Listen)));
                        listenThreads[listenThreads.Count - 1].Start();
                    }
                    catch (Exception ex)
                    {
                        rooms[rooms.Count - 1].Disconnect();
                        Console.WriteLine(ex.Message);
                    }
                //}
            //}
        }
    }
}
