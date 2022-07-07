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
            toby.AliveOrDead = Pet.LifeState.Alive;
            toby.Habitat = "ocean";
            toby.PreferredSalinity = "Very Salty";
            toby.PreferredPrey = "Seals";

            GoldFish tsang = new GoldFish();
            tsang.AliveOrDead = Pet.LifeState.Alive;
            tsang.Habitat = "pond";
            tsang.PreferredSalinity = "No Salt";

            Dog fido = new Dog();
            fido.NumberOfLegs = 4;
            Console.WriteLine($"fido has {fido.NumberOfLegs} legs. Fido says {fido.MakeSound()}");



            Console.ReadLine();
        }
    }
}
