using System;

namespace _12_lambda_
{
    public delegate int MyDelegate(int a);
    public delegate void MyDelegate2();
    public delegate MyDelegate2 MyDelegate1();

    class Program
    {
        static MyDelegate2 Method1()
        {
            return new MyDelegate2(Method2);
        }
        static void Method2()
        {
            Console.WriteLine("Method2");
        }
        static void Sum(int x, MyDelegate dl)
        {
            int a = dl(7);
            Console.WriteLine(a);
        }
        static void Main(string[] args)
        {
            MyDelegate myDelegate = delegate (int x) { return x * 2; }; //lambda method
            myDelegate = x => { Console.WriteLine("lambda operator");
                                return x * 2;
                              }; //lambda operator

            //myDelegate = x => x * 2; //lambda operator(short form)
            
            int res = myDelegate(4);
            Sum(4, x => x * 2);
            //Console.WriteLine(res);


            MyDelegate1 myd1 = new MyDelegate1(Method1);
            MyDelegate2 myd2 = myd1();
            myd2();
        }
    }
}
