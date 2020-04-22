using System;
using System.Collections;
using System.Text;
using System.IO;

namespace _19_binary_writer_
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream file = File.Create(@"C:\Users\AdmiN\source\repos\khmelinin\Step\Sharp\19(binary_writer)\test.txt");
            var writer = new BinaryWriter(file);

            long number = 100;
            byte[] bytes = new byte[] { 10, 20, 50, 100 };
            string s = "hunger";

            writer.Write(number);
            writer.Write(bytes);
            writer.Write(s);

            writer.Close();

            FileStream file1 = File.Create(@"C:\Users\AdmiN\source\repos\khmelinin\Step\Sharp\19(binary_writer)\test.txt");
            var reader = new BinaryReader(file1);

            long number1 = reader.ReadInt64();
            byte[] bytes1 = reader.ReadBytes(4);
            string s1 = reader.ReadString();

            reader.Close();
            Console.WriteLine(number);
            foreach(byte b in bytes1)
            {
                Console.WriteLine("[{0}] ",b);
            }
            Console.WriteLine();
            Console.WriteLine(s);
        }
    }
}
