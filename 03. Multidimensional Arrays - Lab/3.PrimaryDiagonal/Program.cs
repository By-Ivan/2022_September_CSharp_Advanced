using System;
using System.Linq;

namespace _3.PrimaryDiagonal
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

            int sum = 0;

            for (int i = 0; i < matrixSize; i++)
            {
                sum += matrix[i,i];
            }

            Console.WriteLine(sum);
        }
    }
}
