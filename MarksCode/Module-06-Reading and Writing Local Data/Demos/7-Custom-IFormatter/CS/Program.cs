using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace CS
{
    class Program
    {
        static void Main(string[] args)
        {
            SavingsAccount s = new SavingsAccount() { CustomerName = "Kiri", AccountBalance = 399M, Fee = 10 };

            //Disiplay the Savings Account Object
            Console.WriteLine("Before Serialisation. CustomerName={0}, Balance={1}, CreatedDate={2}, Fee={3}",
                               s.CustomerName, s.AccountBalance, s.GetAccountID(), s.Fee);

            //Serialize to XML
            FileStream fs = new FileStream("c:\\temp\\MyData.ini", FileMode.Create);
            IFormatter formatter = new IniFormatter();
            formatter.Serialize(fs, s);
            fs.Close();


            //DeSerialize from XML
            FileStream fsIn = new FileStream("c:\\temp\\MyData.ini", FileMode.Open);
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
    public class BankAccount : ISerializable
    {
        private Guid AccountID;
        public decimal AccountBalance { get; set; }
        public string CustomerName { get; set; }

        public BankAccount()
        {

            AccountID = Guid.NewGuid();
        }

        public BankAccount(SerializationInfo info, StreamingContext ctx)
        {

            AccountID = Guid.Parse(info.GetString("I"));
        }

        public Guid GetAccountID()
        {
            return AccountID;
        }

        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("I", GetAccountID());

        }
    }

    [Serializable()]
    public class SavingsAccount : BankAccount, ISerializable
    {
        public decimal Fee { get; set; }
        public SavingsAccount() { }
        public SavingsAccount(SerializationInfo info, StreamingContext ctx)
            : base(info, ctx)
        {
            AccountBalance = info.GetDecimal("B");
            Fee = info.GetDecimal("F");
            CustomerName = info.GetString("C");


        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("B", AccountBalance);
            info.AddValue("F", Fee);
            info.AddValue("C", CustomerName);


        }


    }


    class IniFormatter : IFormatter
    {
        static readonly char[] _delim = new char[] { '=' };
        public ISurrogateSelector SurrogateSelector { get; set; }
        public SerializationBinder Binder { get; set; }
        public StreamingContext Context { get; set; }
        public IniFormatter()
        {
            this.Context
            = new StreamingContext(StreamingContextStates.All);
        }

        public object Deserialize(Stream serializationStream)
        {
            StreamReader buffer = new StreamReader(serializationStream);
            
            // Get the type from the serialized data.
            Type typeToDeserialize = this.GetType(buffer);
            
            // Create default instance of object using type name.
            Object obj = FormatterServices.GetUninitializedObject(typeToDeserialize);
           
            // Get all the members for the type.
            MemberInfo[] members = FormatterServices.GetSerializableMembers(obj.GetType(), this.Context);
            
            // Create dictionary to store the variable names and any serialized data.
            Dictionary<string, object> serializedMemberData = new Dictionary<string, object>();
            
            // Read the serialized data, and extract the variable names
            // and values as strings.
            while (buffer.Peek() >= 0)
            {
                string line = buffer.ReadLine();
                string[] sarr = line.Split(_delim);
                // key = variable name, value = variable value.
                serializedMemberData.Add(
                sarr[0].Trim(), // Variable name.
                sarr[1].Trim()); // Variable value.
            }
            // Close the underlying stream.
            buffer.Close();

            // Create a list to store member values as their correct type.
            List<object> dataAsCorrectTypes = new List<object>();

            // For each of the members, get the serialized values as their correct type.
            for (int i = 0; i < members.Length; i++)
            {
                FieldInfo field = members[i] as FieldInfo;
                if (!serializedMemberData.ContainsKey(field.Name))
                    throw new SerializationException(field.Name);
                // Change the type of the value to the correct type
                // of the member.
                object valueAsCorrectType;
                

                //I changed the code to be different to Microsoft's code in the manual because their code crashes when deserializing GUIDs
                if(field.FieldType ==  typeof(Guid))
                    valueAsCorrectType = Guid.Parse(serializedMemberData[field.Name].ToString());
                else
                    valueAsCorrectType = Convert.ChangeType( serializedMemberData[field.Name],
                                                                field.FieldType);
                
                dataAsCorrectTypes.Add(valueAsCorrectType);
            }
            // Populate the object with the deserialized values.
            return FormatterServices.PopulateObjectMembers( obj,
                                                            members,
                                                            dataAsCorrectTypes.ToArray());
        }
        public void Serialize(Stream serializationStream, object graph)
        {
            // Get all the fields that you want to serialize.
            MemberInfo[] allMembers = FormatterServices.GetSerializableMembers(graph.GetType(), this.Context);
            
            // Get the field data.
            object[] fieldData = FormatterServices.GetObjectData(graph, allMembers);
            
            // Create a buffer to write the serialized data to.
            StreamWriter sw = new StreamWriter(serializationStream);
            
            // Write the name of the class to the firstline.
            sw.WriteLine("@ClassName={0}", graph.GetType().FullName);
            
            // Iterate the field data.
            for (int i = 0; i < fieldData.Length; ++i)
            {
                sw.WriteLine("{0}={1}",
                allMembers[i].Name, // Member name.
                fieldData[i].ToString()); // Member value.
            }
            sw.Close();
        }
        private Type GetType(StreamReader buffer)
        {
            string firstLine = buffer.ReadLine();
            string[] sarr = firstLine.Split(_delim);
            string nameOfClass = sarr[1];
            return Type.GetType(nameOfClass);
        }
    }
}