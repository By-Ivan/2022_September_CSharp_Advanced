using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace _07.TheV_Logger
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Vlogger> vloggers = new List<Vlogger>();

            string input = Console.ReadLine();

            while (input != "Statistics")
            {
                string[] cmd = input.Split();
                string username = cmd[0];
                string operation = cmd[1];

                switch (operation)
                {
                    case "joined":

                        if (vloggers.FirstOrDefault(x=>x.Username == username) == null)
                        {
                            vloggers.Add(new Vlogger(username));
                        }

                        break;

                    case "followed":
                        string followedVloggerUsername = cmd[2];
                        Vlogger followingVlogger = vloggers.FirstOrDefault(x => x.Username == username);
                        Vlogger followedVlogger = vloggers.FirstOrDefault(x => x.Username == followedVloggerUsername);

                        if (
                            followingVlogger != null &&
                            followedVlogger != null &&
                            followingVlogger != followedVlogger
                            )
                        {
                            if (!followingVlogger.Following.Contains(followedVlogger))
                            {
                                followingVlogger.Following.Add(followedVlogger);
                                followedVlogger.Followers.Add(followingVlogger);
                            }
                        }

                        break;
                }

                input = Console.ReadLine();
            }

            vloggers = vloggers.OrderByDescending(x => x.Followers.Count).ThenBy(x => x.Following.Count).ToList();

            Console.WriteLine($"The V-Logger has a total of {vloggers.Count} vloggers in its logs.");

            for (int i = 0; i < vloggers.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {vloggers[i].Username} : {vloggers[i].Followers.Count} followers, {vloggers[i].Following.Count} following");

                if (i == 0)
                {
                    foreach (Vlogger vlogger in vloggers[i].Followers.OrderBy(x=>x.Username))
                    {
                        Console.WriteLine($"*  {vlogger.Username}");
                    }
                }
            }
        }
    }

    public class Vlogger
    {
        public Vlogger(string username)
        {
            Username = username;
            Followers = new HashSet<Vlogger>();
            Following = new HashSet<Vlogger>();
        }
        public string Username { get; set; }
        public HashSet<Vlogger> Followers { get; set; }
        public HashSet<Vlogger> Following { get; set; }

    }
}
