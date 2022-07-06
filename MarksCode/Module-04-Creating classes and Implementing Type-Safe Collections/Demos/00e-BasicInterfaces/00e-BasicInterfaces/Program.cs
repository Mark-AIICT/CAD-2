using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _00e_BasicInterfaces
{
            class Program
            {
                static void Main(string[] args)
                {


                    BankAccount first = new BankAccount();
                    first.AccountNumber = "111";
                    first.Deposit(200);
  

                    BankAccount second = new BankAccount();
                    second.AccountNumber = "222";
                    second.Deposit(100);


                    Console.WriteLine($"Before, Bank Account {first.AccountNumber}, Balance {first.Balance:C}");
                    Console.WriteLine($"Before, Bank Account {second.AccountNumber}, Balance {second.Balance:C}");

                    Transfer(first, second,20);
                    Transfer(second, first, 10);


                    Console.WriteLine($"After, Bank Account {first.AccountNumber}, Balance {first.Balance:C}");
                    Console.WriteLine($"After, Bank Account {second.AccountNumber}, Balance {second.Balance:C}");


                    Console.ReadLine();
                }

                static void Transfer(IBank from, IBank To, decimal amount)
                {
                    if (from.Balance < amount)
                        throw new Exception("insufficient Funds");
                    from.Withdraw(amount);
                    To.Deposit(amount);
                }
            }

            interface IBank
            {
                void Deposit(decimal amount);
                void Withdraw(decimal amount);
                decimal Balance { get; }
            }

            class BankAccount : IBank
            {
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
