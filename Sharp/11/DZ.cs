using System;
using System.Collections.Generic;
using System.Text;

namespace _11
{
    class Worker
    {
        int year;
        string name;
        string post;
        public string Name { get => name; set => name = value; }
        public string Post { get => post; set => post = value; }
        public int Year { get => year; }
        public Worker(string n, string p, int y)
        {
            this.name = n;
            this.post = p;

            this.year = y;
        }
        public int Experience()
        {
            return DateTime.Now.Year - year;
        }
    }

    class Company
    {
        Worker[] staff;
        string name;
        string post;
        int year;
        string tmp;
        public Company()
        {
            staff = new Worker[5];
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Enter the name: ");
                name = Console.ReadLine();
                Console.WriteLine("Enter the post: ");
                post = Console.ReadLine();
                Console.WriteLine("Enter the year: ");
                tmp = Console.ReadLine();

                try
                {
                    year = Convert.ToInt32(tmp);
                }
                catch(Exception e)
                {
                    Console.WriteLine("!Wrong number!");
                    Console.WriteLine(e.Message);
                    year = DateTime.Now.Year;
                }
                staff[i] = new Worker(name, post, year);
                //Console.Clear();
            }
        }
        public string this[int index]
        {
            get
            {
                for (int i = 0; i < staff.Length; i++)
                {
                    if(staff[i].Experience()>index)
                    {
                        return "Name " + staff[i].Name+"\n";
                    }
                }
                return "Nothing";
            }
        }
    }
}
