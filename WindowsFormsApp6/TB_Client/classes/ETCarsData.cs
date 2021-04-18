// Decompiled with JetBrains decompiler
// Type: TB_Client.classes.ETCarsData
// Assembly: TB Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1A007F5D-635A-4205-BA63-50EE7F34DE72
// Assembly location: C:\Program Files (x86)\TrucksBook Client\TB Client.exe

namespace TB_Client.classes
{
  public class ETCarsData
  {
    public string status { get; set; }

    public ETCarsTelemetry telemetry { get; set; }

    public ETCarsJobdata jobData { get; set; }

    public ETCarsOffense offense { get; set; }
  }
}
