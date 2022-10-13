using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.SoftUniExamResults
{
    public class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> submissions = new Dictionary<string, int>();
            Dictionary<string, int> students = new Dictionary<string, int>();

            string input = Console.ReadLine();

            while (input != "exam finished")
            {
                string[] cmd = input.Split('-');
                string username = cmd[0];

                if (cmd[1] == "banned")
                {
                    students.Remove(username);
                }
                else
                {
                    string language = cmd[1];
                    int points = int.Parse(cmd[2]);

                    if (!submissions.ContainsKey(language))
                    {
                        submissions.Add(language, 0);
                    }

                    submissions[language]++;

                    if (!students.ContainsKey(username))
                    {
                        students.Add(username, 0);
                    }

                    if (points > students[username])
                    {
                        students[username] = points;
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine("Results:");

            foreach (KeyValuePair<string,int> student in students.OrderByDescending(x=>x.Value).ThenBy(x=>x.Key))
            {
                Console.WriteLine($"{student.Key} | {student.Value}");
            }

            Console.WriteLine("Submissions:");

            foreach (KeyValuePair<string,int> submission in submissions.OrderByDescending(x=>x.Value).ThenBy(x=>x.Key))
            {
                Console.WriteLine($"{submission.Key} - {submission.Value}");
            }
        }
    }
}
