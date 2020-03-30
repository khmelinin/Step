using System;
using System.Collections.Generic;
using System.Text;

namespace _5_abstract_factory_
{
    class PepsiBottle:AbstractBottle
    {
        public override void Interact(AbstractWater apa)
        {
            Console.WriteLine(this+" iteract with "+apa);
        }
    }
}
