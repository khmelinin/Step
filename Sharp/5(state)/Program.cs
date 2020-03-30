using System;

namespace _5_state_
{
    class Program
    {
        static void Main(string[] args)
        {
            State n = new Normal();
            Father a= new Father(n);
            a.Request(2);
            a.Request(2);
            a.Request(2);
            a.Request(5);
            a.Request(2);
            a.Request(5);
            a.Request(5);
            a.Request(5);

        }
    }
}
