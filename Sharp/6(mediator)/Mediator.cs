using System;
using System.Collections.Generic;
using System.Text;

namespace _6_mediator_
{
    abstract class Mediator
    {
        public abstract void Send(string msg, Colleague colleague);
    }
}
