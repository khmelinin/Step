using System;
using System.Collections;
using System.IO;

namespace _19_directory_
{
    class Program
    {
        static void Main(string[] args)
        {
            var stream = new FileStream(@"C:\Users\AdmiN\source\repos\khmelinin\Step\Sharp\19(directory)\test1.txt",FileMode.OpenOrCreate,FileAccess.ReadWrite);

            for (int i = 0; i < 256; i++)
            {
                stream.WriteByte((byte)i);
            }
            Console.WriteLine(stream.Position);

            stream.Position = 0;
            for (int i = 0; i < 256; i++)
            {
                Console.WriteLine(" " + stream.ReadByte());
            }
            stream.Close();

            // Delay.
            Console.ReadKey();
        }
    }
}
