using System;

namespace _3DZ
{
    class Block
    {
        private int a, b, c, d;
        public Block(int aa, int bb, int cc, int dd)
        {
            a = aa;
            b = bb;
            c = cc;
            d = dd;
        }
        public override bool Equals(object obj)
        {
            if (obj == null || this.GetType() != obj.GetType())
                return false;
            Block p = (Block)obj;

            return this.a == p.a && this.b == p.b && this.c == p.c && this.d == p.d;
        }
        public override string ToString()
        {
            return "class Block";
        }

    }

    class House
    {
        private int id;
        private string family;
        public House(int i, string f)
        {
            id = i;
            family = f;
        }
        public int Id { get=>id; set=>id=value; }
        public string Family { get => family; set => family = value; }
        public House Clone()
        {
            return this;
        }
        public House DeepClone() 
        {
            House res = new House(this.id, this.family);
            return res;
        }

    }

    class Date
    {
        int day;
        int month;
        int year;
        int day_total;
        public int Day_total { get => day_total; }
        public Date(int d,int m,int y)
        {
            day = d;
            month = m;
            year = y;
            day_total = Day_Total();
        }
        public int Day_Total()
        {
            day_total = day;
            for (int i = 1; i < year; i++)
            {
                if (i % 100 == 0)
                    day_total += 365;
                else if (i % 1000 == 0 || i % 4 == 0)
                    day_total += 366;
                else
                    day_total += 365;
            }
            for (int i = 1; i < month; i++)
            {
                if (i == 1 - 1 || i == 3 - 1 || i == 5 - 1 || i == 7 - 1 || i == 8 - 1 || i == 10 - 1 || i == 12 - 1)
                    day_total += 31;
                else
                if (i == 2 - 1 && (year % 4 == 0 && year % 100 != 0 || year % 1000 == 0))
                    day_total += 29;
                else if (i == 2 - 1 && (year % 4 != 0 && year % 100 == 0 || year % 1000 != 0))
                    day_total += 28;
                else
                    day_total += 30;
            }
            return day_total;
        }
        public void Day_Total_Reverse()
        {
            int dt = day_total;
            year = 1;
            month = 1;
            day = 1;
            while (dt > 365)
            {
                if (year % 4 == 0 && year % 100 != 0 || year % 1000 == 0)
                {
                    year += 1;
                    dt -= 366;
                }
                else
                {
                    year += 1;
                    dt -= 365;
                }
            }
            if (year % 4 == 0 && year % 100 != 0 || year % 1000 == 0)
                while (dt > 29)
                {
                    if (month == 1 - 1 || month == 3 - 1 || month == 5 - 1 || month == 7 - 1 || month == 8 - 1 || month == 10 - 1 || month == 12 - 1)
                    {
                        dt -= 31;
                        month++;
                    }
                    else
                    if (month == 2 - 1)
                    {
                        dt -= 29;
                        month++;
                    }
                    else
                    {
                        dt -= 30;
                        month++;
                    }
                }
            else
                while (dt > 28)
                {
                    if (month == 1 - 1 || month == 3 - 1 || month == 5 - 1 || month == 7 - 1 || month == 8 - 1 || month == 10 - 1 || month == 12 - 1)
                    {
                        dt -= 31;
                        month++;
                    }
                    else
                    if (month == 2 - 1)
                    {
                        dt -= 28;
                        month++;
                    }
                    else
                    {
                        dt -= 30;
                        month++;
                    }
                }
            day = dt;

        }
        public void print()
        {
            Console.WriteLine(day+" "+month+" "+year);
        }
        public static Date operator -(Date a, Date b)
        {
            Date res = a.MemberwiseClone() as Date;
            res.day_total -= b.day_total;
            if(res.day_total>0)
            {
                res.Day_Total_Reverse();
            }
            else
            {
                res.day_total *= -1;
                res.Day_Total_Reverse();
                Console.WriteLine("b.c. case!");
            }
            return res;
        }
        public static Date operator +(Date a,int dd)
        {
            Date res = a.MemberwiseClone() as Date;
            res.day_total += dd;
            res.Day_Total_Reverse();
            return res;
        }
        public static Date operator +(int dd, Date a)
        {
            Date res = a.MemberwiseClone() as Date;
            res.day_total += dd;
            res.Day_Total_Reverse();
            return res;
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Block aB = new Block(3, 4, 3, 4);
            Block bB = new Block(4, 3, 4, 3);
            Block cB = new Block(3, 4, 3, 4);
            Console.WriteLine("a==b : " + aB.Equals(bB));
            Console.WriteLine("a==c : " + aB.Equals(cB));
            Console.WriteLine(aB);

            House aH = new House(11, "Armstrong");
            House bH = aH.Clone();
            House cH = aH.DeepClone();
            Console.WriteLine("aH : "+aH.Id+" "+aH.Family);
            Console.WriteLine("bH : " + bH.Id + " " + bH.Family);
            Console.WriteLine("cH : " + cH.Id + " " + cH.Family);
            aH.Id = 333;
            aH.Family = "Diaz";
            Console.WriteLine("aH : " + aH.Id + " " + aH.Family);
            Console.WriteLine("bH : " + bH.Id + " " + bH.Family);
            Console.WriteLine("cH : " + cH.Id + " " + cH.Family);

            Date aD = new Date(7, 4, 2020);
            Date bD = new Date(6, 5, 2019);
            Date cD = aD - bD;
            aD = aD + 33;
            aD.print();
            bD.print();
            cD.print();

        }
    }
}
