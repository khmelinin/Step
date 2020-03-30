using System;
using System.Collections.Generic;
using System.Text;

namespace _5_abstract_factory_
{
    class Factory_Coca:AbstractFactory
    {
        public override AbstractWater CreateWater()
        {
           
            {
                return new CocaWater();
            }
        }
        public override AbstractBottle CreateBottle()
        {
            return new CocaBottle();
        }
    }
}
