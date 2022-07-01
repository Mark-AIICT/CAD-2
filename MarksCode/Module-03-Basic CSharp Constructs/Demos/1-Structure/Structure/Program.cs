using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structure
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList accounts = new ArrayList();

            BankAccount b = new BankAccount();
            b.Balance = 200;
            accounts.Add(b);

            BankAccount b2 = new BankAccount();
            b2.Balance = 400;
            accounts.Add(b2);


            foreach (BankAccount ba in accounts)
            {
                Console.WriteLine("Account:{0}, Balance:{1}",
                    ba.CustomerName,
                    ba.Balance); 
            }



            Console.WriteLine($"Balance={b.Balance}");
            Console.WriteLine("press any key to end");
            Console.ReadKey();
        }
    }

    struct BankAccount
    {

        //Account Number
        private string m_AccountNumber;

        public string AccountNumber
        {
            get { return m_AccountNumber.ToUpper(); }
            set 
            {
                if (value.Length != 6)
                    throw new ArgumentException("Account Numbers must be 6 characters exactly");
                m_AccountNumber = value; 
            }
        }
        


        //CustomerName Property
        public string CustomerName { get; set; }

        //EXPANDS TO:
        //private string m_CustomerName;
        //public string CustomerName { 
        //    get
        //    {
        //        return m_CustomerName;
        //    }
        //    set
        //    {
        //        m_CustomerName = value;
        //    }
        //}



        //Balance property
        private decimal m_Balance;
        public decimal Balance 
        {
            get
            {
                return m_Balance;
            }
            set
            {
                if (value < 10) 
                    throw new ArgumentException("Balance can't be less than ten");
                m_Balance = value;
            }
        }
    }
}
