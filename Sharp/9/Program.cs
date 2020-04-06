using System;

namespace _9
{
    class Point : object
    {
        protected int x, y;
        public Point(int xx, int yy)
        {
            x = xx;
            y = yy;
        }
        public override bool Equals(object obj)
        {
            if (obj == null || this.GetType() != obj.GetType())
                return false;
            Point p = (Point)obj;

            return (x == p.x) && (y == p.y);
        }
        public override int GetHashCode()
        {
            return x - y;
        }
    }

    class MyBaseClass
    {
        public static string CompanyName = "MS";
        public int age;
        public string name;
    }

    class A { public int a = 1; }
    class B { public int b = 2; }
    class C { public B B = new B(); }
    class X
    {
        public A A = new A();
        public C C = new C();
    }


    //class MyDerivedClass:MyBaseClass
    class Program : X
    {
        static void Main(string[] args)
        {
            /*
            Object a = new Point(-10, -1);
            Object b = new Point(-10, -1);
            Object c = new Point(10, 0);

            Console.WriteLine("a == b : {0}",a.Equals(b));
            Console.WriteLine("HashA : {0}",a.GetHashCode());
            Console.WriteLine("HashB : {0}",b.GetHashCode());
            Console.WriteLine("HashC : {0}",c.GetHashCode());
            */
            /*
            MyDerivedClass original = new MyDerivedClass();
            original.age = 24;
            original.name = "Alyx";
            MyDerivedClass.CompanyName = "Black Mesa";
            Console.WriteLine(original.age + " " + original.name + " " + MyDerivedClass.CompanyName);
            MyDerivedClass clone = original.MemberwiseClone() as MyDerivedClass;
            clone.age = 43;
            clone.name = "Gordon";
            Console.WriteLine(clone.age + " " + clone.name + " " + MyDerivedClass.CompanyName);
            */
            /*
            Program original = new Program();
            Console.WriteLine("original : "+original.A.a+" "+original.C.B.b);
            Program clone = original.MemberwiseClone() as Program;
            Console.WriteLine("clone : " + clone.A.a + " " + clone.C.B.b);
            clone.A.a = clone.C.B.b = 7;
            Console.WriteLine("original : " + original.A.a + " " + original.C.B.b);
            Console.WriteLine("clone : " + clone.A.a + " " + clone.C.B.b);
            original.A.a = original.C.B.b = 3;
            Console.WriteLine("original : " + original.A.a + " " + original.C.B.b);
            Console.WriteLine("clone : " + clone.A.a + " " + clone.C.B.b);
            */


        }
    }
}

