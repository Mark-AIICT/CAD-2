using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _00b_CustomExceptionClass
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                BankAccount b = new BankAccount();
                b.Balance = -20;
                Console.WriteLine($"Balance is {b.Balance:C}");
            }
            catch (BankAccountBalanceException ex)
            {
                Console.WriteLine($"Banking Problem: {ex.Message}. The invalid amonut was {ex.IncorrectBalanceAmount:C}");
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.ReadLine();
            }
        }
    }
}
