﻿using System;
using System.Text;

namespace TASKWebApp.Business.Helpers
{
    public class PasswordEncryptor
    {

        // encoding
        public static string Encrypt(string strData)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(strData));
            // reference https://msdn.microsoft.com/en-us/library/ds4kkd55(v=vs.110).aspx
        }


        // decoding
        public static string Decrypt(string strData)
        {
            return Encoding.UTF8.GetString(Convert.FromBase64String(strData));
            // reference https://msdn.microsoft.com/en-us/library/system.convert.frombase64string(v=vs.110).aspx
        }


        /*
           public class Global
           {
               public string strPassword { get; set; }

               // set permutations
               public const String strPermutation = "ouiveyxaqtd";
               public const Int32 bytePermutation1 = 0x16;
               public const Int32 bytePermutation2 = 0x04;
               public const Int32 bytePermutation3 = 0x10;
               public const Int32 bytePermutation4 = 0x09;
           }

           // encoding
           public static string Encrypt(string strData)
           {

               return Convert.ToBase64String(Encrypt(Encoding.UTF8.GetBytes(strData)));
               // reference https://msdn.microsoft.com/en-us/library/ds4kkd55(v=vs.110).aspx

           }


           // decoding
           public static string Decrypt(string strData)
           {
               return Encoding.UTF8.GetString(Decrypt(Convert.FromBase64String(strData)));
               // reference https://msdn.microsoft.com/en-us/library/system.convert.frombase64string(v=vs.110).aspx

           }

           // encrypt
           public static byte[] Encrypt(byte[] strData)
           {
               PasswordDeriveBytes passbytes =
               new PasswordDeriveBytes(Global.strPermutation,
               new byte[] { Global.bytePermutation1,
                            Global.bytePermutation2,
                            Global.bytePermutation3,
                            Global.bytePermutation4
               });

               MemoryStream memstream = new MemoryStream();
               Aes aes = new AesManaged();
               aes.Key = passbytes.GetBytes(aes.KeySize / 8);
               aes.IV = passbytes.GetBytes(aes.BlockSize / 8);

               CryptoStream cryptostream = new CryptoStream(memstream,
               aes.CreateEncryptor(), CryptoStreamMode.Write);
               cryptostream.Write(strData, 0, strData.Length);
               cryptostream.Close();
               return memstream.ToArray();
           }

           // decrypt
           public static byte[] Decrypt(byte[] strData)
           {
               PasswordDeriveBytes passbytes =
               new PasswordDeriveBytes(Global.strPermutation,
               new byte[] { Global.bytePermutation1,
                            Global.bytePermutation2,
                            Global.bytePermutation3,
                            Global.bytePermutation4
               });

               MemoryStream memstream = new MemoryStream();
               Aes aes = new AesManaged();
               aes.Key = passbytes.GetBytes(aes.KeySize / 8);
               aes.IV = passbytes.GetBytes(aes.BlockSize / 8);

               CryptoStream cryptostream = new CryptoStream(memstream,
               aes.CreateDecryptor(), CryptoStreamMode.Write);
               cryptostream.Write(strData, 0, strData.Length);
               cryptostream.Close();
               return memstream.ToArray();
           }
        */
    }
}
