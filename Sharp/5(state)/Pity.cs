using System;
using System.Collections.Generic;
using System.Text;

namespace _5_state_
{
    class Pity:State
    {
        public Pity()
        {
            Console.WriteLine("Pity");
        }
        public override void Handle(Father f, int n)
        {
            if (n == 5)
                f.State = new Normal();
            if (n == 2)
                f.State = new Angry();
        }
    }
}
