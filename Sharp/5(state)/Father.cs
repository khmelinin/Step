using System;
using System.Collections.Generic;
using System.Text;

namespace _5_state_
{
    class Father
    {
        public State State { get; set; }
        public Father(State state)
        {
            this.State = state;
        }
        public void Request(int n)
        {
            this.State.Handle(this, n);
        }
    }
}
