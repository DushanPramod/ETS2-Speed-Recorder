// Decompiled with JetBrains decompiler
// Type: TB_Client.classes.hash
// Assembly: TB Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1A007F5D-635A-4205-BA63-50EE7F34DE72
// Assembly location: C:\Program Files (x86)\TrucksBook Client\TB Client.exe

using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace TB_Client.classes
{
  internal class hash
  {
    public string getHashFileMD5(string file)
    {
      using (MD5 md5 = MD5.Create())
      {
        using (FileStream fileStream = File.OpenRead(file))
          return BitConverter.ToString(md5.ComputeHash((Stream) fileStream)).Replace("-", "");
      }
    }

    public static string getHashMD5(string str)
    {
      return BitConverter.ToString(MD5.Create().ComputeHash(Encoding.Default.GetBytes(str))).Replace("-", "");
    }

    public static string getHashSHA(string str)
    {
      byte[] hash = new SHA256Managed().ComputeHash(Encoding.Unicode.GetBytes(str));
      string empty = string.Empty;
      foreach (byte num in hash)
        empty += string.Format("{0:x2}", (object) num);
      return empty;
    }
  }
}
