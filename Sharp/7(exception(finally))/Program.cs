using System;

namespace _7_exception_finally__
{
    class ClassWithException
    {
        public void ThrowInner()
        {
            throw new Exception("!Inside exception!");
        }
        public void CatchInner()
        {
            try
            {
                this.ThrowInner();
            }
            catch(Exception e)
            {
                throw new Exception("!Outside exception!",e);
            }
        }
    }
    class Program
    {
        
        static void Main(string[] args)
        {
            /*
             
            int a = 1, n = 2;
            try
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Try to dividing by Zer0");
                Console.WriteLine("a/(2-n)={0}", a / (2 - n));
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("!Exception!");
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.BackgroundColor = ConsoleColor.Black;
            }
            Console.WriteLine("press any K(ey)...");

            */

            ////////////////////////////////////////////////

            ClassWithException instance = new ClassWithException();

            try
            {
                instance.CatchInner();
            }
            catch(Exception e)
            {
                Console.WriteLine("Exception caught: {0}", e.Message);
                Console.WriteLine("Inner Exception: {0}", e.InnerException.Message);
            }

            Console.ReadKey();
            
        }
    }
}
