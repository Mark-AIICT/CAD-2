using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace CS
{
    class Program
    {
        static void Main(string[] args)
        {
            SavingsAccount s = new SavingsAccount() { CustomerName = "Kiri", AccountBalance = 399M, Fee = 10 };

            //Dsiplay the Savings Account Object
            Console.WriteLine("Before Serialisation. CustomerName={0}, Balance={1}, CreatedDate={2}, Fee={3}",
                               s.CustomerName, s.AccountBalance, s.GetAccountID(), s.Fee);

            //Serialize to XML
            FileStream fs = new FileStream("SA.bin", FileMode.Create);
            IFormatter formatter = new BinaryFormatter();
            formatter.Serialize(fs, s);
            fs.Close();


            //DeSerialize from XML
            FileStream fsIn = new FileStream("SA.bin", FileMode.Open);
            SavingsAccount sx = (SavingsAccount)formatter.Deserialize(fsIn);
            fsIn.Close();

            //Dsiplay the Savings Account Object
            Console.WriteLine("After deserialisation. CustomerName={0}, Balance={1}, CreatedDate={2}, Fee={3}",
                               sx.CustomerName, sx.AccountBalance, sx.GetAccountID(), sx.Fee);
            Console.WriteLine("Press enter to end");
            Console.ReadLine();
        }
    }

    [Serializable]
    class BankAccount
    {
        private Guid AccountID;
        public decimal AccountBalance { get; set; }
        public string CustomerName { get; set; }

        public BankAccount()
        {

            AccountID = Guid.NewGuid();
        }

        public Guid GetAccountID()
        {
            return AccountID;
        }
    }

    [Serializable()]
    class SavingsAccount : BankAccount
    {
        public decimal Fee { get; set; }

    }
}
