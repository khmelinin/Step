using System;
using System.Collections.Generic;
using System.Text;

namespace _10_interfaces_
{
    class Class1:Interface1,Interface2
    {
        void Interface1.Method()
        {
            Console.WriteLine("Interface1.Method1");
        }
        void Interface2.Method()
        {
            Console.WriteLine("Interface2.Method2");
        }
    }
}
