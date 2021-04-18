// Decompiled with JetBrains decompiler
// Type: TB_Client.classes.ETCarsOffense
// Assembly: TB Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1A007F5D-635A-4205-BA63-50EE7F34DE72
// Assembly location: C:\Program Files (x86)\TrucksBook Client\TB Client.exe

namespace TB_Client.classes
{
  public class ETCarsOffense : ETCarsCoordinates
  {
    public string reason { get; set; }

    public float speed { get; set; }

    public float speedLimit { get; set; }

    public float trailerX { get; set; }

    public float trailerY { get; set; }

    public float trailerZ { get; set; }

    public float cabinDamage { get; set; }

    public float chassisDamage { get; set; }

    public float engineDamage { get; set; }

    public float transmissionDamage { get; set; }

    public float trailerDamage { get; set; }
  }
}
