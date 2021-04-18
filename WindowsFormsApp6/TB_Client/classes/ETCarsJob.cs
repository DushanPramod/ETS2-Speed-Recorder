// Decompiled with JetBrains decompiler
// Type: TB_Client.classes.ETCarsJob
// Assembly: TB Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1A007F5D-635A-4205-BA63-50EE7F34DE72
// Assembly location: C:\Program Files (x86)\TrucksBook Client\TB Client.exe

namespace TB_Client.classes
{
  public class ETCarsJob
  {
    public string cargoID { get; set; }

    public string cargo { get; set; }

    public float mass { get; set; }

    public float income { get; set; }

    public string destinationCityID { get; set; }

    public string destinationCity { get; set; }

    public string destinationCompanyID { get; set; }

    public string destinationCompany { get; set; }

    public string sourceCityID { get; set; }

    public string sourceCity { get; set; }

    public string sourceCompanyID { get; set; }

    public string sourceCompany { get; set; }

    public long deliveryTime { get; set; }

    public bool isLate { get; set; }

    public long timeRemaining { get; set; }

    public bool onJob { get; set; }
  }
}
