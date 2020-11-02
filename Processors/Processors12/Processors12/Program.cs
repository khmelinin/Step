using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Processors12
{
    class Program
    {
        static Driver driver;
        static void Main(string[] args)
        {
            Console.WriteLine("q - start engine\ne - stop engine\nw - gas\ns - brake\nd - gear up\na - gear down\nexit - exit");
            driver = new Driver(new Car(
                new Engine(4.8, 7000),
                new GearBox(7),
                new FuelTank(40)));
            while (true)
            {
                driver.Drive();
            }
        }
    }
}
