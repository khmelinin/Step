using System;
using System.Collections.Generic;
using System.Text;

namespace _5_state_
{
    class Happy:State
    {
        public Happy()
        {
            Console.WriteLine("Happy");
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
