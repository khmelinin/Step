using System;

namespace _18_anonimous_types_
{
    class MyClass
    {

    }
    delegate void MyDelegate(string st);
    class Program
    {
        static void Main(string[] args)
        {
            var instance = new
            {
                MyDel = new MyDelegate(t => Console.WriteLine(t))
            };
            instance.MyDel("Hi");
        }
    }
}
