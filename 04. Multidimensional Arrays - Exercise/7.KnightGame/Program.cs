using System;
using System.Collections.Generic;
using System.Numerics;

namespace _7.KnightGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] chessBoard = new char[n, n];

            for (int i = 0; i < n; i++)
            {
                char[] currentRow = Console.ReadLine().ToCharArray();

                for (int j = 0; j < n; j++)
                {
                    chessBoard[i, j] = currentRow[j];
                }
            }


            int maxCounter = 0;
            int[] knight = new int[2];
            int removed = 0;

            while (true)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        int counter = 0;

                        if (chessBoard[i, j] == 'K')
                        {
                            int[] temp = new int[] { i, j };

                            if (i < n - 1 && j > 1)
                            {
                                if (chessBoard[i + 1, j - 2] == 'K')
                                {
                                    counter++;
                                }
                            }

                            if (i < n - 1 && j < n - 2)
                            {
                                if (chessBoard[i + 1, j + 2] == 'K')
                                {
                                    counter++;
                                }
                            }

                            if (i > 0 && j > 1)
                            {
                                if (chessBoard[i - 1, j - 2] == 'K')
                                {
                                    counter++;
                                }
                            }

                            if (i > 0 && j < n - 2)
                            {
                                if (chessBoard[i - 1, j + 2] == 'K')
                                {
                                    counter++;
                                }
                            }

                            if (i < n - 2 && j > 0)
                            {
                                if (chessBoard[i + 2, j - 1] == 'K')
                                {
                                    counter++;
                                }
                            }

                            if (i < n - 2 && j < n - 1)
                            {
                                if (chessBoard[i + 2, j + 1] == 'K')
                                {
                                    counter++;
                                }
                            }

                            if (i > 1 && j > 0)
                            {
                                if (chessBoard[i - 2, j - 1] == 'K')
                                {
                                    counter++;
                                }
                            }

                            if (i > 1 && j < n - 1)
                            {
                                if (chessBoard[i - 2, j + 1] == 'K')
                                {
                                    counter++;
                                }
                            }

                            if (counter > maxCounter)
                            {
                                maxCounter = counter;
                                knight[0] = i;
                                knight[1] = j;
                            }
                        }
                    }
                }

                if (maxCounter > 0)
                {
                    chessBoard[knight[0], knight[1]] = '0';
                    removed++;
                    maxCounter = 0;
                }
                else
                {
                    break;
                }
            }

            Console.WriteLine(removed);
        }
    }
}
