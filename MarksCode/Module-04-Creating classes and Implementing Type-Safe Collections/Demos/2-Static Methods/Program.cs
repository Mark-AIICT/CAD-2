using System;
using System.Collections.Generic;
using System.Text;

namespace P19_Static_Methods
{
    class Program
    {
        static void Main(string[] args)
        {
            

            BankAccount.InterestRate = 0.28M;
           
            BankAccount obj = new BankAccount();
            obj.Balance = 100;
            
            BankAccount obj2 = new BankAccount();
            obj2.Balance = 500;


            Console.WriteLine("Interest on 1st Account={0:C}",obj.GetInterestAmount());
            Console.WriteLine("Interest on 2nd Account={0:C}", obj2.GetInterestAmount());
            Console.WriteLine("Terms and Conditions: " + BankAccount.GetTandC());
            Console.WriteLine("OK, Done. Press enter to continue");
            Console.ReadLine();
        }
    }

    class BankAccount
    {

        public decimal Balance;
        public static decimal InterestRate;

        public decimal GetInterestAmount()
        {
            return Balance * InterestRate;
        }

        public static string GetTandC()
        {
            return "Special " + Convert.ToString(InterestRate * 100) + "% interest!";
        }

    }
}
