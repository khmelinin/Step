using System;

namespace DZ_inheritance_
{
    
    /////////////////////////////////// #1 ////////////////////////////////////////////
    
    class Worker
    {
        string name;
        string job;
        int year;
        public Worker()
        {
            Console.WriteLine("Name = ");
            name = Console.ReadLine();
            Console.WriteLine("Job = ");
            job = Console.ReadLine();
            
            try
            {
                Console.WriteLine("Year = ");
                int y = Convert.ToInt32(Console.ReadLine());
                if (y > 0 && y < 2020)
                    year = y;
                else
                    throw new Exception("year is not correct");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                year = DateTime.Now.Year;
            }
            Console.WriteLine();
        }
        public void Experience(int y)
        {
            if(DateTime.Now.Year-year>y)
            Console.WriteLine(name);
        }
    }
    /////////////////////////////////// #1 ////////////////////////////////////////////
    ///
    /////////////////////////////////// #2 ////////////////////////////////////////////
    class Price
    {
        string name;
        string shop;
        int price;
        public Price()
        {
            Console.WriteLine("Name = ");
            name = Console.ReadLine();
            Console.WriteLine("Shop = ");
            shop = Console.ReadLine();
            Console.WriteLine("Price = ");
            price = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
        }

        public string Name { get => name; set => name = value; }
        public string Shop { get => shop; set => shop = value; }
        public int Price_ { get => price; set => price = value; }

    }

    /////////////////////////////////// #2 ////////////////////////////////////////////
    class Program
    {
        static void Main(string[] args)
        {
            // /*
            Worker[] w = { new Worker(), new Worker(), new Worker(), new Worker(), new Worker() };
            int y = 20;
            for(int i=0; i<w.Length; i++)
            {
                w[i].Experience(y);
            }
            // */

            Price[] p = { new Price(), new Price() };
            string s = "Auchan";
            try
            {
                int k = 0;
                for (int i = 0; i < p.Length; i++)
                {
                    if (p[i].Shop == s)
                    {
                        k++;
                        Console.WriteLine(p[i].Name);
                        Console.WriteLine(p[i].Price_);
                    }
                }
                if (k == 0)
                    throw new Exception("No goods in shop " + s);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }
    }
}
