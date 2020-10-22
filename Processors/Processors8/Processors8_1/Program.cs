using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Processors8_1
{
    class Program
    {
        static AutoResetEvent s12 = null;
        static AutoResetEvent s13 = null;
        static AutoResetEvent s21 = null;
        static AutoResetEvent s31 = null;
        static ManualResetEvent exit = null;
        static object cs = new object();
        static int num1 = 0;
        static int num2 = 0;
        static void Main(string[] args)
        {
            s12 = new AutoResetEvent(false);
            s13 = new AutoResetEvent(false);
            s21 = new AutoResetEvent(true);
            s31 = new AutoResetEvent(true);
            exit = new ManualResetEvent(false);
            int n = 10;

            var t1 = new Thread(First);
            t1.Start(n);
            var t2 = new Thread(Second);
            t2.Start();
            var t3 = new Thread(Third);
            t3.Start();

            t1.Join();
            t2.Join();
            t3.Join();

            s12.Close();
            s13.Close();
            s21.Close();
            s31.Close();
            exit.Close();
        }

        static void First(object state)
        {
            using (var writer = new StreamWriter("first.txt"))
            {
                var wh = new WaitHandle[] { s21, s31 };
                var rnd = new Random();
                int n = (int)state;
                for (int i = 0; i < n; i++)
                {
                    WaitHandle.WaitAll(wh);
                    num1 = rnd.Next(0, 100);
                    num2 = rnd.Next(0, 100);
                    s12.Set();
                    s13.Set();
                    lock (cs)
                    {
                        writer.WriteLine($"{num1} - {num2}");
                    }
                }

                exit.Set();

            }
        }

        static void Second()
        {
            using (var writer = new StreamWriter("second.txt"))
            {
                var wh = new WaitHandle[] { s12, exit };
                while (true)
                {
                    int res = WaitHandle.WaitAny(wh);
                    if (res == 1)
                    {
                        break;
                    }

                    int s = 0;
                    lock (cs)
                    {
                        s = num1 + num2;
                    }

                    s21.Set();

                    writer.WriteLine(s);
                }
            }
        }

        static void Third()
        {
            using (var writer = new StreamWriter("third.txt"))
            {
                var wh = new WaitHandle[] { s13, exit };
                while (true)
                {
                    int res = WaitHandle.WaitAny(wh);
                    if (res == 1)
                    {
                        break;
                    }

                    int s = 0;
                    lock (cs)
                    {
                        s = num1 * num2;
                    }

                    s31.Set();

                    writer.WriteLine(s);
                }
            }
        }
    }
}
