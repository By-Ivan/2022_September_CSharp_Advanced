using System;
using System.Collections.Generic;
using System.Linq;

namespace _5.SnakeMoves
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Dimensions are in range [1...12]
            int[] dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rows = dimensions[0];
            int cols = dimensions[1];
            char[,] matrix = new char[rows, cols];
            // Snake is in range [1...20]
            string snake = Console.ReadLine();
            int counter = 0;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    int k = i % 2 != 0 ? cols - 1 - j : j;

                    int x = counter % snake.Length;

                    matrix[i, k] = snake[x];
                    counter++;
                }
            }

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(matrix[i, j]);
                }

                Console.WriteLine();
            }
        }
    }
}
