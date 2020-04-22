using System;
using System.Collections;
using System.IO;

namespace _19_directory_creation_
{
    class Program
    {
        static void Main(string[] args)
        {
            var directory = new DirectoryInfo(@".");
            Console.WriteLine(directory.FullName);
            // Создание в TESTDIR новых подкаталогов.
            if (directory.Exists)
            {
                // Создаем D:\TESTDIR\SUBDIR.
                directory.CreateSubdirectory("SUBDIR");



                // Создаем D:\TESTDIR\MyDir\SubMyDir.
                directory.CreateSubdirectory(@"MyDir\SubMyDir");



                Console.WriteLine("Директории созданы.");
            }
            else
            {
                Console.WriteLine("Директория с именем: {0}  не существует.", directory.FullName);
            }



            // Delay.
            Console.ReadKey();
        }
    }
}
