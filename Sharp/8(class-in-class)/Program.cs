using System;

namespace _8_class_in_class_
{
    class Base
    {
        static int a;
        class Nested
        {
            public void MethodNested()
            {
                Console.WriteLine(a);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
