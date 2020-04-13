using System;

namespace _13
{
    delegate void Listener();
    class Button
    {
        public Listener buttonListener;
        public void OnClick()
        {
            buttonListener();
        }
    }
    class Car
    {
         
        public void Move()
        {
            Console.WriteLine("Move from Car");
        }
    }

    class Road
    {
        
        public void State()
        {
            Console.WriteLine("Move from Road");
        }
    }
    class Program
    {
        public delegate bool Logika_1(int x);
        static void Check(Logika_1 log, int a)
        {
            if(log(a))
            {
                Console.WriteLine("> 0");
            }
            else
            {
                Console.WriteLine("< 0");
            }
        }
        static bool LOG_1(int d)
        {
            Console.WriteLine("LOG_1");
            return d > 0;
        }

        static bool LOG_2(int t)
        {
            Console.WriteLine("LOG_2");
            return (t-1) > 0;
        }

        static void Main(string[] args)
        {
            /*
            Car car = new Car();
            Road road = new Road();
            Button button = new Button();
            button.buttonListener = new Listener(road.State);
            button.buttonListener += car.Move;
            button.OnClick();
            Console.WriteLine("____________________");
            button.buttonListener -= car.Move;
            button.OnClick();
            */

            Logika_1 logike = new Logika_1(LOG_1);
            logike(68);
            Check(logike,6);
            Console.WriteLine("______________");
            logike += LOG_2;
            logike -= LOG_1;
            Check(logike, -6);

        }
    }
}
