using System;

namespace _16_extention_of_class_type._._._
{
    class MyClass<T1, T2>
    {
        

        public T1 field1;
        public T2 field2;
        public U Method<T3, U>(T3 arg, U v)
        {
            Console.WriteLine("field1 = " + field1.GetType());
            Console.WriteLine("field2 = " + field2.GetType());
            Console.Write("return = ");
            Console.WriteLine(arg);
            U val = v;
            return val;
        }
    }

    class MyClass1<TT>
    {
        TT field;
    }

    delegate R MyDelegate<Y, R>(Y arg);

    class Program
    {
        static int Add(double d)
        {
            return Convert.ToInt32(d);
        }
        static string Concantenation(string s)
        {
            return "Hello " + s;
        }





        static void Main(string[] args)
        {
            MyClass<int,int> a = new MyClass<int,int>();
            Console.WriteLine(a.Method<int, bool>(3, true));
            MyClass<string,int> b = new MyClass<string,int>();
            b.field1 = "adf";
            Console.WriteLine(b.Method<string,double>("str",7.62));

            MyDelegate<double, int> delegate1 = new MyDelegate<double, int>(Add);
            int aa = delegate1(12.6);
            MyDelegate<string, string> delegate2 = new MyDelegate<string, string>(Concantenation);
            string st = delegate2("Zorro");
        }
    }
}
