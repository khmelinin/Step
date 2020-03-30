using System;
using System.Collections.Generic;
using System.Text;

namespace _5_state_
{
    class Angry:State
    {
        public Angry()
        {
            Console.WriteLine("Angry");
        }
        public override void Handle(Father f, int n)
        {
            if (n == 5)
                f.State = new Normal();
            if (n == 2)
                f.State = new VeryAngry();
        }
    }
}
