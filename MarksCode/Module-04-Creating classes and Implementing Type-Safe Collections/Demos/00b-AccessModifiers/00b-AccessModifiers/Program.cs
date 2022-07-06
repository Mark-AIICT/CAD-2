using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _00b_AccessModifiers
{
    class Program
    {
        static void Main(string[] args)
        {
            BankAccount first = new BankAccount();
            first.AccountNumber = "111";
            first.Deposit(30);
            first.Withdraw(10);

            Console.WriteLine($"Bank Account {first.AccountNumber}, Balance {first.Balance:C}");

            Console.ReadLine();
        }
    }

    internal class BankAccount // Can be accessed from anywhere in this 'Assembly' (i.e. this .exe), but not from outside this assembly.
    {
        public string AccountNumber { get; set; } //PUBLIC property. Can be accessed outside the class

        private decimal _balance; //PRIVATE field. Can onlybe accessed from within the class.
        public decimal Balance //PUBLIC property. Can be accessed outside the class
        {
            get
            {
                return _balance;
            }
        } //property

        public void Deposit(decimal amount) //PUBLIC method. Can be accessed outside the class
        {
            _balance += amount;
        }

        public void Withdraw(decimal amount)  //PUBLIC method. Can be accessed outside the class
        {
            {
                _balance -= amount;
            }
        }
    }
}
