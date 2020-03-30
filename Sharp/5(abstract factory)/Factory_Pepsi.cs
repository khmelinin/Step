using System;
using System.Collections.Generic;
using System.Text;

namespace _5_abstract_factory_
{
    class Factory_Pepsi : AbstractFactory
    {
        public override AbstractWater CreateWater()
        {

            {
                return new PepsiWater();
            }
        }
        public override AbstractBottle CreateBottle()
        {
            return new PepsiBottle();
        }
    }
}
