using System;
using System.Collections.Generic;
using System.Text;

namespace _5_abstract_factory_
{
    class Client
    {
        AbstractWater water;
        AbstractBottle bottle;
        public Client(AbstractFactory af)
        {
            water = af.CreateWater();
            bottle = af.CreateBottle();
        }
        public void Run()
        {
            bottle.Interact(water);
        }
    }
}
