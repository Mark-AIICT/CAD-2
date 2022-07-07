using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pets
{
    abstract class Pet //you must inherit from this
    {
        public enum LifeState { Alive, Dead };
        public string PetName { get; set; }
        public LifeState AliveOrDead { get; set; }
        public string Habitat { get; set; }

        protected string _petID; //accessible to derived classes

        public Pet() //constructor
        {
            Habitat = "NoHabitatDefinedYet";
            PetName = "NoNameYet";
            AliveOrDead = LifeState.Alive;
            _petID = Guid.NewGuid().ToString();
        }

        public Pet(string petName, string habitat) //constructor
        {
            Habitat = habitat;
            PetName = petName;
            _petID = Guid.NewGuid().ToString();
        }

        public virtual string DescribePet() //derived classes can override this
        {
            string description =
                   $"\n\n{PetName} is {AliveOrDead}, " +
                   $"{PetName} is {Move()}, " +
                   $"{PetName} likes to be in the {Habitat}. ";

            return description ;
        }

        abstract public string Move(); //derived classes must override this
       
    }

    abstract class Fish:Pet
    {
        public Fish()
        {
            PreferredSalinity = "Neutral";
            Habitat = "Water";
        }

        public Fish(string fishName, string habitat) : base(fishName, habitat)
        {
            PreferredSalinity = "Neutral";
        }
        public string PreferredSalinity { get; set; }
        public override string DescribePet()
        {
            string description = base.DescribePet() +
                                 $"ID is Fish-{_petID}, " +
                                 $"{PetName} likes the salinity to be {PreferredSalinity}. ";
            return description;
        }
    }

    sealed class Shark:Fish //sealed means you can't inherit from it
    {
        public string PreferredPrey { get; set; }
        public override string DescribePet()
        {
            string description = base.DescribePet() +
                                 $"{PetName} likes to eat {PreferredPrey}. ";
            return description;
        }

        public override string Move()
        {
            return "Swimming very fast";
        }
    }


    class GoldFish:Fish
    {
        public GoldFish()
        { }

        public GoldFish(string goldFishName) : base(goldFishName,"Pond")
        {

        }
        public override string Move()
        {
            return "Swimming Slowly, bobbing about";
        }
    }

    abstract class Mammal : Pet
    {
        public int NumberOfLegs { get; set; }
        public override string DescribePet()
        {
            string description = base.DescribePet() +
                                 $"ID is Mammal-{_petID}," +
                                 $"{PetName} has {NumberOfLegs} legs. ";
            return description;
        }

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
