// Decompiled with JetBrains decompiler
// Type: TB_Client.classes.id_win
// Assembly: TB Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1A007F5D-635A-4205-BA63-50EE7F34DE72
// Assembly location: C:\Program Files (x86)\TrucksBook Client\TB Client.exe

using System;
using System.Management;

namespace TB_Client.classes
{
  internal class id_win
  {
    public static string GetWin()
    {
      string str = "";
      /*ManagementObjectCollection objectCollection = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_OperatingSystem").Get();
      bool flag = !string.IsNullOrEmpty(Environment.GetEnvironmentVariable("PROCESSOR_ARCHITEW6432"));
      using (ManagementObjectCollection.ManagementObjectEnumerator enumerator = objectCollection.GetEnumerator())
      {
        if (enumerator.MoveNext())
          str = enumerator.Current.Properties["SerialNumber"].Value.ToString();
      }*/
      return str;
    }
  }
}
