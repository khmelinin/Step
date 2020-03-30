using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1DZ
{
    class Program
    {
        static void Method1()
        {
            Console.WriteLine("enter text: ");
            char input;
            int count = 0;
            do
            {
                input = Console.ReadKey().KeyChar;
                if (input == ' ')
                    count++;
            }
            while (input != '.');
            Console.WriteLine();
            Console.WriteLine("count of spaces: " + count);

        }
        static void Method2()
        {
            string n = Console.ReadLine();
            int[] numbers=new int[n.Length];
            for (int i = 0; i < n.Length; i++)
            {
                numbers[i] = Convert.ToInt32(n[i]);
            }
            if(numbers[0]+ numbers[1]+ numbers[2]== numbers[numbers.Length-1]+ numbers[numbers.Length - 2] + numbers[numbers.Length - 3])
                Console.WriteLine("Lucky number");
            else
                Console.WriteLine("common number");
        }

        static void Method3()
        {
            string s = Console.ReadLine();
            char[] c = new char[s.Length];
            for (int i = 0; i < s.Length; i++)
            {
                if(s[i]>=65 && s[i]<=90)
                {
                    c[i]=Convert.ToChar(s[i]+32);
                }
                if(s[i] >= 97 && s[i] <= 122)
                {
                    c[i] = Convert.ToChar(s[i] - 32);
                }
            }
            Console.WriteLine(c);

        }

        static void Method4()
        {
            int[] n = new int[] { 1,3,6,8};
            for (int i = 0; i < n.Length; i++)
            {
                for (int j = n[i]; j > 0; j--)
                {
                    Console.Write(n[i]);
                    Console.Write(' ');
                }
                Console.WriteLine();
            }
        }

        static void Method5()
        {
            int n = 56789;
            string s = Convert.ToString(n);
            char[] res=new char[s.Length];
            
            for (int i = 0; i < s.Length; i++)
            {
                res[res.Length - i-1] = s[i];
            }
            Console.WriteLine(res);
        }
        static void Main(string[] args)
        {
            Method1();
            Method2();
            Method3();
            Method4();
            Method5();
            
        }
    }
}
