using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pets
{
    abstract class Pet
    {
        public enum LifeState { Alive, Dead };
        public LifeState AliveOrDead { get; set; }
        public string Habitat { get; set; }

        public string Move()
        {
            return "Moving";

        }
    }

    abstract class Fish:Pet
    {
        public string PreferredSalinity { get; set; }
    }

    class Shark:Fish
    {
        public string PreferredPrey { get; set; }
    }

    class GoldFish : Fish
    {
        
    }

    abstract class Mammal
    {
        public int NumberOfLegs { get; set; }
        abstract public string MakeSound(); //you must override this in a derived class

    }

    class Dog : Mammal
    {
        override public string MakeSound()
        {
            return "WOOF";
        }
    }
    class Wombat : Mammal
    {
        override public string MakeSound()
        {
            return "Grumble-Grumble";
        }

    }
    class Giraffe : Mammal
    {
        override public string MakeSound()
        {
            return "Neigh";
        }

    }
}
