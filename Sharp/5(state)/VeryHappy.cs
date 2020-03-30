using System;
using System.Collections.Generic;
using System.Text;

namespace _5_state_
{
    class VeryHappy:State
    {
        public VeryHappy()
        {
            Console.WriteLine("VeryHappy");
        }
        public override void Handle(Father f, int n)
        {
            if (n == 5)
                f.State = new VeryHappy();
            if (n == 2)
                f.State = new Pity();
        }
    }
}
