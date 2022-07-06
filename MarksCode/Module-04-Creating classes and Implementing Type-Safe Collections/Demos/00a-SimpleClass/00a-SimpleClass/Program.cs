using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _00a_SimpleClass
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

    class BankAccount
    {
        public string AccountNumber { get; set; } //property

        private decimal _balance; //field
        public decimal Balance {
            get
            {
                return _balance;
            }
                            } //property

        public void Deposit(decimal amount) //Method
        {
            _balance += amount;
        }

        public void Withdraw(decimal amount) //Method
        {
            _balance -= amount;
        }

    }
}
