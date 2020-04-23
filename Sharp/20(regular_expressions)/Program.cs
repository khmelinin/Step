using System;
using System.Text.RegularExpressions;

namespace _20_regular_expressions_
{
    class Program
    {
        static void Main(string[] args)
        {
            const string pattern = @"\d*\D+\d+$";

            var regex = new Regex(pattern);

            var array = new[] { "test", "123", "test123aaa", "test123test", "123test", "test123" };

            foreach(string element in array)
            {
                Console.WriteLine(regex.IsMatch(element)
                    ? "\"{0}\" yes \"{1}\""
                    : "\"{0}\" no \"{1}\"", element,pattern);
                Console.WriteLine(new string(' ',33));
            }
            Console.WriteLine("\n\n");
            while(true)
            {
                Console.WriteLine("enter string: ");
                string input = Console.ReadLine();
                if (input == "exit")
                    break;
                
                Console.WriteLine(input!=null && regex.IsMatch(input)? "\"{0}\" yes \"{1}\"" : "\"{0}\" no \"{1}\"",input,pattern);
                
            }
            Console.WriteLine(Regex.Replace("test123aaa",
                @"\D+",
                "++"));
            Console.WriteLine(Regex.Replace("5 is less than 10",
                @"\d",
                m=>(int.Parse(m.Value)+1).ToString()));
        }
    }
}
