using System;
using System.Collections;

namespace _17_collections_
{
    class Program
    {
        class Element
        {
            public string name;
            public int field1;
            public int field2;
        }
        abstract class Iterator
        {
            public abstract object First();
            public abstract object Next();
            public abstract object CurrentItem();
            public abstract bool IsDone();

        }
        abstract class Agregator
        {
            public abstract Iterator CreateIterator();
            public abstract object this[int index]{get;set;}
        }
        class ConcreteIterator: Iterator
        {
            private ConcreteAgregator agregator;
            private int current;
            public ConcreteIterator(ConcreteAgregator ag)
            {
                agregator = ag;
            }
            public override object First()
            {
                return agregator[0];
            }
            public override object Next()
            {
                object element = null;
                if(current<agregator.Count-1)
                {
                    element = agregator[++current];
                }
                return element;
            }
            public override object CurrentItem()
            {
                return agregator[current];
            }
            public override bool IsDone()
            {
                return current>=agregator.Count-1;
            }
        }
        class ConcreteAgregator: Agregator
        {
            private ArrayList elements = new ArrayList();
            private ConcreteIterator iterator;
            public override Iterator CreateIterator()
            {
                iterator = new ConcreteIterator(this);
                return iterator;
            }
            public int Count
            {
                get => elements.Count;
            }
            public override object this[int index] { get=>elements[index];set => elements.Insert(index, value); }
        }



        static void Main(string[] args)
        {
            ConcreteAgregator agregator = new ConcreteAgregator();
            agregator[0] = "ElementA";
            agregator[1] = "ElementB";
            agregator[2] = "ElementC";
            agregator[3] = "ElementD";
            Iterator iterator = agregator.CreateIterator();
            object element = iterator.First();
            Console.WriteLine(element);
            while(!iterator.IsDone())
            {
                element = iterator.Next();
                Console.WriteLine(element);
            }
        }
    }
}
