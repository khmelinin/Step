using System;
using System.IO;
using System.Text;
using System.Collections;

namespace _19_file_collection_
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            FileStream file = File.Open(@"C:\Users\AdmiN\source\repos\khmelinin\Step\Sharp\19(file_collection)\test.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);

            StreamReader reader = new StreamReader(file);
            Console.WriteLine(reader.ReadToEnd());
            reader.Close();

            Console.WriteLine("\n");

            reader = File.OpenText(@"C:\Users\AdmiN\source\repos\khmelinin\Step\Sharp\19(file_collection)\test.txt");
            Console.WriteLine(reader.ReadToEnd());
            reader.Close();
            Console.WriteLine("\n");
            Console.WriteLine(File.ReadAllText(@"C:\Users\AdmiN\source\repos\khmelinin\Step\Sharp\19(file_collection)\test.txt"));
            */

            string s = "Hello all!" + Environment.NewLine + "This is a multiline \n text string";

            var reader1 = File.OpenText(@"C:\Users\AdmiN\source\repos\khmelinin\Step\Sharp\19(file_collection)\test.txt");
            var reader2 = new StringReader(s);

            while(reader2.Peek()!=-1)
            {
                string line = reader2.ReadLine();
                Console.WriteLine(line);
            }

            while(!reader1.EndOfStream)
            {
                
                string line = reader1.ReadLine();

                if(line!=null && line.Contains("3"))
                {
                    Console.WriteLine("Found: ");
                    Console.WriteLine(line);
                    break;
                }
            }
            reader1.Close();

        }
    }
}
