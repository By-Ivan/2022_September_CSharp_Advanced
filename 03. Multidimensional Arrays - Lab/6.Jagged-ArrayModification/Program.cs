using System;
using System.Linq;

namespace _6.Jagged_ArrayModification
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int[][] matrix = new int[rows][];

            for (int i = 0; i < rows; i++)
            {
                int[] currentRow = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

                matrix[i] = currentRow;
            }

            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] cmd = input.Split();
                string operation = cmd[0];
                int row = int.Parse(cmd[1]);
                int col = int.Parse(cmd[2]);
                int value = int.Parse(cmd[3]);

                if (
                    row >= 0 && col >= 0 &&
                    row <= matrix.Length - 1 &&
                    col <= matrix.Length - 1
                    )
                {
                    switch (operation)
                    {
                        case "Add":
                            matrix[row][col] += value;
                            break;

                        case "Subtract":
                            matrix[row][col] -= value;
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid coordinates");
                }

                input = Console.ReadLine();
            }

            for (int i = 0; i < rows; i++)
            {
                Console.WriteLine(String.Join(' ', matrix[i]));
            }
        }
    }
}
