using System;

namespace _20_garbage_collection_
{
    class Test
    {
        int[] array = new int[100000000]; //100 000 000 B*4=390625 KB = 381 MB

        public void Method(int i)
        {
            Console.WriteLine(i);
        }
        public int Method1()
        {
            return 1;
        }
        ~Test()
        {
            Console.WriteLine("Object "+this.GetHashCode()+" deleted");
        }

    }
    class MyClass
    {
        int a;
        public void VVV(Test c)
        {
            a = c.Method1();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var tests = new Test[1000];

            try
            {
                for (int i = 0; i < tests.Length; i++)
                {
                    //tests[i]=new Test();
                    //tests[i].Method(i);

                    Test test = new Test();
                    test.Method(i);
                }
            }
            catch(OutOfMemoryException ex)
            {
                Console.ForegroundColor=ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.WriteLine("Overflow!!!");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            Console.ReadKey();
        }
    }
}
