using System;
using System.Collections.Generic;
using System.Text;

namespace _5_state_
{
    abstract class State
    {
        public abstract void Handle(Father f, int n);
    }
}
