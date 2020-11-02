using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Processors12
{
    class GearBox
    {
        int max_gear;
        int current = 0;
        public GearBox(int x)
        {
            max_gear = x;
            CurrentGear = 0;
        }
        public int CurrentGear
        {
            get => current; set
            {
                if (current < 0 && current > max_gear)
                {
                    Console.WriteLine("!!! Out of gears");
                }
                else
                {
                    current = value;
                }
            }
        }
    }
}
