using System;
using System.Collections.Generic;
using System.Text;

namespace _5_state_
{
    class Normal:State
    {
        public Normal()
        {
            Console.WriteLine("Normal");
        }
        public override void Handle(Father f,int n)
        {
            if(n==5)
            f.State = new Happy();
            if (n == 2)
            f.State = new Pity();
        }
    }
}
