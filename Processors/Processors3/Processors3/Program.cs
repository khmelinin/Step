using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Processors3
{
    class Program
    {
        static void Main(string[] args)
        {
            const string mutexName = "Mutex_first";
            if (Mutex.TryOpenExisting(mutexName, System.Security.AccessControl.MutexRights.Synchronize, out Mutex result))
            {
                Console.WriteLine("Mutex is created, exit");
                result.Close();
                result.Dispose();
            }
            result = new Mutex(true, mutexName);
            Console.WriteLine("Waiting...");
            Console.ReadLine();

            EventWaitHandle wh;
            AutoResetEvent are;
            ManualResetEvent mre;
        }
    }
}
