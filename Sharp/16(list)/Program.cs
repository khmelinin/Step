using System;

namespace _16_list_
{
    class MyList<T>
    {
        T[] field;
        public MyList()
        {
            field = new T[0];
        }
        public T this[int i]
        {
            get => field[i];
            set => field[i] = value;
        }
        public void Add(T val)
        {

            T[] tmp = new T[field.Length + 1];
            for (int i = 0; i < field.Length; i++)
            {
                tmp[i] = field[i];
            }
            tmp[tmp.Length - 1] = val;
            field = tmp;
        }
        public int getSize()
        {
            return field.Length;
        }
        public void print()
        {
            if (field.Length==0)
                Console.WriteLine("empty");
            else
            for (int i = 0; i < field.Length; i++)
            {
                Console.WriteLine(field[i]);
            }
        }
        public void Clear()
        {
            field = new T[0];
        }
    }

    class CarCollection
    {
        MyList<DateTime> year;
        MyList<string> name;
        public CarCollection()
        {
            year = new MyList<DateTime>();
            name = new MyList<string>();
        }
        public string this[int i]
        {
            get { return name[i] +" "+ year[i].ToString(); }
        }
       
        public void AddCar(DateTime dt, string s)
        {
            year.Add(dt);
            name.Add(s);
        }
        public void print()
        {
            for (int i = 0; i < year.getSize(); i++)
            {
                Console.WriteLine(this[i]);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            /*
            MyList<int> a = new MyList<int>();
            a.Add(3);
            a.Add(6);
            a.print();
            a.Clear();
            a.Clear();
            a.print();
            */
            CarCollection a=new CarCollection();
            a.AddCar(DateTime.Now, "GTR_R34");
            a.AddCar(DateTime.Now, "Chellenger_RT");
            a.print();
        }
    }
}
