using System;

namespace _7.PascalTriangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            long[][] pascal = new long[n][];

            if (n == 1)
            {
                Console.WriteLine("1");
                return;
            }

            for (int i = 0; i < n; i++)
            {
                pascal[i] = new long[i+1];
            }

            for (int i = 0; i < n; i++)
            {
                pascal[i][0] = 1;
            }

            pascal[1][1] = 1;

            for (int row = 2; row < n; row++)
            {
                for (int col = 1; col < row; col++)
                {
                    pascal[row][col] = pascal[row - 1][col] + pascal[row - 1][col - 1];
                }

                pascal[row][row] = 1;
            }

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(String.Join(' ', pascal[i]));
            }
        }
    }
}
