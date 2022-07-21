using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace AsymmetricDemo_CS
{
    class Program
    {
        static void Main(string[] args)
        {
            string strDataToEncrypt = "Hello Secure World";

            byte[] plainTextBytes = Encoding.UTF8.GetBytes(strDataToEncrypt);

            RSACryptoServiceProvider asymmetricKey = new RSACryptoServiceProvider(GenKey_SaveInContainer("Marks Key"));

 

            byte[] cipherBytes = asymmetricKey.Encrypt(plainTextBytes, true);

            Console.WriteLine("Encoded String:");
            Console.WriteLine(Convert.ToBase64String(cipherBytes));
            Console.WriteLine("\n\n");


            RSACryptoServiceProvider asymmetricKeyForDeCryption = GetKeyFromContainer("Marks Key");

            plainTextBytes = asymmetricKey.Decrypt(cipherBytes, true);

            Console.WriteLine("Decoded String:");
            Console.WriteLine(System.Text.Encoding.UTF8.GetString(plainTextBytes));

            DeleteKeyFromContainer("Marks Key");

            Console.ReadLine();
        }

        public static CspParameters GenKey_SaveInContainer(string ContainerName)
        {
            // Create the CspParameters object and set the key container 
            // name used to store the RSA key pair.
            CspParameters cp = new CspParameters();
            cp.KeyContainerName = ContainerName;

            // Create a new instance of RSACryptoServiceProvider that accesses
            // the key container MyKeyContainerName.
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(cp);

           

            Console.WriteLine("Contains only public key?: \n  {0}\n\n", rsa.PublicOnly.ToString());

            // Display the key information to the console.
            Console.WriteLine("Key added to Windows Key container: \n  {0}\n\n", rsa.ToXmlString(true));

            Console.WriteLine("Public Key : \n  {0}\n\n", rsa.ToXmlString(false));  //just for interest.
            return cp;
        }



        public static RSACryptoServiceProvider GetKeyFromContainer(string ContainerName)
        {
            // Create the CspParameters object and set the key container 
            // name used to store the RSA key pair.
            CspParameters cp = new CspParameters();
            cp.KeyContainerName = ContainerName;

            // Create a new instance of RSACryptoServiceProvider that accesses
            // the key container MyKeyContainerName.
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(cp);

            // Display the key information to the console.
            Console.WriteLine("Key retrieved from container : \n {0}\n\n", rsa.ToXmlString(true));
            return rsa;
        }

        public static void DeleteKeyFromContainer(string ContainerName)
        {
            // Create the CspParameters object and set the key container 
            // name used to store the RSA key pair.
            CspParameters cp = new CspParameters();
            cp.KeyContainerName = ContainerName;

            // Create a new instance of RSACryptoServiceProvider that accesses
            // the key container.
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(cp);

            // Delete the key entry in the container.
            rsa.PersistKeyInCsp = false;

            // Call Clear to release resources and delete the key from the container.
            rsa.Clear();

            Console.WriteLine("\n\nKey deleted.\n\n");
        }

    }
}
