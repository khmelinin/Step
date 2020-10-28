using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Processors11
{
    class Program
    {
        static void Factorial(int n)
        {
            long res = 1;
            for (int i = 1; i <=n; i++)
            {
                res *= i;
            }
            Console.WriteLine($"{n}! = {res}");
        }
        static async void FactorialAsync(int n)
        {
            Console.WriteLine("Start of async method");

            //await Task.Run(() => { Factorial(n); });
            //await Task.Run(() => { Factorial(n + 1); });
            //await Task.Run(() => { Factorial(n + 2); });
            //await Task.Run(() => { Factorial(n + 3); });

            var t = Task.Run(() => { Factorial(n); });
            var t1 = Task.Run(() => { Factorial(n + 1); });
            var t2 = Task.Run(() => { Factorial(n + 2); });
            var t3 = Task.Run(() => { Factorial(n + 3); });
            await Task.WhenAll(t, t1, t2, t3);

            Console.WriteLine("End of async method");
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Start Main method");
            FactorialAsync(1);
            Console.WriteLine("End Main method");
            Console.ReadLine();
        }
    }
}
