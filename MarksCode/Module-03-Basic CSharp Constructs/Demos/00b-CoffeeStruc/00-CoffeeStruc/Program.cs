using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
                    
namespace _00_CoffeeStruc
{
    class Program
    {
        static void Main(string[] args)
        {
            Coffee c1 = new Coffee();
            c1.BeanType = "Aribica";

            Coffee c2 = new Coffee();
            c2.BeanType = "Kenyan";


            Coffee c3 = new Coffee("PNG", 45, 5);

            Coffee c4 = new Coffee("Brazil");

            c3.Strength = 3;
            Console.WriteLine($"{c3.BeanType} has a quantity of {c3.QtyKgs}, strength is: {c3.Strength}");

            Console.ReadLine();
        }
    }

    struct Coffee
    {
        //Constructors
        public Coffee(string bType, int qty, int strength)
        {
            BeanType = bType;
            QtyKgs = qty;
            _strength = strength;
        }
        public Coffee(string bType)
        {
            BeanType = bType;
            QtyKgs = 0;
            _strength = 0;
        }

        //Fields (members)
        public string BeanType;
        public int QtyKgs;
        private int _strength;

        //Property
        public int Strength
        {
            get { return _strength; }
            set
            {
                if (value < 1 || value > 5)
                    throw new ArgumentOutOfRangeException("strength", "Strength must be between 1 and 5");
                _strength = value;
            }
        }
    }
}
