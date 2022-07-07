using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _00b_CustomExceptionClass
{
    class BankAccount
    {
        private decimal _balance;

        public decimal Balance
        {
            get { return _balance; }
            set {
                if (value < 0)
                    throw new BankAccountBalanceException("Balance can't be less than zero", value);
                _balance = value;
            }
        }

    }

    class BankAccountBalanceException : ApplicationException
    {
        public decimal IncorrectBalanceAmount { get; set; }
        public BankAccountBalanceException() : base()
        { }

        public BankAccountBalanceException(string msg) : base(msg)
        { }

        public BankAccountBalanceException(string msg, decimal incorrectBalance) : base(msg)
        {
            IncorrectBalanceAmount = incorrectBalance;
        }

        public BankAccountBalanceException(string msg, Exception ex) : base(msg,ex)
        { }



    }
}
