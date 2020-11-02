using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ServerConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            CancellationTokenSource source = new CancellationTokenSource();
            var task = Task.Run(() => { ServerMethod(source.Token); });
            Console.ReadLine();
            source.Cancel();
            task.Wait();
        }

        static void ServerMethod(CancellationToken token)
        {
            using (Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
            {
                try {
                    IPEndPoint ipep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 10000);
                    server.Bind(ipep);
                    server.Listen(10);
                    while (true)
                    {
                        var ar = server.BeginAccept(AcceptCallBack, server);
                        if (token.IsCancellationRequested)
                        {
                            break;
                        }
                    }
                    server.Shutdown(SocketShutdown.Both);
                    server.Close();
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

        }
        static void AcceptCallBack(IAsyncResult ar)
        {
            var server = ar.AsyncState as Socket;
            if (server == null)
            {
                throw new ArgumentNullException();
            }
            var client = server.EndAccept(ar);
            var so = new StateObject() { socket = client, buffer = new byte[1024] };
            client.BeginReceive(so.buffer,0,so.buffer.Length,SocketFlags.None, ReceiveCallback, so);

            //var @as = new ArraySegment<byte>(so.buffer);
            //await client.ReceiveAsync(@as);

        }

        private static void ReceiveCallback(IAsyncResult ar)
        {
            var so = ar.AsyncState as StateObject;
            if (so == null)
            {
                throw new ArgumentNullException();
            }

            var client = so.socket;
            var amount = client.EndReceive(ar);

            string res = Encoding.Unicode.GetString(so.buffer, 0, amount);
            res = res.ToUpper();
            so.buffer = Encoding.Unicode.GetBytes(res);
            client.BeginSend(so.buffer, 0, so.buffer.Length, SocketFlags.None, SendCallback, so);
        }

        private static void SendCallback(IAsyncResult ar)
        {
            var so = ar.AsyncState as StateObject;
            if (so == null)
            {
                throw new ArgumentNullException();
            }

            var client = so.socket;
            client.EndSend(ar);
            client.Shutdown(SocketShutdown.Both);
            client.Close();
            client.Dispose();
        }
    }
}
