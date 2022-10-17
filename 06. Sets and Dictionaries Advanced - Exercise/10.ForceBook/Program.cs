using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.ForceBook
{
    public class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> users = new Dictionary<string, string>();
            Dictionary<string, List<string>> sides = new Dictionary<string, List<string>>();

            string input = Console.ReadLine();

            while (input != "Lumpawaroo")
            {
                string[] cmd = input.Split(new string[] {" | ", " -> "}, StringSplitOptions.RemoveEmptyEntries);

                if (input.Contains(" | "))
                {
                    users = AddForceUser(users, cmd);
                }
                else
                {
                    users = SwitchSides(users, cmd);
                }

                input = Console.ReadLine();
            }

            foreach (KeyValuePair<string,string> user in users)
            {
                if (!sides.ContainsKey(user.Value))
                {
                    sides.Add(user.Value,new List<string>());
                }

                sides[user.Value].Add(user.Key);
            }

            foreach (KeyValuePair<string, List<string>> side in sides.OrderByDescending(x=>x.Value.Count).ThenBy(x=>x.Key))
            {
                Console.WriteLine($"Side: {side.Key}, Members: {side.Value.Count}");

                foreach (string user in side.Value.OrderBy(x=>x))
                {
                    Console.WriteLine($"! {user}");
                }
            }
        }

        private static Dictionary<string, string> SwitchSides(Dictionary<string, string> users, string[] cmd)
        {
            string forceUser = cmd[0];
            string forceSide = cmd[1];

            if (!users.ContainsKey(forceUser))
            {
                users.Add(forceUser, forceSide);
            }
            else
            {
                users[forceUser] = forceSide;
            }

            Console.WriteLine($"{forceUser} joins the {forceSide} side!");

            return users;
        }

        private static Dictionary<string, string> AddForceUser(Dictionary<string, string> users, string[] cmd)
        {
            string forceSide = cmd[0];
            string forceUser = cmd[1];

            if (!users.ContainsKey(forceUser))
            {
                users.Add(forceUser, forceSide);
            }

            return users;
        }
    }
}
