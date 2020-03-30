using System;
using System.Collections.Generic;
using System.Text;

namespace _5_hero_
{
    abstract class AbstractFactory
    {
        public abstract AbstractHit CreateHit();
        public abstract AbstractMove CreateMove();
    }
}
