using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Processors7
{
    // MX = (MA*MB)
    interface IPair<T>
    {
        T First { get; set; }
        T Second { get; set; }
    }

    struct Pair<T> : IPair<T>
    {
        public T First { get; set; }
        public T Second { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Task[] arr = new Task[4];
            for (int i = 0; i < 4; i++)
            {
                Pair<int> p = default(Pair<int>);
                p.First = i;
                p.Second = i + 2;
                arr[i] = new Task(MAMB, p);
                arr[i].ContinueWith(MCMD, p).ContinueWith(MAMB, p);
                arr[i].Start();
            }
            Task.WaitAll(arr);

            Task t = new Task(() =>
            {
                Console.WriteLine($"Start task {Task.CurrentId}");
                Console.WriteLine($"2+2={2 + 2}");
                Console.WriteLine($"Finish task {Task.CurrentId}");
            });
            t.Start();
            var t1 = Task.Run(() =>
            {
                Console.WriteLine($"Start task {Task.CurrentId}");
                Console.WriteLine($"3+3={3 + 3}");
                Console.WriteLine($"Finish task {Task.CurrentId}");
            });
            t1.ContinueWith((o) =>
            {
                Console.WriteLine($"Complete t1 {o.Id}");
                Console.WriteLine("Continue other task");
            });
            Console.WriteLine("Worked");
            Console.WriteLine("Main complete");
            Task.WaitAll(t, t1);
        }

        private static object MCMD(Task t, object o)
        {
            return o;
        }

        private static void MAMB(object o)
        {
            var p = (Pair<int>)o;
        }
    }
}
