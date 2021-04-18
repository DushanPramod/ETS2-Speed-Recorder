// Decompiled with JetBrains decompiler
// Type: TB_Client.classes.ETCarsWheelInfo
// Assembly: TB Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1A007F5D-635A-4205-BA63-50EE7F34DE72
// Assembly location: C:\Program Files (x86)\TrucksBook Client\TB Client.exe

namespace TB_Client.classes
{
  public class ETCarsWheelInfo
  {
    public float suspensionDeflection { get; set; }

    public bool onGround { get; set; }

    public string substance { get; set; }

    public float angularVelocity { get; set; }

    public float lift { get; set; }

    public float liftOffset { get; set; }

    public ETCarsPosition position { get; set; }

    public bool steerable { get; set; }

    public bool simulated { get; set; }

    public float radius { get; set; }

    public float steering { get; set; }

    public float rotation { get; set; }

    public bool powered { get; set; }

    public bool liftable { get; set; }
  }
}
