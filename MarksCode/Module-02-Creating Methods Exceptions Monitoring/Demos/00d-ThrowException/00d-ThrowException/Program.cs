using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _00d_ThrowException
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string invoice;
                invoice = ConstructInvoice(3, -6);
                Console.WriteLine(invoice);
            }
            catch (ApplicationException ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }

        static string ConstructInvoice(decimal qty, decimal price)
        {

            decimal invoiceTotal = qty * price;

            //Check the invoice total
            if (invoiceTotal <= 0)
                throw new ApplicationException("Invoice total is invalid. Must be >= 0");

            return $"invoice: Total Amount {invoiceTotal:C}";
        }
    }
}
