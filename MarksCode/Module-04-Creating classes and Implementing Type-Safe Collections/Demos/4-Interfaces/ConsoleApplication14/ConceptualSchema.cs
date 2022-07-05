using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication14
{
    public interface IBankAccount
    {
        void Deposit(decimal amount);
        void Withdraw(decimal amount);
    }

    public interface IPersist
    {
        void Save(string path);
    }

    public class SavingsAccount : IBankAccount,IPersist
    {
        private decimal bal;

        public void Deposit(decimal amount)
        {
            bal += amount;
        }

        public void Withdraw(decimal amount)
        {
            bal -= amount;

        }

        public void Save(string path)
        {
            //Save account goes here
        }
    }

    public class ChequeAccount : IBankAccount
    {
        private decimal B;
        public string CustomerName { get; set; }

        public void Deposit(decimal amount)
        {
            B += amount -10;
        }

        public void Withdraw(decimal amount)
        {
            B -= amount + 5;

        }
    }

}
