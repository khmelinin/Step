using System;

namespace _9_operators_overload_
{
    public class Point
    {
        private int x, y;
        public Point(int xPos, int yPos)
        {
            x = xPos;
            y = yPos;
        }
        public override string ToString()
        {
            return string.Format("[{0}, {1}]",this.x,this.y);
        }

        public static Point operator +(Point a, Point b)
        {
            return new Point(a.x + b.x, a.y + b.y);
        }
        public static Point operator -(Point a, Point b)
        {
            return new Point(a.x - b.x, a.y - b.y);
        }
        public static Point operator *(Point a, Point b)
        {
            return new Point(a.x * b.x, a.y * b.y);
        }
        public static Point operator /(Point a, Point b)
        {
            return new Point(a.x / b.x, a.y / b.y);
        }

        public static Point operator ++(Point a)
        {
            return new Point(a.x +1, a.y +1);
        }
        public static Point operator --(Point a)
        {
            return new Point(a.x - 1, a.y - 1);
        }
        public static bool operator ==(Point a,Point b)
        {
            return a.Equals(b);
        }
        public static bool operator !=(Point a, Point b)
        {
            return !a.Equals(b);
        }
        public int CompareTo(object obj)
        {
            if(obj is Point)
            {
                Point p = (Point)obj;
                if (this.x > p.x && this.y > p.y)
                    return 1;

                else if (this.x < p.x && this.y < p.y)
                    return -1;
                else 
                    return 0;
            }
            else
            {
                throw new ArgumentException();
            }
        }
        public static bool operator <(Point a, Point b)
        {
            return (a.CompareTo(b)<0);
        }
        public static bool operator >(Point a, Point b)
        {
            return (a.CompareTo(b) > 0);
        }

    }
        class Program
    {
        static void Main(string[] args)
        {
            Point a = new Point(1, 3);
            Point b = new Point(6, 7);
            a++;
            Point c = a + b;
            Console.WriteLine(c);
        }
    }
}
