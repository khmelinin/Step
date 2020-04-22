using System;
using System.IO;
using System.Collections;
using System.Text;

namespace _19_buffer_
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream file = File.Create(@"C:\Users\AdmiN\source\repos\khmelinin\Step\Sharp\19(buffer)\test.txt");
            BufferedStream buffered = new BufferedStream(file);

            StreamWriter writer = new StreamWriter(buffered);

            writer.WriteLine("some data");

            buffered.Position = 0;

            writer.Close();

        }
    }
}
