using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace exam
{
    class MyMatrix
    {
        int x;
        int y;
        int [,]matrix;
        public MyMatrix(int x, int y)
        {
            this.x = x;
            this.y = y;
            matrix = new int[x, y];
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    matrix[i, j] = new Random().Next(0,9);
                }
            }
        }

        public void print()
        {
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    Console.Write(matrix[i, j]);
                    Console.Write(" ");
                }
                Console.Write("\n");
            }
        }

        public void Resize(int xx, int yy)
        {
            int[,] tmp = matrix;
            matrix = new int[xx, yy];
            for (int i = 0; i < xx; i++)
            {
                for (int j = 0; j < yy; j++)
                {
                    matrix[i, j] = new Random().Next(0, 9);
                }
            }

            if(xx>x && yy>y)
                for (int i = 0; i < x; i++)
                {
                    for (int j = 0; j < y; j++)
                    {
                        matrix[i, j] = tmp[i,j];
                    }
                }
            else
                for (int i = 0; i < xx; i++)
                {
                    for (int j = 0; j < yy; j++)
                    {
                        matrix[i, j] = tmp[i, j];
                    }
                }

            x = xx;
            y = yy;
        }
        
        
        
    }
}
