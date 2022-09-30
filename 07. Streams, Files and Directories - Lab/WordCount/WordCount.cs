namespace WordCount
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class WordCount
    {
        static void Main()
        {
            string wordPath = @"..\..\..\Files\words.txt";
            string textPath = @"..\..\..\Files\text.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            CalculateWordCounts(wordPath, textPath, outputPath);
        }

        public static void CalculateWordCounts(string wordsFilePath, string textFilePath, string outputFilePath)
        {
            Dictionary<string, int> searchedWordsCount = new Dictionary<string, int>();

            using (StreamReader reader = new StreamReader(wordsFilePath))
            {
                while (!reader.EndOfStream)
                {
                    string[] line = reader.ReadLine().Split(' ');

                    foreach (string str in line)
                    {
                        searchedWordsCount.Add(str, 0);
                    }
                }

                reader.Close();
            }

            string[] searchedWords = searchedWordsCount.Keys.ToArray();

            string words = String.Empty;

            using (StreamReader reader = new StreamReader(textFilePath))
            {
                words = reader.ReadToEnd();
                reader.Close();
            }

            for (int i = 0; i < searchedWords.Length; i++)
            {
                Regex regex = new Regex($"{searchedWords[i]}");
                searchedWordsCount[searchedWords[i]] = regex.Matches(words).Count;
            }
            

            using (StreamWriter writer = new StreamWriter(outputFilePath))
            {
                foreach (KeyValuePair<string,int> keyValuePair in searchedWordsCount.OrderByDescending(x=>x.Value))
                {
                    writer.WriteLine($"{keyValuePair.Key} - {keyValuePair.Value}");
                }

                writer.Close();
            }
        }
    }
}
