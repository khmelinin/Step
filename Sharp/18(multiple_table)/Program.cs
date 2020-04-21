﻿using System;
using System.Linq;

namespace _18_multiple_table_
{
    class Program
    {
        static void Main(string[] args)
        {
            var query = from x in Enumerable.Range(1, 9) // Таблица умножения от 1 до 9.
                        from y in Enumerable.Range(1, 10)
                        select new
                        {
                            X = x,
                            Y = y,
                            Product = x * y
                        };



            foreach (var item in query)
                Console.WriteLine("{0} * {1} = {2}", item.X, item.Y, item.Product);
        }
    }
}
