using System;
using System.Text;
using System.IO;
using System.Collections;

namespace _19_string_writer_
{
    class Program
    {
        static void Main(string[] args)
        {
            var writer = new StringWriter();
            writer.WriteLine("Hi.");
            writer.Write("This is a multi-line ");
            writer.WriteLine("text string.");

            Console.WriteLine(writer.ToString());
        }
    }
}
