using System;

namespace _14
{
    class My_Class
    {
        private int[] nums = new int[10];
        public My_Class()
        {
            for (int i = 0; i < 10; i++)
            {
                if (i % 2 == 0)
                    nums[i] = -i;
                else
                    nums[i] = i;
            }
        }
       
        public int Where(Predicate<int> aa)
        {
            int r = 0;
            for (int i = 0; i < 10; i++)
            {
                if (aa(nums[i]))
                {
                    r++;
                }
            }
            return r;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            My_Class a = new My_Class();
            int res = a.Where(x => x > 0);
            Console.WriteLine(res);
            res = a.Where(x => { x *= 2; return x * 3 % 2 == 0; });
        }
    }
}
