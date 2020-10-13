using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Main
{
    class Program
    {
        static void Main(string[] args)
        {
            //var p = Process.Start("Child1.exe", "1 * 3");
            //if (p != null)
            //{
            //    p.WaitForExit();
            //}

            Thread thread = new Thread(ThreadProc);
            thread.Start();

            int id = Thread.CurrentThread.ManagedThreadId;
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine($"{id} -- {i}");
            }

            thread.Join();

        }

        static void ThreadProc()
        {
            int id = Thread.CurrentThread.ManagedThreadId;
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine($"{id} -- {i}");
            }
        }
    }
}
