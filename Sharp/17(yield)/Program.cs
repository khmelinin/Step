using System;
using System.Collections;

namespace _17_yield_
{
    class Collection<T> : IEnumerable
    {
        public T[] array = new T[8];
        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < array.Length; i++)
            {
                yield return array[i];
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Collection<string> col = new Collection<string>();
            col.array[0] = "a";
            col.array[1] = "N";
            col.array[2] = "Main";

            foreach (var item in col)
            {
                Console.WriteLine(item);
            }
        }
    }
}
