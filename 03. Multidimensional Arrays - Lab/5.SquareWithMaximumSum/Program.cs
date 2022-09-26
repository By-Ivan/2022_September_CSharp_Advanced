using System;
using System.Linq;

namespace _5.SquareWithMaximumSum
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
                int[] currentRow = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

                for (int j = 0; j < currentRow.Length; j++)
                {
                    matrix[i, j] = currentRow[j];
                }
            }

            int maxSum = 0;
            int[,] submatrix = new int[2, 2];

            for (int i = 0; i < rows - 1; i++)
            {
                for (int j = 0; j < cols - 1; j++)
                {
                    int sum = matrix[i, j] + matrix[i, j + 1] + matrix[i + 1, j] + matrix[i + 1, j + 1];

                    if (sum > maxSum)
                    {
                        maxSum = sum;

                        submatrix[0, 0] = matrix[i, j];
                        submatrix[0, 1] = matrix[i, j + 1];
                        submatrix[1, 0] = matrix[i + 1, j];
                        submatrix[1, 1] = matrix[i + 1, j + 1];
                    }
                }
            }

            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    Console.Write($"{submatrix[i, j]} ");
                }

                Console.WriteLine();
            }

            Console.WriteLine(maxSum);
        }
    }
}
