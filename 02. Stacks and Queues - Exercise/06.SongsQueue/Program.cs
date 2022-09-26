using System;
using System.Collections;
using System.Collections.Generic;

namespace _06.SongsQueue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] initialSongs = Console.ReadLine().Split(", ");
            Queue<string> songQueue = new Queue<string>(initialSongs);

            while (songQueue.Count > 0)
            {
                string[] cmd = Console.ReadLine().Split();

                switch (cmd[0])
                {
                    case "Play":
                        songQueue.Dequeue();
                        break;

                    case "Add":
                        string song = string.Join(' ', cmd, 1, cmd.Length - 1);

                        if (!songQueue.Contains(song))
                        {
                            songQueue.Enqueue(song);
                        }
                        else
                        {
                            Console.WriteLine($"{song} is already contained!");
                        }
                        break;

                    case "Show":
                        Console.WriteLine(string.Join(", ",songQueue));
                        break;
                }
            }

            Console.WriteLine("No more songs!");
        }
    }
}
