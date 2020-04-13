using System;

namespace _13_lambda_
{
    class Program
    {
        public delegate double MyDelegate(double a, double b);
        static void Main(string[] args)
        {
            string z = "+";
            double num1 = 1, num2 = 3;
            MyDelegate myDelegate= null;
            z = Console.ReadLine();
            if (z == "+")
                myDelegate = (a, b) => a + b;
            else
                if (z == "-")
                myDelegate = (a, b) => a - b;
            else
                if (z == "*")
                myDelegate = (a, b) => a * b;
            else
                if (z == "/")
                myDelegate = (a, b) => { if (b != 0) return a / b; else { Console.WriteLine("(num/0) no no no"); return 0; } };
            else
                myDelegate = (a, b) => { Console.WriteLine("wrong operator");return 0; };
            
            double sum = myDelegate(num1, num2);
            Console.WriteLine(sum);
            
        }
    }
}
