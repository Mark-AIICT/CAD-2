using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _00_hashtables
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new Hashtable collection.
            Hashtable ingredients = new Hashtable();
            // Add some key/value pairs to the collection.
            ingredients.Add("Café au Lait", "Coffee, Milk");
            ingredients.Add("Café Mocha", "Coffee, Milk, Chocolate");
            ingredients.Add("Cappuccino", "Coffee, Milk, Foam");
            ingredients.Add("Irish Coffee", "Coffee, Whiskey, Cream, Sugar");
            ingredients.Add("Macchiato", "Coffee, Milk, Foam");
            // Check whether a key exists.
            if (ingredients.ContainsKey("Café Mocha"))
            {
                // Retrieve the value associated with a key.
                Console.WriteLine("The ingredients of a Café Mocha are: {0}\n\n", ingredients["Café Mocha"]);
            }

            foreach (string key in ingredients.Keys)
            {
                // For each key in turn, retrieve the value associated with the key.
                Console.WriteLine($"The ingredients of a {key} are {ingredients[key]}");
            }



            Console.ReadLine();
           
        }
    }
}
