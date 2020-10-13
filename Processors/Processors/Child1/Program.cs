using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Child1
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach(var item in args)
            {
                Console.WriteLine(item);
            }
            if(args.Length<3)
            {
                Console.WriteLine("Not much args");
                return;
            }
            int a = Convert.ToInt32(args[0]);
            int b = Convert.ToInt32(args[2]);
            switch(args[1])
            {
                case "+":
                    Console.WriteLine("= " + (a + b));
                    break;
                case "-":
                    Console.WriteLine("= " + (a - b));
                    break;
                case "*":
                    Console.WriteLine("= " + (a * b));
                    break;
                case "/":
                    Console.WriteLine("= " + (a / b));
                    break;
                default:
                    Console.WriteLine("Unknown command");
                    break;
            }
            Console.ReadLine();
        }
    }
}
