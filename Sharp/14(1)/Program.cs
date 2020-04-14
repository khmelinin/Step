using System;

namespace _14_1_
{
    class Program
    {
        static void Main(string[] args)
        {
            //Predicate<int> md=MyFunc;
            Func<string,int> fc = MyFunc;
            fc(3);
        }
        static int MyFunc(string r)
        {
            Console.WriteLine("MyAction + "+r);
            return (Convert.ToInt32(r));
        }
    }
}
