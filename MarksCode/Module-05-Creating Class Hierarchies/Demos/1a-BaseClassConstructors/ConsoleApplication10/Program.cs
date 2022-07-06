using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApplication10
{
    class Program
    {
        static void Main(string[] args)
        {
            SavingsAccount s = new SavingsAccount("Joe");
            ChequeAccount c = new ChequeAccount("Ang");
            HighInterestSavingsAccount h = new HighInterestSavingsAccount("Ness");
            s.Withdraw(300); //early binding

            transfer(s, c, 300);
            transfer(c, s, 400);
            transfer(c, h, 30);

            Console.WriteLine("Run this using the debugger. Press enter to end");
            Console.ReadLine();
 

        }

        //Closed for modification but open for extension
        static void transfer(Account from, Account to, decimal amount)
        {
            to.Deposit(amount); //late binding
            from.Withdraw(amount);
            
        }
    }
}
