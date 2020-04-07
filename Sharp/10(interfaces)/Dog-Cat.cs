using System;
using System.Collections.Generic;
using System.Text;

namespace _10_interfaces_
{
    interface IGoEat
    {
        void Go();
        void Eat();
    }
    interface ISecurity
    {
        void Guard();
    }
    class Dog:IGoEat,ISecurity
    {
        public void Go()
        {
            Console.WriteLine("Dog step");
        }

        public void Eat()
        {
            Console.WriteLine("Dog eat");
        }
        public void Guard()
        {
            Console.WriteLine("Dog is guar");
        }
    }

    class Cat:IGoEat
    {
        public void Go()
        {
            Console.WriteLine("Cat step");
        }

        public void Eat()
        {
            Console.WriteLine("Cat eat");
        }
    }
}
