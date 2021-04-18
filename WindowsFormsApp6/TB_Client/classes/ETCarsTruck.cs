// Decompiled with JetBrains decompiler
// Type: TB_Client.classes.ETCarsTruck
// Assembly: TB Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1A007F5D-635A-4205-BA63-50EE7F34DE72
// Assembly location: C:\Program Files (x86)\TrucksBook Client\TB Client.exe

namespace TB_Client.classes
{
  public class ETCarsTruck
  {
    public float cruiseControlSpeed { get; set; }

    public int gear { get; set; }

    public int gearDisplayed { get; set; }

    public int retarderBrakeLevel { get; set; }

    public bool wipersOn { get; set; }

    public string make { get; set; }

    public string makeID { get; set; }

    public string model { get; set; }

    public string modelID { get; set; }

    public string shifterType { get; set; }

    public float odometer { get; set; }

    public bool hasTruck { get; set; }

    public bool engineEnabled { get; set; }

    public bool electricsEnabled { get; set; }

    public bool motorBrake { get; set; }

    public bool parkingBrake { get; set; }

    public float speed { get; set; }

    public float engineRPM { get; set; }

    public float brakeTemperature { get; set; }

    public float fuelRange { get; set; }

    public float oilPressure { get; set; }

    public float oilTemperature { get; set; }

    public float waterTemperature { get; set; }

    public float batteryVoltage { get; set; }

    public float inputSteering { get; set; }

    public float inputThrottle { get; set; }

    public float inputBrake { get; set; }

    public float inputClutch { get; set; }

    public float effectiveSteering { get; set; }

    public float effectiveThrottle { get; set; }

    public float effectiveBrake { get; set; }

    public float effectiveClutch { get; set; }

    public float hShifterSlot { get; set; }

    public float brakeAirPressure { get; set; }

    public float adBlue { get; set; }

    public float dashboardBacklight { get; set; }

    public float maxEngineRPM { get; set; }

    public float forwardGearCount { get; set; }

    public float reverseGearCount { get; set; }

    public float retarderStepCount { get; set; }

    public bool trailerConnected { get; set; }

    public ETCarsWorldPlacement worldPlacement { get; set; }

    public ETCarsLinearVelocity linearVelocity { get; set; }

    public ETCarsAngularVelocity angularVelocity { get; set; }

    public ETCarsLinearAcceleration linearAcceleration { get; set; }

    public ETCarsAngularAcceleration angularAcceleration { get; set; }

    public ETCarsCabiOffset cabinOffset { get; set; }

    public ETCarsHookPosition hookPosition { get; set; }

    public ETCarsHeadPosition headPosition { get; set; }

    public ETCarsCabinAngularVelocity cabinAngularVelocity { get; set; }

    public ETCarsCabinAngularAcceleration cabinAngularAcceleration { get; set; }

    public float[] forwardRatios { get; set; }

    public float[] reverseRatios { get; set; }

    public int wheelCount { get; set; }

    public ETCarsWheelInfo[] wheelInfo { get; set; }

    public ETCarsTrailerPlacement trailerPlacement { get; set; }

    public ETCarsWarnings warnings { get; set; }

    public ETCarsDamages damages { get; set; }

    public ETCarsLights lights { get; set; }

    public ETCarsFuel fuel { get; set; }
  }
}
