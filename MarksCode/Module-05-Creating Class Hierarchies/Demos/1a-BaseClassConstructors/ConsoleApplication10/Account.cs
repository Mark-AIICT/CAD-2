using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApplication10
{
    public abstract class Account
    {
        protected decimal _balance;
        protected string _customerName;

        public Account(string CustomerName)
        {
            _customerName = CustomerName;
        }

        public Account(string CustomerName, decimal InitialBalance)
        {
            _customerName = CustomerName;
            _balance = InitialBalance;
        }


        public virtual void Withdraw(decimal amount)
        {
            _balance -= amount;
        }

        public abstract void Deposit(decimal amount);
  
    }

    public class SavingsAccount : Account
    {
        public SavingsAccount(string CustomerName) : base(CustomerName, 5)
        { }

        public override void Deposit(decimal amount)
        {
            this._balance += 10 + amount;
        }
    }

    public class HighInterestSavingsAccount : SavingsAccount
    {
        public HighInterestSavingsAccount(string CustomerName) : base(CustomerName)
        { }

        public override void Deposit(decimal amount)
        {
            this._balance += 100 + amount;
        }
    }
    public sealed class ChequeAccount : Account
    {
        public ChequeAccount(string CustomerName) : base(CustomerName, 0)
        { }

        public override void Deposit(decimal amount)
        {
            this._balance += amount -1;
        }
    }
}
