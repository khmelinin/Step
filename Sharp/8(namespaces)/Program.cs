using System;
using NamespaceA;
using NamespaceA.NamespaceB;
using NamespaceA.NamespaceB.NamespaceC;

namespace NamespaceA
{
    namespace NamespaceB
    {
        namespace NamespaceC
        {
            class ClassC
            {
                public void Method()
                {
                    Console.WriteLine("ClassC");
                }
            }
        }
        class B { }
    }
    class A { }
}

namespace _8_namespaces_
{
    using MyClass = NamespaceA.NamespaceB.NamespaceC.ClassC;
    class Program
    {
        static void Main(string[] args)
        {
            MyClass c = new MyClass();
            c.Method();
            Console.WriteLine("Hello World!");
        }
    }
}
