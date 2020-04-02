using System;

namespace _8_extention_class_
{
    static class ExtentionClass
    {
        public static void ExtentionMethod(this string value)
        {
            Console.WriteLine(value);
        }
        public static void ExtentionMethod(this int value)
        {
            Console.WriteLine(value);
        }

        public static void ExtentionMethod(this string value1, string value2)
        {
            Console.WriteLine(value1 + value2);
        }
        public static void ExtentionMethod(this string value, int counter)
        {
            counter--;
            Console.WriteLine(value+counter);
            if (counter > 0)
                value.ExtentionMethod(counter);
            Console.WriteLine(value + counter);
            
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string text = "test";
            
            text.ExtentionMethod();
            3.ExtentionMethod();
        }
    }
}
