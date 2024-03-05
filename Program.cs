// Name: Ang Jun Jie James
// Admin Number: 214301S

using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonPocket
{
    class Program
    {
        static void Main(string[] args)
        {
            //PokemonMaster list for checking pokemon evolution availability.    
            List<PokemonMaster> pokemonMasters = new List<PokemonMaster>(){
            new PokemonMaster("Pikachu", 2, "Raichu"),
            new PokemonMaster("Eevee", 3, "Flareon"),
            new PokemonMaster("Charmander", 1, "Charmeleon")
            };

            // List Creation
            List<Pokemon> pokemonList = new List<Pokemon>();
            List<Berry> berryList = new List<Berry>();
            List<Pokeball> pokeballList = new List<Pokeball>();
            List<ReviveCrystal> reviveCrystalList = new List<ReviveCrystal>();
            int PokeCoin = 0;

            while (true) // while loop to loop options until Q is entered
            {
                Console.WriteLine("");
                Console.WriteLine("*****************************");
                Console.WriteLine("Welcome to Pokemon Pocket App");
                Console.WriteLine("*****************************");
                Console.WriteLine("(1). Add pokemon to my pocket");
                Console.WriteLine("(2). List pokemon(s) in my Pocket");
                Console.WriteLine("(3). Check if I can evolve pokemon");
                Console.WriteLine("(4). Evolve pokemon");
                Console.WriteLine("(5). Check PokeShop");
                Console.WriteLine("(6). View Inventory\n");
                Console.Write("Please only enter [1,2,3,4,5,6] or Q to quit: ");

                string menu = Convert.ToString(Console.ReadLine());
                string skill = "";
                Random rnd = new Random();
                int coinsGained = rnd.Next(1, 101);  // creates a random number between 1 and 100

                if (menu == "1")
                {
                    while (true)
                    {
                        Console.Write("Enter Pokemon's Name: "); // User enters pokemon information here
                        string name = Console.ReadLine();

                        int hp;
                        Console.Write("Enter Pokemon's HP: ");
                        while (!int.TryParse(Console.ReadLine(), out hp))
                        {
                            Console.WriteLine("This is not a valid input. Please enter an integer value.");
                            Console.Write("Enter Pokemon's HP: ");
                        }

                        int exp;
                        Console.Write("Enter Pokemons's EXP: ");
                        while (!int.TryParse(Console.ReadLine(), out exp))
                        {
                            Console.WriteLine("This is not a valid input. Please enter an integer value.");
                            Console.Write("Enter Pokemon's EXP: ");
                        }

                        if (name.ToLower() == pokemonMasters[0].Name.ToLower()) // Check if pokemon exists, if exist adds pokemon.
                        {
                            skill = "Lightning Bolt";
                            var tmpCharacter = new Pikachu(pokemonMasters[0].Name, hp, exp, skill);
                            pokemonList.Add(tmpCharacter);
                            Console.WriteLine("Pokemon has been added!");
                            PokeCoin = PokeCoin + coinsGained;
                            Console.WriteLine($"You have gained {coinsGained} Pokecoins!");
                            break;
                        }

                        else if (name.ToLower() == pokemonMasters[1].Name.ToLower())
                        {
                            skill = "Run Away";
                            var tmpCharacter = new Eevee(pokemonMasters[1].Name, hp, exp, skill);
                            pokemonList.Add(tmpCharacter);
                            Console.WriteLine("Pokemon has been added!");
                            PokeCoin = PokeCoin + coinsGained;
                            Console.WriteLine($"You have gained {coinsGained} Pokecoins!");
                            break;
                        }

                        else if (name.ToLower() == pokemonMasters[2].Name.ToLower())
                        {
                            skill = "Solar Power";
                            var tmpCharacter = new Charmander(pokemonMasters[2].Name, hp, exp, skill);
                            pokemonList.Add(tmpCharacter);
                            Console.WriteLine("Pokemon has been added!");
                            PokeCoin = PokeCoin + coinsGained;
                            Console.WriteLine($"You have gained {coinsGained} Pokecoins!");
                            break;
                        }

                        else // Additional Feature: User enters new pokemon and able to add to list
                        {
                            Console.Write("You have entered a pokemon not in our database, would you like to add it? (Y/N): ");
                            string AddPokemon = Console.ReadLine();
                            if (AddPokemon.ToUpper() == "Y")
                            {
                                Console.Write("Enter Pokemon's Skill: ");
                                string newSkill = Console.ReadLine();
                                var tmpCharacter = new NewPokemon(name, hp, exp, newSkill);
                                pokemonList.Add(tmpCharacter);
                                Console.WriteLine("Your new Pokemon has been added!");
                                PokeCoin = PokeCoin + coinsGained;
                                Console.WriteLine($"You have gained {coinsGained} Pokecoins!");
                                break;
                            }

                            else if (AddPokemon.ToUpper() == "N") 
                            {
                                break;
                            }

                            else
                            {
                                Console.WriteLine("Invalid Option!");
                            }
                        }
                    }
                }

                else if (menu == "2")
                {

                    var sortedList = pokemonList.OrderBy(h => h.hp); // Displays Pokemon by hp in ascending order using LINQ
                    foreach (var item in sortedList)
                    {
                        Console.WriteLine("----------------------------");
                        Console.WriteLine($"Name: {item.name}");
                        Console.WriteLine($"HP: {item.hp}");
                        Console.WriteLine($"Exp: {item.exp}");
                        Console.WriteLine($"Skill: {item.skill}");
                        Console.WriteLine("----------------------------");
                    }
                }

                else if (menu == "3")
                {
                    if (pokemonList.Count == 0)
                    {
                        Console.WriteLine("You have no Pokemons to check for evolution. Start adding some!");
                    }

                    int pikachuCount = 0;
                    int charmanderCount = 0;
                    int eeveeCount = 0;
                    foreach (var pokemon in pokemonList)
                    {
                        if (pokemon.name.ToLower() == pokemonMasters[0].Name.ToLower()) // Checks for possible evolution
                        {
                            pikachuCount += 1;
                            if (pikachuCount >= pokemonMasters[0].NoToEvolve)
                            {
                                Console.WriteLine($"{pokemonMasters[0].Name} --> {pokemonMasters[0].EvolveTo}");
                                if (pikachuCount == 2)
                                {
                                    pikachuCount = 0;
                                }
                            }
                        }

                        else if (pokemon.name.ToLower() == pokemonMasters[1].Name.ToLower())
                        {
                            eeveeCount += 1;
                            if (eeveeCount >= pokemonMasters[1].NoToEvolve)
                            {
                                Console.WriteLine($"{pokemonMasters[1].Name} --> Flareon, Vaporeon or Jolteon");
                                if (eeveeCount == 3)
                                {
                                    eeveeCount = 0;
                                }
                            }
                        }

                        else if (pokemon.name.ToLower() == pokemonMasters[2].Name.ToLower())
                        {
                            charmanderCount += 1;
                            if (charmanderCount >= pokemonMasters[2].NoToEvolve)
                            {
                                Console.WriteLine($"{pokemonMasters[2].Name} --> {pokemonMasters[2].EvolveTo}"); ;
                                if (charmanderCount == 1)
                                {
                                    charmanderCount = 0;
                                }
                            }
                        }
                    }
                }

                else if (menu == "4")
                {
                    if (pokemonList.Count == 0)
                    {
                        Console.WriteLine("You have no Pokemons to evolve. Start adding some!");
                    }

                    int pikachuCount = 0;
                    int charmanderCount = 0;
                    int eeveeCount = 0;

                    foreach (var pokemon in pokemonList)
                    {
                        if (pokemon.name.ToLower() == pokemonMasters[0].Name.ToLower()) // Gets individual count of each pokemon
                        {
                            pikachuCount += 1;
                        }

                        else if (pokemon.name.ToLower() == pokemonMasters[1].Name.ToLower())
                        {
                            eeveeCount += 1;
                        }

                        else if (pokemon.name.ToLower() == pokemonMasters[2].Name.ToLower())
                        {
                            charmanderCount += 1;
                        }
                    }

                    while (pikachuCount >= 2)
                    {
                        var tmpCharacter = new Pikachu("Raichu", 0, 0, "Thunder Punch");
                        pokemonList.Add(tmpCharacter);
                        Console.WriteLine($"{pokemonMasters[0].Name} has evolved to {pokemonMasters[0].EvolveTo} and acquired Thunder Punch!");
                        Console.WriteLine("");
                        pikachuCount -= 2;
                        RemovePokemonFromList(pokemonList, "Pikachu", 2);
                    }

                    while (eeveeCount >= 3)
                    {
                        // Additional Feature: Eevee able to evolve into 3 different outcome, Flareon, Vaporeon or Jolteon
                        int eeveeEvolveRand = rnd.Next(1, 4);  // creates a random number between 1 and 3 for random evolution
                        if (eeveeEvolveRand == 1)
                        {
                            var tmpCharacter = new Eevee("Flareon", 0, 0, "Overheat");
                            pokemonList.Add(tmpCharacter);
                            Console.WriteLine($"{pokemonMasters[1].Name} has evolved to Flareon and acquired Overheat!");
                            Console.WriteLine("");
                            eeveeCount -= 3;
                            RemovePokemonFromList(pokemonList, "Eevee", 3);
                        }

                        else if (eeveeEvolveRand == 2)
                        {
                            var tmpCharacter = new Eevee("Vaporeon", 0, 0, "Hydro Pump");
                            pokemonList.Add(tmpCharacter);
                            Console.WriteLine($"{pokemonMasters[1].Name} has evolved to Vaporeon and acquired Hydro Pump!");
                            Console.WriteLine("");
                            eeveeCount -= 3;
                            RemovePokemonFromList(pokemonList, "Eevee", 3);
                        }

                        else if (eeveeEvolveRand == 3)
                        {
                            var tmpCharacter = new Eevee("Jolteon", 0, 0, "Discharge");
                            pokemonList.Add(tmpCharacter);
                            Console.WriteLine($"{pokemonMasters[1].Name} has evolved to Jolteon and acquired Discharge!");
                            Console.WriteLine("");
                            eeveeCount -= 3;
                            RemovePokemonFromList(pokemonList, "Eevee", 3);
                        }
                    }

                    while (charmanderCount >= 1)
                    {
                        var tmpCharacter = new Charmander("Charmeleon", 0, 0, "Flame Thrower");
                        pokemonList.Add(tmpCharacter);
                        Console.WriteLine($"{pokemonMasters[2].Name} has evolved to {pokemonMasters[2].EvolveTo} and acquired Flame Thrower!");
                        Console.WriteLine("");
                        charmanderCount -= 1;
                        RemovePokemonFromList(pokemonList, "Charmander", 1);
                    }
                }

                else if (menu == "5") // Additional Feature: Currency System & Shop
                {
                    while (true)
                    {
                        Console.WriteLine("");
                        Console.WriteLine("********************");
                        Console.WriteLine("Welcome to PokeShop!");
                        Console.WriteLine("********************");
                        Console.WriteLine($"You currently have {PokeCoin} PokeCoins!");
                        Console.WriteLine("");
                        Console.WriteLine("(1). Pinap Berry x4 [40 PokeCoins]");
                        Console.WriteLine("(2). Pokeball x10 [80 PokeCoins]");
                        Console.WriteLine("(3). Revive Crystal 1x [100 PokeCoins]\n");
                        Console.Write("What would you like to buy [Q to exit PokeShop]: ");

                        string shop = Convert.ToString(Console.ReadLine());

                        if (shop == "1")
                        {
                            if (PokeCoin >= 40)
                            {
                                var tmpInventory = new Berry("Pinap Berry", 4);
                                PokeCoin -= 40;
                                if (berryList.Count == 0)
                                {
                                    berryList.Add(tmpInventory);
                                    Console.WriteLine("You bought 4x Pinap Berry for 40 PokeCoins!");
                                }

                                else
                                {
                                    foreach (var item in berryList)
                                    {
                                        if (item.itemName.ToLower() == "pinap berry")
                                        {
                                            item.itemNo += 4;
                                            Console.WriteLine("You bought 4x Pinap Berry for 40 PokeCoins!");
                                        }
                                    }
                                }
                            }

                            else
                            {
                                Console.WriteLine("You do not have enough PokeCoins!");
                            }
                        }

                        else if (shop == "2")
                        {
                            if (PokeCoin >= 80)
                            {
                                var tmpInventory = new Pokeball("Pokeball", 10);
                                PokeCoin -= 80;
                                if (pokeballList.Count == 0)
                                {
                                    pokeballList.Add(tmpInventory);
                                    Console.WriteLine("You bought 4x Pinap Berry for 40 PokeCoins!");
                                }

                                else
                                {
                                    foreach (var item in pokeballList)
                                    {
                                        if (item.itemName.ToLower() == "pokeball")
                                        {
                                            item.itemNo += 10;
                                            Console.WriteLine("You bought 10x Pokeballs for 80 PokeCoins!");
                                        }
                                    }
                                }
                            }

                            else
                            {
                                Console.WriteLine("You do not have enough PokeCoins!");
                            }
                        }

                        else if (shop == "3")
                        {
                            if (PokeCoin >= 100)
                            {
                                var tmpInventory = new ReviveCrystal("Revive Crystal", 1);
                                PokeCoin -= 80;
                                if (reviveCrystalList.Count == 0)
                                {
                                    reviveCrystalList.Add(tmpInventory);
                                    Console.WriteLine("You bought 1x Revive Crystal for 100 PokeCoins!");
                                }

                                else
                                {
                                    foreach (var item in reviveCrystalList)
                                    {
                                        if (item.itemName.ToLower() == "revive crystal")
                                        {
                                            item.itemNo += 1;
                                            Console.WriteLine("You bought 1x Revive Crystal for 100 PokeCoins!");
                                        }
                                    }
                                }
                            }

                            else
                            {
                                Console.WriteLine("You do not have enough PokeCoins!");
                            }
                        }

                        else if (shop.ToUpper() == "Q")
                        {
                            Console.WriteLine("Thanks for shopping at PokeShop! See you again!");
                            break;
                        }

                        else
                        {
                            Console.WriteLine("Invalid Input!");
                        }
                    }
                }

                else if (menu == "6") // Additional Feature: Inventory System to keep track of items bought
                {
                    Console.WriteLine("");
                    Console.WriteLine("You currently have:");
                    if (berryList.Count == 0 && pokeballList.Count == 0 && reviveCrystalList.Count == 0)
                    {
                        Console.WriteLine("Nothing yet! Start buying some items from the Pokeshop!");
                    }

                    foreach (var item in berryList)
                    {
                        Console.WriteLine($"{item.itemNo}x {item.itemName}");
                    }

                    foreach (var item in pokeballList)
                    {
                        Console.WriteLine($"{item.itemNo}x {item.itemName}");
                    }

                    foreach (var item in reviveCrystalList)
                    {
                        Console.WriteLine($"{item.itemNo}x {item.itemName}");
                    }
                }

                else if (menu.ToUpper() == "Q")
                {
                    Console.WriteLine("Thank you for using Pokemon Pocket App!");
                    Console.WriteLine("");
                    Environment.Exit(0);
                }

                else
                {
                    Console.WriteLine("Invalid Option!");
                }
            }
        }

        // Remove Pokemon Function
        static void RemovePokemonFromList(List<Pokemon> pokemonList, string nameOfPokemonToRemove, int numberOfTimes)
        {
            List<Pokemon> listOfPokemonToRemove = new List<Pokemon>();

            int numberAlreadyRemoved = 0;

            foreach (var p in pokemonList)
            {
                if (numberAlreadyRemoved < numberOfTimes)
                {
                    if (string.Compare(p.name, nameOfPokemonToRemove, true) == 0)
                    {
                        listOfPokemonToRemove.Add(p);
                        numberAlreadyRemoved += 1;
                    }
                }
            }

            foreach (var pokemonToRemove in listOfPokemonToRemove)
            {
                pokemonList.Remove(pokemonToRemove);
            }
        }
    }
}
