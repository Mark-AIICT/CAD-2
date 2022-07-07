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
        public string PetName { get; set; }
        public LifeState AliveOrDead { get; set; }
        public string Habitat { get; set; }

        public Pet()
        {
            Habitat = "something";
            PetName = "NoName";
        }

        public virtual string DescribePet()
        {
            string description =
                   $"\n\n{PetName} is {AliveOrDead}, " +
                   $"{PetName} is {Move()}, " +
                   $"{PetName} likes to be in the {Habitat}. ";

            return description ;
        }

        abstract public string Move();
       
    }

    abstract class Fish:Pet
    {
        public string PreferredSalinity { get; set; }
        public override string DescribePet()
        {
            string description = base.DescribePet() +
                                 $"{PetName} likes the salinity to be {PreferredSalinity}. ";
            return description;
        }
    }

    sealed class Shark:Fish //sealed means you can't inherit from it
    {
        public string PreferredPrey { get; set; }
        public override string Move()
        {
            return "Swimming very fast";
        }
    }


    class GoldFish : Fish
    {
        public override string Move()
        {
            return "Swimming Slowly, bobbing about";
        }
    }

    abstract class Mammal : Pet
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
        public override string Move()
        {
            return "Walking";
        }
    }
    class Wombat : Mammal
    {
        override public string MakeSound()
        {
            return "Grumble-Grumble";
        }
        public override string Move()
        {
            return "Waddling";
        }

    }
    class Giraffe : Mammal
    {
        override public string MakeSound()
        {
            return "Neigh";
        }
        public override string Move()
        {
            return "Cantering";
        }

    }
}
