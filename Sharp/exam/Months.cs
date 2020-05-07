using System;
using System.Collections.Generic;
using System.Text;

namespace exam
{
    class Months
    {
        string[] months = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
        int[] days = { 31,28,31,30,31,30,31,31,30,31,30,31};
        public void MonthsIndex(int i)
        {
            try
            {
                if (i > 0 && i < 13)
                {
                    Console.WriteLine(months[i-1]);
                }
                else
                {
                    throw new Exception("!!!we have only 12 months!!!");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void MonthsDays(int i)
        {
            try
            {
                if (i > 27 && i < 32)
                {
                    for (int j = 0; j < 12; j++)
                    {
                        if (days[j] == i)
                        {
                            Console.Write(months[j] + " ");
                        }
                    }
                    Console.WriteLine();
                }
                else
                {
                    throw new Exception("!!!we have no months with >31 days and >28 days!!!");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
