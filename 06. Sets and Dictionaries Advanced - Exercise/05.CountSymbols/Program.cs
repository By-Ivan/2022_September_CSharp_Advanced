using System;
using System.Collections.Generic;

namespace _05.CountSymbols
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<char, int> characters = new SortedDictionary<char, int>();

            foreach (char ch in Console.ReadLine())
            {
                if (!characters.ContainsKey(ch))
                {
                    characters.Add(ch, 0);
                }

                characters[ch]++;
            }

            foreach (KeyValuePair<char,int> ch in characters)
            {
                Console.WriteLine($"{ch.Key}: {ch.Value} time/s");
            }
        }
    }
}
