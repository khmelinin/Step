using System;

namespace _6
{
    class Program
    {
        static void Main(string[] args)
        {
            Mediator med = new ConcreteMediator();
            
            Colleague cons = new Consumer(med);
            Colleague dev = new Developer(med);
            Colleague test = new Tester(med);
            med.Send("request",cons);
        }
    }
}
