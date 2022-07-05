using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication14
{
    class Program
    {
        static void Main(string[] args)
        {
            SavingsAccount sa = new SavingsAccount();
            sa.Deposit(100);

            ChequeAccount ca = new ChequeAccount();
            ca.Deposit(30);

            TransferMoney(ca, sa, 5);
            TransferMoney(sa, ca, 15);
            TransferMoney(sa, sa, 3);

            Console.WriteLine("Use the debugger to go through this line by line. Press enter to end");
            Console.ReadLine();


        }

        static void TransferMoney(IBankAccount from, IBankAccount to, Decimal Amt)
        {
            from.Withdraw(Amt);
            to.Deposit(Amt-2);
        }
    }
}
