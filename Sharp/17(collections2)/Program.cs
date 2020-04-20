using System;
using System.Collections;

namespace _17_collections2_
{

    public class Element
    {
        // Поля.

        private string name;
        private int field1;
        private int field2;
        
        // Конструктор.
        public Element(string s, int a, int b)
        {
            name = s;
            field1 = a;
            field2 = b;
        }
        
        // Свойства.
        public int Field1
        {
            get { return field1; }
            set { field1 = value; }
        }
        
        public int Field2
        {
            get { return field2; }
            set { field2 = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
    }

    public class UserCollection : IEnumerable, IEnumerator
    {
        public Element[] elementsArray = null;



        public UserCollection()
        {
            elementsArray = new Element[4];
            elementsArray[0] = new Element("A", 1, 10);
            elementsArray[1] = new Element("B", 2, 20);
            elementsArray[2] = new Element("C", 3, 30);
            elementsArray[3] = new Element("D", 4, 40);
        }

        // Указатель текущей позиции элемента в массиве.
        int position = -1;



        // ------------------------------------------------------------------------------------------------------------------
        // Реализация интерфейса IEnumerator.



        // Передвинуть внутренний указатель (position) на одну позицию.
        public bool MoveNext()
        {
            if (position < elementsArray.Length - 1)
            {
                position++;
                return true;
            }
            else
            {
                return false;
            }
        }



        // Установить указатель (position) перед началом набора.
        public void Reset()
        {
            position = -1;
        }



        // Получить текущий элемент набора. 
        public object Current
        {
            get { return elementsArray[position]; }
        }



        // -----------------------------------------------------------------------------------------------------------------
        // Реализация интерфейса - IEnumerable.



        IEnumerator IEnumerable.GetEnumerator()
        {
            return this as IEnumerator;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            UserCollection myCollection = new UserCollection();
            foreach(Element element in myCollection)
            {
                Console.WriteLine("Name: {0} Field1: {1} Field2: {2} ", element.Name, element.Field1, element.Field2);

            }
            Console.Write(new string('-',29)+"/n");

            foreach(Element element in myCollection)
            {
                Console.WriteLine("Name: {0} Field1: {1} Field2: {2} ", element.Name, element.Field1, element.Field2);

            }
            Console.Write(new string('-', 29) + "/n");




            UserCollection myElementsCollection = new UserCollection();
            IEnumerable enumerable = myElementsCollection as IEnumerable;
            IEnumerator enumerator = enumerable.GetEnumerator();

            while(enumerator.MoveNext())
            {
                Element element = enumerator.Current as Element;
                Console.WriteLine("Name: {0} Field1: {1} Field2: {2} ", element.Name, element.Field1, element.Field2);

            }
            enumerator.Reset();
            Console.ReadKey();
        }
    }
}
