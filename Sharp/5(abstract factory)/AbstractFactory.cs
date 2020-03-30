using System;
using System.Collections.Generic;
using System.Text;

namespace _5_abstract_factory_
{
    abstract class AbstractFactory
    {
        public abstract AbstractWater CreateWater();
        public abstract AbstractBottle CreateBottle();
    }
}
