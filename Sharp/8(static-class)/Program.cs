using System;

namespace _8_namespaces_
{
    class NotStaticClass
    {
        static readonly long readonlyField = 2;
        public int x;
        public static long ReadonlyField
        {
            get => readonlyField;
        }
        public NotStaticClass()
        {
            Console.WriteLine("My Constructor()");
            x = 2;
        }
        static NotStaticClass()
        {
            Console.WriteLine("My StaticConstructor()");
            readonlyField = 1;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(NotStaticClass.ReadonlyField);
        }
    }
}
