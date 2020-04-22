using System;
using System.Collections;
using System.IO;

namespace _19_byte_write_
{
    class Program
    {
        static void Main(string[] args)
        {
            var memory = new MemoryStream();



            //  Задаем требуемый объем памяти.
            //   memory.Capacity = 256;



            // Записываем байты в поток.
            for (var i = 0; i < 256; i++)
            {
                memory.WriteByte((byte)i);
            }



            // Переставляем внутренний указатель на начало.
            memory.Position = 0;



            // Считывам байты из потока.
            for (int i = 0; i < 256; i++)
            {
                Console.Write(" " + memory.ReadByte());
            }



            Console.WriteLine("\n" + new string('-', 80));



            // Сохраняем данные из MemoryStream в массив байт.
            byte[] array = memory.ToArray();

            foreach (byte b in array)
            {
                Console.Write(b);
            }



            Console.WriteLine("\n" + new string('-', 80));



            // Сохраняем данные из MemoryStream в файл.
            var file = new FileStream(@"C:\Users\AdmiN\source\repos\khmelinin\Step\Sharp\19(file_system)\Dump.dat", FileMode.Create, FileAccess.ReadWrite);
            memory.WriteTo(file);

            // Переставляем внутренний указатель на начало.
            file.Position = 0;



            // Считывам байты из файла.
            for (int i = 0; i < 256; i++)
            {
                Console.Write(" "+file.ReadByte());
            }
            memory.Close();
            file.Close();



            // Delay.
            Console.ReadKey();
        }
    }
}