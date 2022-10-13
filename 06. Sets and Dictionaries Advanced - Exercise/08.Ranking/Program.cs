using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace _08.Ranking
{
    public class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contests = new Dictionary<string, string>();
            Dictionary<string, Student> students = new Dictionary<string, Student>();

            string input = Console.ReadLine();

            while (input != "end of contests")
            {
                string[] cmd = input.Split(':');
                string contest = cmd[0];
                string pass = cmd[1];

                if (!contests.ContainsKey(contest))
                {
                    contests.Add(contest, String.Empty);
                }

                contests[contest] = pass;

                input = Console.ReadLine();
            }

            input = Console.ReadLine();

            while (input != "end of submissions")
            {
                string[] cmd = input.Split("=>");
                string contest = cmd[0];
                string pass = cmd[1];
                string username = cmd[2];
                int points = int.Parse(cmd[3]);

                Student student = new Student(username);

                if (contests.ContainsKey(contest))
                {
                    if (contests[contest] == pass)
                    {
                        if (!students.ContainsKey(username))
                        {
                            students.Add(username, student);
                        }

                        students[username].AddPoints(contest, points);
                    }
                }

                input = Console.ReadLine();
            }

            Student student1 = students.Select(x => x.Value).OrderByDescending(x => x.TotalPoints).First();

            Console.WriteLine($"Best candidate is {student1.Username} with total {student1.TotalPoints} points.");
            Console.WriteLine("Ranking:");

            foreach (Student student in students.Values.OrderBy(x=>x.Username))
            {
                Console.WriteLine($"{student.Username}");

                foreach (KeyValuePair<string,int> contest in student.Points.OrderByDescending(x=>x.Value))
                {
                    Console.WriteLine($"#  {contest.Key} -> {contest.Value}");
                }
            }
        }
    }

    internal class Student
    {
        public Student(string username)
        {
            Username = username;
        }

        public string Username { get; set; }

        public Dictionary<string, int> Points = new Dictionary<string, int>();

        public int TotalPoints 
        { 
            get
            {
                return Points.Values.Sum();
            }
        }

        public void AddPoints(string contest, int points)
        {
            if (!Points.ContainsKey(contest))
            {
                Points.Add(contest, 0);
            }

            if (points > Points[contest])
            {
                Points[contest] = points;
            }
        }
    }
}
