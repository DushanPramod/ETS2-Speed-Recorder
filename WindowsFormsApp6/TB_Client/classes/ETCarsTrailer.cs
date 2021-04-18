// Decompiled with JetBrains decompiler
// Type: TB_Client.classes.ETCarsTrailer
// Assembly: TB Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1A007F5D-635A-4205-BA63-50EE7F34DE72
// Assembly location: C:\Program Files (x86)\TrucksBook Client\TB Client.exe

namespace TB_Client.classes
{
  public class ETCarsTrailer
  {
    public ETCarsLinearVelocity linearVelocity { get; set; }

    public ETCarsAngularVelocity angularVelocity { get; set; }

    public ETCarsLinearAcceleration linearAcceleration { get; set; }

    public ETCarsAngularAcceleration angularAcceleration { get; set; }

    public int wheelCount { get; set; }

    public ETCarsWheelInfo[] wheelInfo { get; set; }

    public string id { get; set; }

    public string cargoAccessoryId { get; set; }

    public ETCarsHookPosition hookPosition { get; set; }
  }
}
