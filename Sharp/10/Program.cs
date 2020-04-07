using System;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;

namespace _10
{
    class MyClass
    {
        int a, b;
        public MyClass()
        {
            Thread.Sleep(1000);
            a = new Random().Next(1, 10);
            Thread.Sleep(1000);
            b = new Random().Next(1, 10);
        }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }

    class info
    {
        int id;
        public int Id { get => id; set => id = value; }
        public info(int i)
        {
            id = i;
        }
    }
    class Person
    {
        info idinfo;
        string name;
        public info IdInfo{ get => idinfo; }
        public string Name { get => name; }
        public Person(info i, string n)
        {
            idinfo = i;
            name = n;
        }
        public Person DeepClone()
        {
            Person res = (Person)this.MemberwiseClone();
            res.idinfo = new info(this.idinfo.Id);
            return res;

        }

        public Person Clone()
        {
            return (Person)this.MemberwiseClone();
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            /*
            Stopwatch timer=new Stopwatch();
            timer.Start();
            MyClass original = new MyClass();
            timer.Stop();
            Console.WriteLine("original builded by {0}",timer.Elapsed.Ticks);
            timer.Reset();
            timer.Start();
            MyClass clone = original.Clone() as MyClass;
            timer.Stop();
            Console.WriteLine("clone builded by {0}", timer.Elapsed.Ticks);
            */

            Person A = new Person(new info(15), "A");
            Person B = A.Clone();
            Console.WriteLine(A.IdInfo.Id+" "+A.Name);
            B.IdInfo.Id = 7;
            Person C = A.DeepClone();
            C.IdInfo.Id = 17;
            Console.WriteLine();
            Console.WriteLine(A.IdInfo.Id + " " + A.Name);
            Console.WriteLine(B.IdInfo.Id + " " + B.Name);
            Console.WriteLine(C.IdInfo.Id + " " + C.Name);
        }
    }
}
