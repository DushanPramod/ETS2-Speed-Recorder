// Decompiled with JetBrains decompiler
// Type: SCSSdkClient.Extension
// Assembly: TB Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1A007F5D-635A-4205-BA63-50EE7F34DE72
// Assembly location: C:\Program Files (x86)\TrucksBook Client\TB Client.exe

using System;

namespace SCSSdkClient
{
  public static class Extension
  {
    public static T ToEnum<T>(this uint enumInt)
    {
      return (T) Enum.ToObject(typeof (T), enumInt);
    }

    public static T ToEnum<T>(this string enumString) where T : struct
    {
      T result;
      return !Enum.TryParse<T>(enumString, true, out result) ? 0U.ToEnum<T>() : result;
    }

    public static string StringFormater(this string choob)
    {
      string str = "";
      for (int index = 0; index < choob.Length; ++index)
      {
        char ch = choob[index];
        str += ch.ToString();
        if (ch == '\n')
        {
          while (ch == '\n' || ch == '\t')
          {
            ++index;
            ch = choob[index];
            str = ch != '\n' && ch != '\t' ? str + "\t" + ch.ToString() : str + ch.ToString();
          }
        }
      }
      return str;
    }
  }
}
