using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _00d_StaticClassMembers
{

    class Program
    {
        static void Main(string[] args)
        {
            BankAccount.InterestRate = 0.1M;
            BankAccount.IncreaseInterestrate();

            BankAccount first = new BankAccount();
            first.AccountNumber = "111";
            first.Deposit(30);
            first.Withdraw(10);
            Console.WriteLine($"Bank Account {first.AccountNumber}, Balance {first.Balance:C}, Current Interest {first.GetInterest():C}");

            BankAccount second = new BankAccount();
            second.AccountNumber = "222";
            second.Deposit(100);
            second.Withdraw(10);
            Console.WriteLine($"Bank Account {second.AccountNumber}, Balance {second.Balance:C}, Current Interest {second.GetInterest():C}");

            Console.ReadLine();
        }
    }

    class BankAccount
    {

        public static decimal InterestRate { get; set; }                                

        public string AccountNumber { get; set; } //property

        private decimal _balance; //field
        public decimal Balance
        {
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

        public decimal GetInterest()
        {
            return _balance * InterestRate;
        }

        public static void IncreaseInterestrate()
        {
            InterestRate += 0.5M;
            
        }
    }
}
