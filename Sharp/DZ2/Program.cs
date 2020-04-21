using System;

namespace DZ2
{
    partial class Auto
    {
        private static string material;
        private static int doors;
        int id;
        string company;
        string model;
        int power;
        int cost;
        public Auto()
        {
            id = 0;
            company = "NONE";
            model = "NONE";
            power = 0;
            cost = 0;
        }
        static Auto()
        {
            material = "metal";
            doors = 4;
        }
        public Auto(string co, string m)
        {
            company = co;
            model = m;
        }
        public Auto(int i)
        {
            id = i;
        }
        public Auto(int i, string co, string m, int p, int c)
        {
            id = i;
            company = co;
            model = m;
            power = p;
            cost = c;
        }
        public int Id { get => id; set => id = value; }
        public string Company { get => company; set => company = value; }
        public string Model { get => model; set => model = value; }
        public int Power { get => power; set => power = value; }
        public int Cost { get => cost; set => cost = value; }

        public void Method(ref int c)
        {
            cost = c;
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Auto[]a= { new Auto(123),new Auto("Bomer","m34"),new Auto(), new Auto(111,"Tesla","QX",444,12000), new Auto(90)};
            a[3].Wroom();
        }
    }
}
