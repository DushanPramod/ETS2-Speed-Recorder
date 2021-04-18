// Decompiled with JetBrains decompiler
// Type: TB_Client.classes.WebClientEx
// Assembly: TB Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1A007F5D-635A-4205-BA63-50EE7F34DE72
// Assembly location: C:\Program Files (x86)\TrucksBook Client\TB Client.exe

using System;
using System.Net;

namespace TB_Client.classes
{
  public class WebClientEx : WebClient
  {
    protected override WebRequest GetWebRequest(Uri address)
    {
      WebRequest webRequest = base.GetWebRequest(address);
      webRequest.Timeout = 10000;
      return webRequest;
    }
  }
}
