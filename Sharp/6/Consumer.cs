using System;
using System.Collections.Generic;
using System.Text;

namespace _6
{
    class Consumer : Colleague
    {
        public Consumer(Mediator mediator)
            : base(mediator)
        { }

        public void Send(string message)
        {
            mediator.Send(message, this);
        }

        public void Notify(string message)
        {
            Console.WriteLine("Notify Consumer");
        }
    }
}
