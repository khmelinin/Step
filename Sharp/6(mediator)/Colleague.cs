using System;
using System.Collections.Generic;
using System.Text;

namespace _6_mediator_
{
    abstract class Colleague
    {
        protected Mediator mediator;

        public Colleague(Mediator mediator)
        {
            this.mediator = mediator;
        }
    }
}
