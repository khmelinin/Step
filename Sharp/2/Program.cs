using System;

namespace _2
{
    class Program
    {

        static void Main(string[] args)
        {
            /* 
             string[,] lt = new string[3, 3];
             string[,] arr = new string[2, 3];
             lt[0, 0] = "aaa";
             lt[0, 1] = "bbb";
             lt[0, 2] = "ccc";
             lt[1, 0] = "DDD";
             lt[1, 1] = "EEE";
             lt[1, 2] = "FFF";
             lt[2, 0] = "QQQ";
             lt[2, 1] = "WWW";
             lt[2, 2] = "SSS";

             for (int i = 0; i < 2; i++)
                 for (int j = 0; j < 3; j++)
                 {
                     arr[i, j] = lt[j, i];
                 }

             for (int i = 0; i < 3; i++)
             {
                 for (int j = 0; j < 3; j++)
                 {
                     Console.Write(lt[i, j] + " ");
                 }
                 Console.WriteLine();
             }
             Console.WriteLine();

             for (int i = 0; i < 2; i++)
             {
                 for (int j = 0; j < 3; j++)
                 {
                     Console.Write(arr[i, j]+" ");
                 }
                 Console.WriteLine();
             }
             
             */

            string[,] a = new string[,]{ { "23", "Product_1" }, { "45", "Product_2" }, { "64", "Product_3" } };
            int[,] b = new int[,] { { 45, 35 }, { 23, 67 }, { 64, 89 } };
            string[,] c = new string[3, 4];

            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 2; j++)
                    for (int ii = 0; ii < 3; ii++)
                        for (int jj = 0; jj < 2; jj++)
                        {
                            if (a[i, j] == Convert.ToString (b[ii, jj]))
                            {
                                c[i, j] = Convert.ToString(b[ii, jj]);
                                c[i, j + 1] = a[i, j + 1];
                                c[i, j + 2] = Convert.ToString(b[ii, jj + 1]);

                            }
                        }

            for (int i = 0; i < 3; i++)
            {
                c[i, 3] = "uah";
            }

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Console.Write(c[i, j]+ " ");
                }
                Console.WriteLine();
            }
            
        }
    }
}
