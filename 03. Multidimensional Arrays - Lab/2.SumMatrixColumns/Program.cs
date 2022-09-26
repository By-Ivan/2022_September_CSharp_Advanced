using System;
using System.Linq;

namespace _2.SumMatrixColumns
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSize = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int rows = matrixSize[0];
            int cols = matrixSize[1];
            int[,] matrix = new int[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                int[] currentRow = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int j = 0; j < currentRow.Length; j++)
                {
                    matrix[i, j] = currentRow[j];
                }
            }

            for (int i = 0; i < cols; i++)
            {
                int sum = 0;

                for (int j = 0; j < rows; j++)
                {
                    sum += matrix[j, i];
                }

                Console.WriteLine(sum);
            }
        }
    }
}
