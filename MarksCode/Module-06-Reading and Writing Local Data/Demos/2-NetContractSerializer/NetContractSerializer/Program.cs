﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;

namespace NetContractSerializer
{
    class Program
    {
        static void Main(string[] args)
        {
            SavingsAccount s = new SavingsAccount() { CustomerName = "Kiri", AccountBalance = 399M, Fee=10 };

            //Dsiplay the Savings Account Object
            Console.WriteLine("Before Serialisation. CustomerName={0}, Balance={1}, CreatedDate={2}, Fee={3}",
                               s.CustomerName, s.AccountBalance, s.GetAccountID(), s.Fee);

            //Serialize to XML
            FileStream fs = new FileStream("c:\\temp\\NetContract.xml", FileMode.Create);
            XmlDictionaryWriter writer = XmlDictionaryWriter.CreateTextWriter(fs);
            NetDataContractSerializer ser = new NetDataContractSerializer();
            ser.WriteObject(writer, s);
            writer.Close();


            //DeSerialize from XML
            FileStream fsIn = new FileStream("c:\\temp\\NetContract.xml", FileMode.Open);
            XmlDictionaryReader reader = XmlDictionaryReader.CreateTextReader(fsIn, new XmlDictionaryReaderQuotas());
            NetDataContractSerializer serIn = new NetDataContractSerializer();

            // Deserialize the data and read it from the instance.
            SavingsAccount sx = (SavingsAccount)serIn.ReadObject(reader, true);
            fsIn.Close();

            //Dsiplay the Savings Account Object
            Console.WriteLine("After deserialisation. CustomerName={0}, Balance={1}, CreatedDate={2}, Fee={3}",
                               sx.CustomerName, sx.AccountBalance, sx.GetAccountID(), sx.Fee );
            Console.WriteLine("Press enter to end");
            Console.ReadLine();
        }
    }

    [Serializable]
    [DataContract(Name ="BankAccount")]
    class BankAccount
    {
        [DataMember(Name = "AccountID")]
        private Guid AccountID;

        [DataMember(Name="Bal")]
        public decimal AccountBalance { get; set; }

        [DataMember(Name = "Customer")]
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
    [DataContract(Name = "SavingsAcct")]
    class SavingsAccount : BankAccount
    {
        [DataMember(Name = "Fee")]
        public decimal Fee { get; set; }

    }
}
