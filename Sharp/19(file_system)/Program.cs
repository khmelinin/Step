using System;
using System.Collections;
using System.Linq;
using System.IO;

namespace _19_file_system_
{
    class Program
    {
        static void Main(string[] args)
        {
            var directory = new DirectoryInfo(@"C:\Users\AdmiN\source\repos\khmelinin\Step\Sharp\19(file_system)");
            if(directory.Exists)
            {
                FileInfo[] files = directory.GetFiles("*.txt");
                
                foreach(FileInfo file in files)
                {
                    
                    Console.WriteLine("File name: {0}", file.Name); ;
                    Console.WriteLine("File size: {0}", file.Length); ;
                    Console.WriteLine("Creation time: {0}", file.CreationTime);
                    Console.WriteLine("Attributes: {0}", file.Attributes);
                    Console.Write("\n");
                }
               
            }
            else
                {
                    Console.WriteLine("nothing_special");
                }

            Console.WriteLine();
            var file1 = new FileInfo(@"C:\Users\AdmiN\source\repos\khmelinin\Step\Sharp\19(file_system)\test333.txt");
            FileStream stream = file1.Open(FileMode.OpenOrCreate,FileAccess.Read,FileShare.None); //file1.Create()
            Console.WriteLine(file1.FullName);
            Console.WriteLine(file1.Attributes.ToString());
            Console.WriteLine(file1.CreationTime);
            stream.Close();
        }
    }
}
