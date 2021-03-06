using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Xml.Serialization;

namespace CS
{
    class Program
    {
        static void Main(string[] args)
        {
            SavingsAccount s = new SavingsAccount() { CustomerName = "Kiri", AccountBalance = 399M, Fee = 10 };

            //Dsiplay the Savings Account Object
            Console.WriteLine("Before Serialisation. CustomerName={0}, Balance={1}, AccountNumber={2}, Fee={3}",
                               s.CustomerName, s.AccountBalance, s.GetAccountID(), s.Fee);

            //Serialize to XML
            FileStream fs = new FileStream(@"c:\temp\SA2.xml", FileMode.Create);
            XmlSerializer ser = new XmlSerializer(typeof(SavingsAccount));
            ser.Serialize(fs, s);
            fs.Close();


            //DeSerialize from XML
            FileStream fsIn = new FileStream(@"C:\temp\SA2.xml", FileMode.Open);
            SavingsAccount sx = (SavingsAccount)ser.Deserialize(fsIn);
            fsIn.Close();

            //Dsiplay the Savings Account Object
            Console.WriteLine("After deserialisation. CustomerName={0}, Balance={1}, AccountNumber={2}, Fee={3}",
                               sx.CustomerName, sx.AccountBalance, sx.GetAccountID(), sx.Fee);
            Console.WriteLine("Press enter to end");

            Console.ReadLine();
        }
    }

    [Serializable]
    public class BankAccount
    {
        private Guid AccountID; //Private data is not serialized by the XMLSerializer



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
    public class SavingsAccount : BankAccount
    {
        public decimal Fee { get; set; }

    }
}
