// Decompiled with JetBrains decompiler
// Type: TB_Client.classes.ETCarsGame
// Assembly: TB Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1A007F5D-635A-4205-BA63-50EE7F34DE72
// Assembly location: C:\Program Files (x86)\TrucksBook Client\TB Client.exe

namespace TB_Client.classes
{
  public class ETCarsGame
  {
    public bool isMultiplayer { get; set; }

    public bool paused { get; set; }

    public bool isDriving { get; set; }

    public int majorVersion { get; set; }

    public int minorVersion { get; set; }

    public string gameID { get; set; }

    public string gameName { get; set; }

    public string gameVersionStr { get; set; }

    public string gameVersionOnly { get; set; }

    public long nextRestStop { get; set; }

    public long gameDateTime { get; set; }

    public string gameDayTime { get; set; }

    public string gameDateTimeStr { get; set; }

    public string osEnvironment { get; set; }

    public string architecture { get; set; }

    public int localScale { get; set; }

    public string[] substances { get; set; }
  }
}
