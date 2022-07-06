using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _00c_Constructors
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

            BankAccount second = new BankAccount(100);
            second.AccountNumber = "222";
            second.Deposit(50);
            Console.WriteLine($"Bank Account {second.AccountNumber}, Balance {second.Balance:C}");

            BankAccount third = new BankAccount("333", 70);
            third.Deposit(33);
            Console.WriteLine($"Bank Account {third.AccountNumber}, Balance {third.Balance:C}");

            BankAccount fourth = new BankAccount() { AccountNumber = "444" };
            fourth.Deposit(66);
            Console.WriteLine($"Bank Account {fourth.AccountNumber}, Balance {fourth.Balance:C}");

            Console.ReadLine();
        }
    }

    class BankAccount
    {
        public BankAccount()
        {

        }

        public BankAccount(decimal initBalance)
        {
            _balance = initBalance;
        }

        public BankAccount(string accountNumber, decimal initBalance)
        {
            _balance = initBalance;
            AccountNumber = accountNumber;
        }

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
    }
}
