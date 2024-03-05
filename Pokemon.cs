// Name: Ang Jun Jie James
// Admin Number: 214301S

using System;
using System.Collections.Generic;

namespace PokemonPocket
{
    public class PokemonMaster
    {
        public string Name { get; set; }
        public int NoToEvolve { get; set; }
        public string EvolveTo { get; set; }

        public PokemonMaster(string name, int noToEvolve, string evolveTo)
        {
            this.Name = name;
            this.NoToEvolve = noToEvolve;
            this.EvolveTo = evolveTo;
        }
    }

    class Pokemon
    {
        public string name { get; set; }
        public int hp { get; set; }
        public int exp { get; set; }
        public string skill { get; set; }
        public Pokemon(string name = "", int hp = 0, int exp = 0)
        {
            this.name = name;
            this.hp = hp;
            this.exp = exp;
        }
    }

    class Pikachu : Pokemon
    {
        public Pikachu(string name, int hp, int exp, string skill)
        : base(name, hp, exp)
        {
            this.skill = skill;
        }
    }

    class Charmander : Pokemon
    {
        public Charmander(string name, int hp, int exp, string skill)
        : base(name, hp, exp)
        {
            this.skill = skill;
        }
    }

    class Eevee : Pokemon
    {
        public Eevee(string name, int hp, int exp, string skill)
        : base(name, hp, exp)
        {
            this.skill = skill;
        }
    }

    class NewPokemon : Pokemon
    {
        public NewPokemon(string name, int hp, int exp, string skill)
        : base(name, hp, exp)
        {
            this.skill = skill;
        }
    }

    class Inventory
    {
        public string itemName {get;set;}
        public int itemNo {get;set;}

        public Inventory(string itemName)
        {
            this.itemName = itemName;
            this.itemNo = itemNo;
        }
    }

    class Berry : Inventory
    {
        public Berry(string itemName, int itemNo)
        : base(itemName)
        {
            this.itemNo = itemNo;
        }
    }

    class Pokeball : Inventory
    {
        public Pokeball(string itemName, int itemNo)
        : base(itemName)
        {
            this.itemNo = itemNo;
        }
    }

    class ReviveCrystal : Inventory
    {
        public ReviveCrystal(string itemName, int itemNo)
        : base(itemName)
        {
            this.itemNo = itemNo;
        }
    }
}