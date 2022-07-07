using Pets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _00a_PetsClasses
{
    class Program
    {
        static void Main(string[] args)
        {

            Shark toby = new Shark();
            toby.PetName = "Toby";
            toby.AliveOrDead = Pet.LifeState.Alive;
            toby.Habitat = "ocean";
            toby.PreferredSalinity = "Very Salty";
            toby.PreferredPrey = "Seals";
            Console.WriteLine(toby.DescribePet());


            GoldFish tsang = new GoldFish("Tsang");
            tsang.AliveOrDead = Pet.LifeState.Alive;
            tsang.PreferredSalinity = "No Salt";
            Console.WriteLine(tsang.DescribePet());


            Dog fido = new Dog();
            fido.PetName = "Fido";
            fido.NumberOfLegs = 4;
            fido.Habitat = "Garden";
            Console.WriteLine(fido.DescribePet());

            Wombat wally = new Wombat();
            wally.PetName = "Wally";
            wally.NumberOfLegs = 5;
            wally.Habitat = "Bush";
            Console.WriteLine(wally.DescribePet());

            Console.WriteLine("\n\n\nUsing the alternative...");

            Console.WriteLine( DescribePet(fido) );   //An aternative



            Console.ReadLine();
        }

        public static string DescribePet(Pet p)
        {
            string description =
                   $"{p.PetName} is {p.AliveOrDead}, " +
                   $"{p.PetName} is {p.Move()}, " +
                   $"{p.PetName} likes to be in the {p.Habitat} ";

            return description;
        }


    }
}
                                    