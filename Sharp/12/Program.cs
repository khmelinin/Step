using System;

namespace _12
{
    public delegate void MyDeligate();
    class MyClass
    {
        public void Method()
        {
            Console.WriteLine("Method from delegat");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            MyClass instance = new MyClass();
            MyDeligate myDeligate = new MyDeligate(Sum);
            MyDeligate myDeligate1 = myDeligate + myDeligate;
            myDeligate1();
            myDeligate.Invoke();
            
        }
        private static void Sum()
            {
                Console.WriteLine("Sum Method from deligate");
            }
    }
}
