using System;
using System.Linq;

namespace _4.MatrixShuffling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rows = size[0];
            int cols = size[1];
            string[,] matrix = new string[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                string[] currentRow = Console.ReadLine().Split();

                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = currentRow[j];
                }
            }

            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] cmd = input.Split();

                if (cmd[0] != "swap" || cmd.Length < 5)
                {
                    Console.WriteLine("Invalid input!");
                }
                else
                {
                    int row1, col1, row2, col2 = 0;
                    bool valid1 = int.TryParse(cmd[1], out row1);
                    bool valid2 = int.TryParse(cmd[2], out col1);
                    bool valid3 = int.TryParse(cmd[3], out row2);
                    bool valid4 = int.TryParse(cmd[4], out col2);

                    if (valid1 && valid2 && valid3 && valid4)
                    {
                        if (row1 >= 0 && row1 <= rows && col1 >= 0 && col1 <= cols && row2 >= 0 && row2 <= rows && col2 >= 0 && col2 <= cols)
                        {
                            string buffer = matrix[row1, col1];

                            matrix[row1, col1] = matrix[row2, col2];
                            matrix[row2, col2] = buffer;

                            for (int i = 0; i < rows; i++)
                            {
                                for (int j = 0; j < cols; j++)
                                {
                                    Console.Write($"{matrix[i, j]} ");
                                }

                                Console.WriteLine();
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid input!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input!");
                    }
                }

                input = Console.ReadLine();
            }
        }
    }
}
