using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Processors12
{
    class Engine
    {
        double rev;
        public Engine(double c, double mr)
        {
            Capacity = c;
            rev = 0;
            MaxRevs = mr;
        }
        public double Capacity { get; set; }
        public double Revs
        {
            get => rev; set
            {
                if (rev > MaxRevs)
                {
                    Console.WriteLine("!!! Engine Burning");
                    rev = 0;
                }
                else
                {
                    rev = value;
                }
            }
        }
        public double MaxRevs { get; }
    }
}
