using System;
using _23_1dll_;

namespace _23_1_
{
    class Program
    {
        static void Main(string[] args)
        {
            SportsCar sportcar = new SportsCar("Viper", 240,60);
            sportcar.Acceleration();

            MiniVan minivan = new MiniVan();
            minivan.Acceleration();
            
        }
    }
}
