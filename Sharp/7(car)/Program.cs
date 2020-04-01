using System;

namespace _7_car_
{
    class Engine
    {
        private int speed = 0;
        public int Speed
        {
            get => speed;
            set => speed = value;
        }
        public int Boost(int n)
        {
            speed += n;
            if(speed<=200)
            {

            }
            else
            {
                speed = 0;
                CarException ce = new CarException("speed > 200");
                throw ce;

            }
            return speed;
        }
    }
    class BodyCar
    {

    }
    class Car
    {
        private Engine engine;
        private BodyCar body;
        int speed = 0;
        public Car() 
        { 
            engine = new Engine();
           
            body = new BodyCar();
        }
        public int Speed
        {
            get => speed;
            set => speed = value;
        }
        public void Boost(int b)
        {
           
            speed = engine.Boost(b);
            Console.WriteLine(speed);
        }
    }
    class Game
    {
        private Car car;
        public Game()
        {
            car = new Car();
        }
        public void Run()
        {
            while(true)
            {
                try
                {
                    car.Boost(10);
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                    break;
                }
            }
        }
    }
    class CarException:Exception
    {
        public CarException(string s):base(s)
        {

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Game g = new Game();
            g.Run();
        }
    }
}
