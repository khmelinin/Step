using System;
using System.Collections.Generic;


namespace Sharp
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            string name="";
            int age = 0;
            double height = 0;
            Console.Write("Введите имя ");
            name = Console.ReadLine();
            Console.Write("Введите возраст ");
            age = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите рост ");
            height = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Имя: {0} Возраст: {1} Рост: {2}",name,age,height);
            */

            /*
            string[,] arr = new string[5, 5];
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (Math.Abs(i-2)+Math.Abs(j-2)<=2)
                        arr[i, j] = "1 ";
                    else
                        arr[i, j] = "  ";
                }
            }

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Console.Write(arr[i, j]);
                }
                Console.WriteLine();
            }
            */

            string a = " ";
            Console.Write("Enter your bilet = ");
            a = Console.ReadLine();
            if(Convert.ToInt32(a[0])+ Convert.ToInt32(a[1])+ Convert.ToInt32(a[2])== Convert.ToInt32(a[a.Length- 0]) + Convert.ToInt32(a[a.Length- 1]) + Convert.ToInt32(a[a.Length- 2]))
                Console.WriteLine("!!!Congratulations!!!");
            else
                Console.WriteLine("eh");

                    Console.ReadKey();
        }
    }
}
