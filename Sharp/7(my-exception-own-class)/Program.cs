using System;
using System.IO;

namespace _7_my_exception_own_class_
{
    class UWUexception:Exception
    {
        public void Method()
        {
            Console.WriteLine("[UWU]");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                throw new UWUexception();
            }
            catch(UWUexception uwue)
            {
                Console.WriteLine("Exception!");
                uwue.Method();
                try
                {
                    FileStream fs = File.Open(@"C:\NonExistentFile.log", FileMode.Open);

                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine(e.GetType());
                }
            }
            Console.ReadKey();
        }
    }
}
