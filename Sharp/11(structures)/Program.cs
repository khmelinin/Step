using System;

namespace _11_structures_
{
    struct MyStruct
    {
        public int field;
        public MyStruct(int f)
        {
            Console.WriteLine("public MyStruct(int f)");
            field = f;
        }
        static MyStruct()
        {
            Console.WriteLine("static MyStruct()");
        }
        public void Show()
        {
            Console.WriteLine(field);
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            MyStruct instance=new MyStruct(333) { field=89890};
            //instance.field = 1;
            Console.WriteLine(instance.field);
            Console.ReadKey();
        }
    }
}
