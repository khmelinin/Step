using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace Processors6
{
    class Program
    {
        private static string filename="numbers.txt";
        private static int min = 2;
        private static int max = 100;
        private static int n = 100;
        private static List<int> numbers;
        private static int digit = 3;

        static AutoResetEvent ftos = new AutoResetEvent(false);
        static AutoResetEvent stot = new AutoResetEvent(false);

        static void Main(string[] args)
        {
            var t = new Thread(Third);
            t.Start();
            new Thread(First).Start();
            new Thread(Second).Start();
            t.Join();
        }

        static void First()
        {
            Random rnd = new Random();
            using (StreamWriter writer = new StreamWriter(filename))
            {
                for (int i = 0; i < n; i++)
                {
                    writer.WriteLine(rnd.Next(min, max));
                }
            }

            ftos.Set();
        }

        static void Second()
        {
            ftos.WaitOne();

            numbers = new List<int>();
            using (StreamReader reader = new StreamReader(filename))
            {
                while (!reader.EndOfStream)
                {
                    var s = reader.ReadLine();
                    if (string.IsNullOrWhiteSpace(s))
                    {
                        continue;
                    }
                    try
                    {
                        var d = Convert.ToInt32(s);
                        if (IsSimple(d))
                        {
                            numbers.Add(d);
                        }
                    }
                    catch (FormatException)
                    {
                        continue;
                    }
                    catch (OverflowException)
                    {
                        continue;
                    }
                }
            }
                //run second
                stot.Set();
        }

        static void Third()
        {
            stot.WaitOne();
            foreach (var item in numbers)
            {
                if (item % 10 == digit)
                {
                    Console.WriteLine(item);
                }
            }

        }
        static bool IsSimple(int n)
        {
            double t = Math.Sqrt(n);
            bool result = true;
            for (int i = 2; i <= t && result; i++)
            {
                result = !(n % i == 0);
            }
            return result;
        }
    }
}
