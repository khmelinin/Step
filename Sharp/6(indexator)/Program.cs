using System;

namespace _6_indexator_
{
    class Str
    {
        private char[] s=new char[] { };
        public char this[int i]
        {
            get
            {
                return s[i];
            }
            set
            {
                s[i] = value;
            }
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Str q=new Str();
            q[0] = 'a';
            q[1] = 'b';
            q[2] = 'c';

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(q[i]);
            }

        }
    }
}
