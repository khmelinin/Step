using System;
using System.Collections;
using System.Linq;

namespace _18_Auto_
{
    class Auto
    {
        string mark;
        string model;
        int year;
        string color;

        public Auto(string m, string mod, int y, string c)
        {
            mark = m;
            model = mod;
            year = y;
            color = c;
        }

        public string Mark { get => mark; set => mark = value; }
        public string Model { get => model; set => model = value; }
        public int Year { get => year; set => year = value; }
        public string Color { get => color; set => color = value; }
    }
    class Customer
    {
        string name;
        string model;
        string tel;
        public Customer(string n,string mod, string t)
        {
            name = n;
            model = mod;
            tel = t;
        }

        public string Name { get => name; set => name = value; }
        public string Model { get => model; set => model = value; }
        public string Tel { get => tel; set => tel = value; }
    }
    class Program
    {
        
        static void Main(string[] args)
        {
            Auto[] autos = { new Auto("Toyota", "LandCruiser", 2000, "Yellow"), new Auto("Nissan", "GTRR34", 1999, "Silver"), new Auto("Toyota", "Supra", 1999, "Orange") };
            Customer[] customers = { new Customer("Alyx","Supra","+9999"), new Customer("Andrey", "GTRR34", "+333"), new Customer("Sergey", "LandCruiser", "+777") };
            var query = from x in autos
                        join n in costumers
                        on x.Model equals n.Models
                        

            foreach (var gr in query)
            {
                Console.WriteLine(gr.Name+" "+gr.Model);



                foreach (var number in gr)
                    Console.WriteLine("{0}, ", number);
            }
            /////////////////////////////////// NOT_COMPLITED /////////////////////////////////////
        }
    }
}
