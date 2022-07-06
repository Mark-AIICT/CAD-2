using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApplication10
{
    public abstract class Account
    {
        protected decimal _balance;
        protected string _customerName;


        public virtual void Withdraw(decimal amount)
        {
            _balance -= amount;
        }

        public abstract void Deposit(decimal amount);
  
    }

    public class SavingsAccount : Account
    {
        public override void Deposit(decimal amount)
        {
            this._balance += 10 + amount;
        }
    }

    public class HighInterestSavingsAccount : Account
    {
        public override void Deposit(decimal amount)
        {
            this._balance += 100 + amount;
        }
    }
    public sealed class ChequeAccount : Account
    {
        public override void Deposit(decimal amount)
        {
            this._balance += amount -1;
        }
    }
}
