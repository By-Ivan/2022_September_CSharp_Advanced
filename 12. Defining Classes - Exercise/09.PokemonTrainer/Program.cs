using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.PokemonTrainer
{
    public class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Dictionary<string, Trainer> trainers = new Dictionary<string, Trainer>();

            while (input != "Tournament")
            {
                string[] info = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string trainerName = info[0];
                string pokemonName = info[1];
                string pokemonElement = info[2];
                int pokemonHealth = int.Parse(info[3]);

                Pokemon pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);

                if (!trainers.ContainsKey(trainerName))
                {
                    trainers.Add(trainerName, new Trainer(trainerName));
                }

                trainers[trainerName].Pokemons.Add(pokemon);

                input = Console.ReadLine();
            }

            input = Console.ReadLine();

            while (input != "End")
            {
                foreach (Trainer trainer in trainers.Values)
                {
                    if (trainer.Pokemons.Select(x => x.Element).Contains(input))
                    {
                        trainers[trainer.Name].Badges++;
                    }
                    else
                    {
                        trainers[trainer.Name].DecreaseHealth();
                    }
                }

                input = Console.ReadLine();
            }

            foreach (Trainer trainer in trainers.Values.OrderByDescending(x=>x.Badges))
            {
                Console.WriteLine($"{trainer.Name} {trainer.Badges} {trainer.Pokemons.Count}");
            }
        }
    }
}
