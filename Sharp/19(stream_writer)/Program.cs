using System;
using System.Collections;
using System.IO;
using System.Text;

namespace _19_stream_writer_
{
    class Program
    {
        static void Main(string[] args)
        {
            var file = new FileStream(@"C:\Users\AdmiN\source\repos\khmelinin\Step\Sharp\19(stream_writer)\test.txt",FileMode.OpenOrCreate,FileAccess.ReadWrite);
            //StreamWriter writer = file.CreateText();
            var writer = new StreamWriter(file, Encoding.ASCII);

            writer.WriteLine("1st line");
            writer.WriteLine("2nd line");
            writer.Write(writer.NewLine);
            writer.WriteLine("3rd line");

            for (int i = 0; i < 10; i++)
            {
                writer.Write(i + " ");
            }
            writer.Write(writer.NewLine);
            writer.Close();

            Console.WriteLine();

            StreamReader reader = File.OpenText(@"C:\Users\AdmiN\source\repos\khmelinin\Step\Sharp\19(stream_writer)\test.txt");
            string input;

            while((input=reader.ReadLine())!=null)
            {
                Console.WriteLine(input);
            }
            reader.Close();

        }
    }
}
