using System;
using System.Collections.Generic;
using System.Text;

namespace _23_1dll_
{
    public class SportsCar : Car
    {
        public SportsCar()
        {
        }



        public SportsCar(string name, short maxSpeed, short currentSpeed)
            : base(name, maxSpeed, currentSpeed)
        {
        }



        public override void Acceleration()
        {
            Console.WriteLine("SPORTCAR:  Быстрая скорость!");



        }
    }
}
