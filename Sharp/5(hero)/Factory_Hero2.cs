using System;
using System.Collections.Generic;
using System.Text;

namespace _5_hero_
{
    class Factory_Hero2 : AbstractFactory
    {
        public override AbstractHit CreateHit()
        {

            {
                return new ThrowBall();
            }
        }
        public override AbstractMove CreateMove()
        {
            return new Run();
        }
    }
}
