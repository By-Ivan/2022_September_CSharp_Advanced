using System;
using System.Collections.Generic;
using System.Text;

namespace _09.PokemonTrainer
{
    public class Trainer
    {
        public Trainer(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
        public int Badges { get; set; } = 0;

        public List<Pokemon> Pokemons { get; set; } = new List<Pokemon>();

        public void DecreaseHealth()
        {
            List<Pokemon> output = new List<Pokemon>();

            foreach (Pokemon pokemon in Pokemons)
            {
                pokemon.Health -= 10;

                if (pokemon.Health > 0)
                {
                    output.Add(pokemon);
                }
            }

            Pokemons = output;
        }
    }
}
