using System;

namespace DZ_delegates_tank__
{
    class Program
    {
        static void Main(string[] args)
        {
            Tank[] T34 = { new Tank("T34"), new Tank("T34"), new Tank("T34"), new Tank("T34"), new Tank("T34") };
            Tank[] Pantera = { new Tank("Pantera"), new Tank("Pantera"), new Tank("Pantera"), new Tank("Pantera"), new Tank("Pantera") };
            for (int i = 0; i < 5; i++)
            {
                Console.Write("T34 (True) vs Pantera (False) : ");
                Console.WriteLine(T34[i]*Pantera[i]);
            }
        }
    }
}
