using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Processors12
{
    class FuelTank
    {
        double volume;
        public FuelTank(double val)
        {
            volume = val;
        }
        public double Volume { get => volume;
            set
            {
                if (volume <= 0)
                {
                    Console.WriteLine("! Out of fuel");
                }
                else
                {
                    volume = value;
                }
            }
        }
    }
}
