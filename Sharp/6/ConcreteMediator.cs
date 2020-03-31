using System;
using System.Collections.Generic;
using System.Text;

namespace _6
{
    class ConcreteMediator : Mediator
    {
        public Consumer Colleague0 { get; set; }
        public Developer Colleague1 { get; set; }
        public Tester Colleague2 { get; set; }
        
        public override void Send(string msg, Colleague colleague)
        {
            if (Colleague0 == colleague)
            {
                Colleague1.Notify(msg);
            }
            else
                if (Colleague1 == colleague)
            {
                Colleague2.Notify(msg);
            }
            else
                if (Colleague2 == colleague)
            {
                Colleague0.Notify(msg);
            }

        }
    }
}
