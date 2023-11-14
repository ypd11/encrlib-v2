/*
 *  This library was made by Yaroy P. Díaz.
 *  UPDATED TO VERSION 2.0 ON NOVEMBER 14th 2023
 * 
 */

using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace EncrLib2
{
    public static class Encryptor
    {
        private static string IV
        {
            get
            {
                string str1 = "2";
                string str2 = "b";
                string iv = str1 + str2;
                while (iv.Length < 16)
                    iv = iv + str1 + str2;
                return iv;
            }
        }

        private static string AESKey
        {
            get
            {
                string str1 = "3";
                string str2 = "c";
                string aesKey = str1 + str2;
                do
                {
                    aesKey = aesKey + str1 + str2;
                }
                while (aesKey.Length < 31);
                return aesKey;
            }
        }

        private static string TripleDESKey
        {
            get
            {
                char ch1 = C(18);
                char ch2 = C(1);
                char ch3 = C(11);
                char ch4 = C(22);
                char ch5 = C(28);
                char ch6 = C(7);
                char ch7 = C(13);
                char ch8 = C(33);
                char ch9 = C(18);
                char ch10 = C(16);
                char ch11 = C(14);
                char ch12 = C(24);
                char ch13 = C(26);
                char ch14 = C(34);
                List<string> stringList = new List<string>();
                stringList.Insert(0, ch1.ToString());
                stringList.Insert(1, ch2.ToString());
                stringList.Insert(2, ch3.ToString());
                stringList.Insert(3, ch4.ToString());
                stringList.Insert(4, "-");
                stringList.Insert(5, ch5.ToString());
                stringList.Insert(6, ch6.ToString());
                stringList.Insert(7, ch7.ToString());
                stringList.Insert(8, ch8.ToString());
                stringList.Insert(9, "-");
                stringList.Insert(10, ch9.ToString());
                stringList.Insert(11, ch10.ToString());
                stringList.Insert(12, ch11.ToString());
                stringList.Insert(13, ch12.ToString());
                stringList.Insert(14, ch13.ToString());
                stringList.Insert(15, ch14.ToString());
                string tripleDesKey = "";
                foreach (string str in stringList)
                    tripleDesKey += Convert.ToString(str);
                return tripleDesKey;
            }
        }

        private static char C(int i) => (char)Alphabet.Items().GetValue(i);

        public static string SimpleEncrypt(string text)
        {
            try
            {
                string empty = string.Empty;
                return Convert.ToBase64String(Encoding.ASCII.GetBytes(text));
            }
            catch
            {
                return null;
            }
        }

        public static string SimpleDecrypt(string text)
        {
            try
            {
                string empty = string.Empty;
                return Encoding.ASCII.GetString(Convert.FromBase64String(text));
            }
            catch
            {
                return null;
            }
        }

        public static string AESEncrypt(string text)
        {
            try
            {
                byte[] bytes = Encoding.ASCII.GetBytes(text);
                AesCryptoServiceProvider cryptoServiceProvider1 = new AesCryptoServiceProvider
                {
                    BlockSize = 128,
                    KeySize = 256,
                    IV = Encoding.ASCII.GetBytes(IV),
                    Key = Encoding.ASCII.GetBytes(AESKey),
                    Padding = PaddingMode.PKCS7,
                    Mode = CipherMode.CBC
                };
                AesCryptoServiceProvider cryptoServiceProvider2 = cryptoServiceProvider1;
                ICryptoTransform encryptor = cryptoServiceProvider2.CreateEncryptor(cryptoServiceProvider2.Key, cryptoServiceProvider2.IV);
                byte[] inArray = encryptor.TransformFinalBlock(bytes, 0, bytes.Length);
                encryptor.Dispose();
                return Convert.ToBase64String(inArray);
            }
            catch
            {
                return null;
            }
        }

        public static string AESDecrypt(string text)
        {
            try
            {
                byte[] inputBuffer = Convert.FromBase64String(text);
                AesCryptoServiceProvider cryptoServiceProvider1 = new AesCryptoServiceProvider
                {
                    BlockSize = 128,
                    KeySize = 256,
                    IV = Encoding.ASCII.GetBytes(IV),
                    Key = Encoding.ASCII.GetBytes(AESKey),
                    Padding = PaddingMode.PKCS7,
                    Mode = CipherMode.CBC
                };
                AesCryptoServiceProvider cryptoServiceProvider2 = cryptoServiceProvider1;
                ICryptoTransform decryptor = cryptoServiceProvider2.CreateDecryptor(cryptoServiceProvider2.Key, cryptoServiceProvider2.IV);
                byte[] bytes = decryptor.TransformFinalBlock(inputBuffer, 0, inputBuffer.Length);
                decryptor.Dispose();
                return Encoding.ASCII.GetString(bytes);
            }
            catch
            {
                return null;
            }
        }

        public static string TripleDESEncrypt(string text)
        {
            try
            {
                byte[] bytes = Encoding.UTF8.GetBytes(text);
                TripleDESCryptoServiceProvider cryptoServiceProvider = new TripleDESCryptoServiceProvider
                {
                    Key = Encoding.UTF8.GetBytes(TripleDESKey),
                    Mode = CipherMode.ECB,
                    Padding = PaddingMode.PKCS7
                };
                byte[] inArray = cryptoServiceProvider.CreateEncryptor().TransformFinalBlock(bytes, 0, bytes.Length);
                cryptoServiceProvider.Clear();
                return Convert.ToBase64String(inArray, 0, inArray.Length);
            }
            catch
            {
                return null;
            }
        }

        public static string TripleDESDecrypt(string text)
        {
            try
            {
                byte[] inputBuffer = Convert.FromBase64String(text);
                TripleDESCryptoServiceProvider cryptoServiceProvider = new TripleDESCryptoServiceProvider
                {
                    Key = Encoding.UTF8.GetBytes(TripleDESKey),
                    Mode = CipherMode.ECB,
                    Padding = PaddingMode.PKCS7
                };
                byte[] bytes = cryptoServiceProvider.CreateDecryptor().TransformFinalBlock(inputBuffer, 0, inputBuffer.Length);
                cryptoServiceProvider.Clear();
                return Encoding.UTF8.GetString(bytes);
            }
            catch
            {
                return null;
            }
        }

        public static string ToHash(string text)
        {
            if (string.IsNullOrEmpty(text))
                return  null;

            string hash = null;

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] result = sha256.ComputeHash(Encoding.UTF8.GetBytes(text));
                hash = BitConverter.ToString(result).Replace("-", "");
            }
            
            return hash;
        }
    }

    static class Alphabet
    {
        public static char[] Items() => "abcdefghijklmnopqrstuvwxyz1234567890".ToCharArray();
    }
}
