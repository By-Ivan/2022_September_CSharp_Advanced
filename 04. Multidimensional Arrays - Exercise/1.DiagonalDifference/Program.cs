using System;
using System.Linq;

namespace _1.DiagonalDifference
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());
            int[,] matrix = new int[matrixSize, matrixSize];

            for (int i = 0; i < matrixSize; i++)
            {
                int[] currentRow = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int j = 0; j < matrixSize; j++)
                {
                    matrix[i, j] = currentRow[j];
                }
            }

            int sumLeft = 0;

            for (int i = 0; i < matrixSize; i++)
            {
                sumLeft += matrix[i, i];
            }

            int sumRight = 0;

            for (int i = 0; i < matrixSize; i++)
            {
                sumRight += matrix[i, matrixSize - 1 - i];
            }

            Console.WriteLine(Math.Abs(sumLeft - sumRight));
        }
    }
}
