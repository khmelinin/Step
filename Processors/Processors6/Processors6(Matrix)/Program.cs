using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Processors6_Matrix_
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] A = new int[2, 3];
            int[,] B = new int[3, 4];
            int[,] C = new int[2, 4];

            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    C[i, j] = 0;
                    for (int k = 0; k < 3; k++)
                    {
                        C[i, j] += A[i, k] * B[k, j];
                    }
                }
            }
        }
    }
}
