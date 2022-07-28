using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using System.IO;


namespace SymmetricCryptography
{
    public partial class Form1 : Form
    {

       

        public Form1()
        {
            InitializeComponent();
        }






      


        private void button3_Click(object sender, EventArgs e)
        {

            byte[] m_salt = Convert.FromBase64String(lblSalt.Text);
            byte[] IV = Convert.FromBase64String(lblIV.Text);

            //Convert back from Base64 String
            string strEncryptedString = textBox3.Text;
            byte[] encryptedBytes = Convert.FromBase64String(strEncryptedString);


            // Generate a 16 byte (128 bit) key from the password and salt.
            Rfc2898DeriveBytes derBytes = new Rfc2898DeriveBytes(textBox1.Text, m_salt);
            byte[] m_SymmetricKey = derBytes.GetBytes(16);

            Rijndael symAlg = Rijndael.Create();
            symAlg.Key = m_SymmetricKey;
            symAlg.IV = IV;

            //Decode the bytes
            ICryptoTransform decryptor = symAlg.CreateDecryptor();

            MemoryStream msDecryptedData = new MemoryStream(encryptedBytes);

            CryptoStream cryptoStream = new CryptoStream(msDecryptedData, decryptor, CryptoStreamMode.Read);

            byte[] plainTextInBytes = new byte[encryptedBytes.Length];

            int decryptedByteCount = cryptoStream.Read(plainTextInBytes, 0, plainTextInBytes.Length);

            //Convert the data back to string using UTF-8 encoding.
            textBox2.Text = Encoding.UTF8.GetString(plainTextInBytes, 0, decryptedByteCount);

        }

      



       private void button2_Click(object sender, EventArgs e)
        {

           
NumberGenerator rNum = RandomNumberGenerator.Create();
                rNum.GetBytes(m_salt);

                // Generate a 16 byte (128 bit) key from the password and salt.
                Rfc2898DeriveBytes derBytes = new Rfc2898DeriveBytes(textBox1.Text, m_salt);
                byte[] m_SymmetricKey = derBytes.GetBytes(16);

                string strDataToEncrypt = textBox2.Text;

                //Encode the string into bytes using UTF8 encoding
                byte[] plainTextInBytes = Encoding.UTF8.GetBytes(strDataToEncrypt);

                Rijndael symAlg = Rijndael.Create();
                symAlg.Key = m_SymmetricKey;

                ICryptoTransform encryptor = symAlg.CreateEncryptor();

                MemoryStream msEncryptedData = new MemoryStream();

                //Write the salt and IV to the labels
                lblSalt.Text = Convert.ToBase64String(m_salt);
                lblIV.Text = Convert.ToBase64String(symAlg.IV);

                CryptoStream cryptoStream = new CryptoStream(msEncryptedData, encryptor, CryptoStreamMode.Write);

                //Start Encrypting
                cryptoStream.Write(plainTextInBytes, 0, plainTextInBytes.Length);

                //Flush Final Block
                cryptoStream.FlushFinalBlock();

                //Memory stream to byte array 
                byte[] arrEncryptedData = msEncryptedData.ToArray();

                //Convert to Base 64 string. 
                string cipherText = Convert.ToBase64String(arrEncryptedData);
                textBox3.Text += cipherText;
                textBox2.Text = "";
            }
            else
            {
                MessageBox.Show("Password not strong enough", "try again", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }



           



         
        }
    }
}