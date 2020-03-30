using System;
using System.Collections.Generic;
using System.Text;

namespace _5_hero_
{
    class Factory_Hero1:AbstractFactory
    {
        public override AbstractHit CreateHit()
        {
           
            {
                return new ShootFromBow();
            }
        }
        public override AbstractMove CreateMove()
        {
            return new Fly();
        }
    }
}
