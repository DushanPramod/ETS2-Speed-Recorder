// Decompiled with JetBrains decompiler
// Type: TB_Client.classes.EnDecrypt
// Assembly: TB Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1A007F5D-635A-4205-BA63-50EE7F34DE72
// Assembly location: C:\Program Files (x86)\TrucksBook Client\TB Client.exe

using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace TB_Client.classes
{
  internal class EnDecrypt
  {
    public void GenerateKeyIV()
    {
      Random random = new Random();
      string s1 = new string(Enumerable.Repeat<string>("ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789", 50).Select<string, char>((Func<string, char>) (s => s[random.Next(s.Length)])).ToArray<char>());
      SHA256 shA256 = SHA256.Create();
      //Nastaveni.ed_pass = s1;
      //Nastaveni.key = shA256.ComputeHash(Encoding.ASCII.GetBytes(s1));
      //Nastaveni.IV = new byte[16];
    }

    public string EncryptString(string plainText, byte[] key, byte[] iv)
    {
      Aes aes = Aes.Create();
      aes.Mode = CipherMode.CBC;
      byte[] numArray = new byte[32];
      Array.Copy((Array) key, 0, (Array) numArray, 0, 32);
      aes.Key = numArray;
      aes.IV = iv;
      MemoryStream memoryStream = new MemoryStream();
      ICryptoTransform encryptor = aes.CreateEncryptor();
      CryptoStream cryptoStream = new CryptoStream((Stream) memoryStream, encryptor, CryptoStreamMode.Write);
      byte[] bytes = Encoding.UTF8.GetBytes(plainText);
      cryptoStream.Write(bytes, 0, bytes.Length);
      cryptoStream.FlushFinalBlock();
      byte[] array = memoryStream.ToArray();
      memoryStream.Close();
      cryptoStream.Close();
      return Convert.ToBase64String(array, 0, array.Length);
    }
  }
}
