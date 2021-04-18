// Decompiled with JetBrains decompiler
// Type: TB_Client.classes.id_guid
// Assembly: TB Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1A007F5D-635A-4205-BA63-50EE7F34DE72
// Assembly location: C:\Program Files (x86)\TrucksBook Client\TB Client.exe

using Microsoft.Win32;
using System;

namespace TB_Client.classes
{
  internal class id_guid
  {
    public static string GetGuid()
    {
      string name1 = "SOFTWARE\\Microsoft\\Cryptography";
      string name2 = "MachineGuid";
      using (RegistryKey registryKey1 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64))
      {
        using (RegistryKey registryKey2 = registryKey1.OpenSubKey(name1))
        {
          if (registryKey2 == null)
            return "";
          object obj = registryKey2.GetValue(name2);
          if (obj == null)
            throw new IndexOutOfRangeException(string.Format("Index Not Found: {0}", (object) name2));
          return obj.ToString();
        }
      }
    }
  }
}
