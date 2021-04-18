// Decompiled with JetBrains decompiler
// Type: SCSSdkClient.SCSSdkConvert
// Assembly: TB Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1A007F5D-635A-4205-BA63-50EE7F34DE72
// Assembly location: C:\Program Files (x86)\TrucksBook Client\TB Client.exe

using SCSSdkClient.Object;
using System;
using System.Text;

namespace SCSSdkClient
{
  public class SCSSdkConvert
  {
    private readonly int[] _offsetAreas = new int[14]
    {
      0,
      40,
      500,
      700,
      1500,
      1640,
      2000,
      2200,
      2300,
      4000,
      4200,
      4300,
      4400,
      6000
    };
    private const int StringSize = 64;
    private const int WheelSize = 16;
    private const int Substances = 25;
    private byte[] _data;
    private int _offset;
    private int _offsetArea;

    public SCSTelemetry Convert(byte[] structureDataBytes)
    {
      this._offsetArea = 0;
      this.SetOffset();
      this._data = structureDataBytes;
      SCSTelemetry scsTelemetry = new SCSTelemetry();
      scsTelemetry.SdkActive = this.GetBool();
      this.GetBoolArray(3);
      scsTelemetry.Paused = this.GetBool();
      this.GetBoolArray(3);
      scsTelemetry.Timestamp = this.GetULong();
      scsTelemetry.SimulationTimestamp = this.GetULong();
      scsTelemetry.RenderTimestamp = this.GetULong();
      this.NextOffsetArea();
      scsTelemetry.DllVersion = this.GetUint();
      scsTelemetry.GameVersion.Major = this.GetUint();
      scsTelemetry.GameVersion.Minor = this.GetUint();
      scsTelemetry.Game = this.GetUint().ToEnum<SCSGame>();
      scsTelemetry.TelemetryVersion.Major = this.GetUint();
      scsTelemetry.TelemetryVersion.Minor = this.GetUint();
      scsTelemetry.SetGameTime(this.GetUint());
      scsTelemetry.TruckValues.ConstantsValues.MotorValues.ForwardGearCount = this.GetUint();
      scsTelemetry.TruckValues.ConstantsValues.MotorValues.ReverseGearCount = this.GetUint();
      scsTelemetry.TruckValues.ConstantsValues.MotorValues.RetarderStepCount = this.GetUint();
      scsTelemetry.TruckValues.ConstantsValues.WheelsValues.Count = this.GetUint();
      scsTelemetry.TruckValues.ConstantsValues.MotorValues.SelectorCount = this.GetUint();
      scsTelemetry.JobValues.DeliveryTime = (SCSTelemetry.Time) this.GetUint();
      scsTelemetry.MaxTrailerCount = this.GetUint();
      scsTelemetry.JobValues.CargoValues.UnitCount = this.GetUint();
      scsTelemetry.JobValues.PlannedDistanceKm = this.GetUint();
      scsTelemetry.TruckValues.CurrentValues.MotorValues.GearValues.HShifterSlot = this.GetUint();
      scsTelemetry.TruckValues.CurrentValues.MotorValues.BrakeValues.RetarderLevel = this.GetUint();
      scsTelemetry.TruckValues.CurrentValues.LightsValues.AuxFront = this.GetUint().ToEnum<AuxLevel>();
      scsTelemetry.TruckValues.CurrentValues.LightsValues.AuxRoof = this.GetUint().ToEnum<AuxLevel>();
      scsTelemetry.TruckValues.CurrentValues.WheelsValues.Substance = this.GetUintArray(16);
      scsTelemetry.TruckValues.ConstantsValues.MotorValues.SlotHandlePosition = this.GetUintArray(32);
      scsTelemetry.TruckValues.ConstantsValues.MotorValues.SlotSelectors = this.GetUintArray(32);
      scsTelemetry.GamePlay.JobDelivered.DeliveryTime = (SCSTelemetry.Time) this.GetUint();
      SCSTelemetry.Time time1 = new SCSTelemetry.Time(this.GetUint());
      scsTelemetry.GamePlay.JobCancelled.Started = time1;
      scsTelemetry.GamePlay.JobDelivered.Started = time1;
      SCSTelemetry.Time time2 = new SCSTelemetry.Time(this.GetUint());
      scsTelemetry.GamePlay.JobCancelled.Finished = time2;
      scsTelemetry.GamePlay.JobDelivered.Finished = time2;
      this.NextOffsetArea();
      scsTelemetry.CommonValues.NextRestStop = (SCSTelemetry.Frequency) this.GetInt();
      scsTelemetry.TruckValues.CurrentValues.MotorValues.GearValues.Selected = this.GetInt();
      scsTelemetry.TruckValues.CurrentValues.DashboardValues.GearDashboards = this.GetInt();
      scsTelemetry.TruckValues.ConstantsValues.MotorValues.SlotGear = this.GetIntArray(32);
      scsTelemetry.GamePlay.JobDelivered.EarnedXp = this.GetInt();
      this.NextOffsetArea();
      scsTelemetry.CommonValues.Scale = this.GetFloat();
      scsTelemetry.TruckValues.ConstantsValues.CapacityValues.Fuel = this.GetFloat();
      scsTelemetry.TruckValues.ConstantsValues.WarningFactorValues.Fuel = this.GetFloat();
      scsTelemetry.TruckValues.ConstantsValues.CapacityValues.AdBlue = this.GetFloat();
      scsTelemetry.TruckValues.ConstantsValues.WarningFactorValues.AdBlue = this.GetFloat();
      scsTelemetry.TruckValues.ConstantsValues.WarningFactorValues.AirPressure = this.GetFloat();
      scsTelemetry.TruckValues.ConstantsValues.WarningFactorValues.AirPressureEmergency = this.GetFloat();
      scsTelemetry.TruckValues.ConstantsValues.WarningFactorValues.OilPressure = this.GetFloat();
      scsTelemetry.TruckValues.ConstantsValues.WarningFactorValues.WaterTemperature = this.GetFloat();
      scsTelemetry.TruckValues.ConstantsValues.WarningFactorValues.BatteryVoltage = this.GetFloat();
      scsTelemetry.TruckValues.ConstantsValues.MotorValues.EngineRpmMax = this.GetFloat();
      scsTelemetry.TruckValues.ConstantsValues.MotorValues.DifferentialRation = this.GetFloat();
      scsTelemetry.JobValues.CargoValues.Mass = this.GetFloat();
      scsTelemetry.TruckValues.ConstantsValues.WheelsValues.Radius = this.GetFloatArray(16);
      scsTelemetry.TruckValues.ConstantsValues.MotorValues.GearRatiosForward = this.GetFloatArray(24);
      scsTelemetry.TruckValues.ConstantsValues.MotorValues.GearRatiosReverse = this.GetFloatArray(8);
      scsTelemetry.JobValues.CargoValues.UnitMass = this.GetFloat();
      scsTelemetry.TruckValues.CurrentValues.DashboardValues.Speed.Value = this.GetFloat();
      scsTelemetry.TruckValues.CurrentValues.DashboardValues.RPM = this.GetFloat();
      scsTelemetry.ControlValues.InputValues.Steering = this.GetFloat();
      scsTelemetry.ControlValues.InputValues.Throttle = this.GetFloat();
      scsTelemetry.ControlValues.InputValues.Brake = this.GetFloat();
      scsTelemetry.ControlValues.InputValues.Clutch = this.GetFloat();
      scsTelemetry.ControlValues.GameValues.Steering = this.GetFloat();
      scsTelemetry.ControlValues.GameValues.Throttle = this.GetFloat();
      scsTelemetry.ControlValues.GameValues.Brake = this.GetFloat();
      scsTelemetry.ControlValues.GameValues.Clutch = this.GetFloat();
      scsTelemetry.TruckValues.CurrentValues.DashboardValues.CruiseControlSpeed.Value = this.GetFloat();
      scsTelemetry.TruckValues.CurrentValues.MotorValues.BrakeValues.AirPressure = this.GetFloat();
      scsTelemetry.TruckValues.CurrentValues.MotorValues.BrakeValues.Temperature = this.GetFloat();
      scsTelemetry.TruckValues.CurrentValues.DashboardValues.FuelValue.Amount = this.GetFloat();
      scsTelemetry.TruckValues.CurrentValues.DashboardValues.FuelValue.AverageConsumption = this.GetFloat();
      scsTelemetry.TruckValues.CurrentValues.DashboardValues.FuelValue.Range = this.GetFloat();
      scsTelemetry.TruckValues.CurrentValues.DashboardValues.AdBlue = this.GetFloat();
      scsTelemetry.TruckValues.CurrentValues.DashboardValues.OilPressure = this.GetFloat();
      scsTelemetry.TruckValues.CurrentValues.DashboardValues.OilTemperature = this.GetFloat();
      scsTelemetry.TruckValues.CurrentValues.DashboardValues.WaterTemperature = this.GetFloat();
      scsTelemetry.TruckValues.CurrentValues.DashboardValues.BatteryVoltage = this.GetFloat();
      scsTelemetry.TruckValues.CurrentValues.LightsValues.DashboardBacklight = this.GetFloat();
      scsTelemetry.TruckValues.CurrentValues.DamageValues.Engine = this.GetFloat();
      scsTelemetry.TruckValues.CurrentValues.DamageValues.Transmission = this.GetFloat();
      scsTelemetry.TruckValues.CurrentValues.DamageValues.Cabin = this.GetFloat();
      scsTelemetry.TruckValues.CurrentValues.DamageValues.Chassis = this.GetFloat();
      scsTelemetry.TruckValues.CurrentValues.DamageValues.WheelsAvg = this.GetFloat();
      scsTelemetry.TruckValues.CurrentValues.DashboardValues.Odometer = this.GetFloat();
      scsTelemetry.NavigationValues.NavigationDistance = this.GetFloat();
      scsTelemetry.NavigationValues.NavigationTime = this.GetFloat();
      scsTelemetry.NavigationValues.SpeedLimit = (SCSTelemetry.Movement) this.GetFloat();
      scsTelemetry.TruckValues.CurrentValues.WheelsValues.SuspDeflection = this.GetFloatArray(16);
      scsTelemetry.TruckValues.CurrentValues.WheelsValues.Velocity = this.GetFloatArray(16);
      scsTelemetry.TruckValues.CurrentValues.WheelsValues.Steering = this.GetFloatArray(16);
      scsTelemetry.TruckValues.CurrentValues.WheelsValues.Rotation = this.GetFloatArray(16);
      scsTelemetry.TruckValues.CurrentValues.WheelsValues.Lift = this.GetFloatArray(16);
      scsTelemetry.TruckValues.CurrentValues.WheelsValues.LiftOffset = this.GetFloatArray(16);
      scsTelemetry.GamePlay.JobDelivered.CargoDamage = this.GetFloat();
      scsTelemetry.GamePlay.JobDelivered.DistanceKm = this.GetFloat();
      scsTelemetry.GamePlay.RefuelEvent.Amount = this.GetFloat();
      scsTelemetry.JobValues.CargoValues.CargoDamage = this.GetFloat();
      this.NextOffsetArea();
      scsTelemetry.TruckValues.ConstantsValues.WheelsValues.Steerable = this.GetBoolArray(16);
      scsTelemetry.TruckValues.ConstantsValues.WheelsValues.Simulated = this.GetBoolArray(16);
      scsTelemetry.TruckValues.ConstantsValues.WheelsValues.Powered = this.GetBoolArray(16);
      scsTelemetry.TruckValues.ConstantsValues.WheelsValues.Liftable = this.GetBoolArray(16);
      scsTelemetry.JobValues.CargoLoaded = this.GetBool();
      scsTelemetry.JobValues.SpecialJob = this.GetBool();
      scsTelemetry.TruckValues.CurrentValues.MotorValues.BrakeValues.ParkingBrake = this.GetBool();
      scsTelemetry.TruckValues.CurrentValues.MotorValues.BrakeValues.MotorBrake = this.GetBool();
      scsTelemetry.TruckValues.CurrentValues.DashboardValues.WarningValues.AirPressure = this.GetBool();
      scsTelemetry.TruckValues.CurrentValues.DashboardValues.WarningValues.AirPressureEmergency = this.GetBool();
      scsTelemetry.TruckValues.CurrentValues.DashboardValues.WarningValues.FuelW = this.GetBool();
      scsTelemetry.TruckValues.CurrentValues.DashboardValues.WarningValues.AdBlue = this.GetBool();
      scsTelemetry.TruckValues.CurrentValues.DashboardValues.WarningValues.OilPressure = this.GetBool();
      scsTelemetry.TruckValues.CurrentValues.DashboardValues.WarningValues.WaterTemperature = this.GetBool();
      scsTelemetry.TruckValues.CurrentValues.DashboardValues.WarningValues.BatteryVoltage = this.GetBool();
      scsTelemetry.TruckValues.CurrentValues.ElectricEnabled = this.GetBool();
      scsTelemetry.TruckValues.CurrentValues.EngineEnabled = this.GetBool();
      scsTelemetry.TruckValues.CurrentValues.DashboardValues.Wipers = this.GetBool();
      scsTelemetry.TruckValues.CurrentValues.LightsValues.BlinkerLeftActive = this.GetBool();
      scsTelemetry.TruckValues.CurrentValues.LightsValues.BlinkerRightActive = this.GetBool();
      scsTelemetry.TruckValues.CurrentValues.LightsValues.BlinkerLeftOn = this.GetBool();
      scsTelemetry.TruckValues.CurrentValues.LightsValues.BlinkerRightOn = this.GetBool();
      scsTelemetry.TruckValues.CurrentValues.LightsValues.Parking = this.GetBool();
      scsTelemetry.TruckValues.CurrentValues.LightsValues.BeamLow = this.GetBool();
      scsTelemetry.TruckValues.CurrentValues.LightsValues.BeamHigh = this.GetBool();
      scsTelemetry.TruckValues.CurrentValues.LightsValues.Beacon = this.GetBool();
      scsTelemetry.TruckValues.CurrentValues.LightsValues.Brake = this.GetBool();
      scsTelemetry.TruckValues.CurrentValues.LightsValues.Reverse = this.GetBool();
      scsTelemetry.TruckValues.CurrentValues.DashboardValues.CruiseControl = this.GetBool();
      scsTelemetry.TruckValues.CurrentValues.WheelsValues.OnGround = this.GetBoolArray(16);
      scsTelemetry.TruckValues.CurrentValues.MotorValues.GearValues.HShifterSelector = this.GetBoolArray(2);
      scsTelemetry.GamePlay.JobDelivered.AutoParked = this.GetBool();
      scsTelemetry.GamePlay.JobDelivered.AutoLoaded = this.GetBool();
      this.NextOffsetArea();
      scsTelemetry.TruckValues.Positioning.Cabin = this.GetFVector();
      scsTelemetry.TruckValues.Positioning.Head = this.GetFVector();
      scsTelemetry.TruckValues.Positioning.Hook = this.GetFVector();
      SCSTelemetry.FVector[] fvectorArray = new SCSTelemetry.FVector[16];
      for (int index = 0; index < 16; ++index)
        fvectorArray[index] = new SCSTelemetry.FVector()
        {
          X = this.GetFloat()
        };
      for (int index = 0; index < 16; ++index)
        fvectorArray[index].Y = this.GetFloat();
      for (int index = 0; index < 16; ++index)
        fvectorArray[index].Z = this.GetFloat();
      scsTelemetry.TruckValues.ConstantsValues.WheelsValues.PositionValues = fvectorArray;
      scsTelemetry.TruckValues.CurrentValues.AccelerationValues.LinearVelocity = this.GetFVector();
      scsTelemetry.TruckValues.CurrentValues.AccelerationValues.AngularVelocity = this.GetFVector();
      scsTelemetry.TruckValues.CurrentValues.AccelerationValues.LinearAcceleration = this.GetFVector();
      scsTelemetry.TruckValues.CurrentValues.AccelerationValues.AngularAcceleration = this.GetFVector();
      scsTelemetry.TruckValues.CurrentValues.AccelerationValues.CabinAngularVelocity = this.GetFVector();
      scsTelemetry.TruckValues.CurrentValues.AccelerationValues.CabinAngularAcceleration = this.GetFVector();
      this.NextOffsetArea();
      scsTelemetry.TruckValues.Positioning.CabinOffset = this.GetFPlacement();
      scsTelemetry.TruckValues.Positioning.HeadOffset = this.GetFPlacement();
      this.NextOffsetArea();
      scsTelemetry.SetTruckPosition(this.GetDPlacement());
      this.NextOffsetArea();
      scsTelemetry.TruckValues.ConstantsValues.BrandId = this.GetString(64);
      scsTelemetry.TruckValues.ConstantsValues.Brand = this.GetString(64);
      scsTelemetry.TruckValues.ConstantsValues.Id = this.GetString(64);
      scsTelemetry.TruckValues.ConstantsValues.Name = this.GetString(64);
      scsTelemetry.JobValues.CargoValues.Id = this.GetString(64);
      scsTelemetry.JobValues.CargoValues.Name = this.GetString(64);
      scsTelemetry.JobValues.CityDestinationId = this.GetString(64);
      scsTelemetry.JobValues.CityDestination = this.GetString(64);
      scsTelemetry.JobValues.CompanyDestinationId = this.GetString(64);
      scsTelemetry.JobValues.CompanyDestination = this.GetString(64);
      scsTelemetry.JobValues.CitySourceId = this.GetString(64);
      scsTelemetry.JobValues.CitySource = this.GetString(64);
      scsTelemetry.JobValues.CompanySourceId = this.GetString(64);
      scsTelemetry.JobValues.CompanySource = this.GetString(64);
      string enumString1 = this.GetString(16);
      if (enumString1 != null && enumString1.Length > 0)
        scsTelemetry.TruckValues.ConstantsValues.MotorValues.ShifterTypeValue = enumString1.ToEnum<ShifterType>();
      scsTelemetry.TruckValues.ConstantsValues.LicensePlate = this.GetString(64);
      scsTelemetry.TruckValues.ConstantsValues.LicensePlateCountryId = this.GetString(64);
      scsTelemetry.TruckValues.ConstantsValues.LicensePlateCountry = this.GetString(64);
      string enumString2 = this.GetString(32);
      if (enumString2 != null && enumString2.Length > 0)
        scsTelemetry.JobValues.Market = enumString2.ToEnum<JobMarket>();
      string enumString3 = this.GetString(16);
      if (enumString3 != null && enumString3.Length > 0)
        scsTelemetry.GamePlay.FinedEvent.Offence = enumString3.ToEnum<Offence>();
      scsTelemetry.GamePlay.FerryEvent.SourceName = this.GetString(64);
      scsTelemetry.GamePlay.FerryEvent.TargetName = this.GetString(64);
      scsTelemetry.GamePlay.FerryEvent.SourceId = this.GetString(64);
      scsTelemetry.GamePlay.FerryEvent.TargetId = this.GetString(64);
      scsTelemetry.GamePlay.TrainEvent.SourceName = this.GetString(64);
      scsTelemetry.GamePlay.TrainEvent.TargetName = this.GetString(64);
      scsTelemetry.GamePlay.TrainEvent.SourceId = this.GetString(64);
      scsTelemetry.GamePlay.TrainEvent.TargetId = this.GetString(64);
      this.NextOffsetArea();
      scsTelemetry.JobValues.Income = this.GetULong();
      this.NextOffsetArea();
      scsTelemetry.GamePlay.JobCancelled.Penalty = this.GetLong();
      scsTelemetry.GamePlay.JobDelivered.Revenue = this.GetLong();
      scsTelemetry.GamePlay.FinedEvent.Amount = this.GetLong();
      scsTelemetry.GamePlay.TollgateEvent.PayAmount = this.GetLong();
      scsTelemetry.GamePlay.FerryEvent.PayAmount = this.GetLong();
      scsTelemetry.GamePlay.TrainEvent.PayAmount = this.GetLong();
      this.NextOffsetArea();
      scsTelemetry.SpecialEventsValues.OnJob = this.GetBool();
      scsTelemetry.SpecialEventsValues.JobFinished = this.GetBool();
      scsTelemetry.SpecialEventsValues.JobCancelled = this.GetBool();
      scsTelemetry.SpecialEventsValues.JobDelivered = this.GetBool();
      scsTelemetry.SpecialEventsValues.Fined = this.GetBool();
      scsTelemetry.SpecialEventsValues.Tollgate = this.GetBool();
      scsTelemetry.SpecialEventsValues.Ferry = this.GetBool();
      scsTelemetry.SpecialEventsValues.Train = this.GetBool();
      scsTelemetry.SpecialEventsValues.Refuel = this.GetBool();
      scsTelemetry.SpecialEventsValues.RefuelPayed = this.GetBool();
      this.NextOffsetArea();
      for (int index = 0; index < 25; ++index)
      {
        string str = this.GetString(64);
        if ((uint) str.Length > 0U)
          scsTelemetry.Substances.Add(new SCSTelemetry.Substance()
          {
            Index = index,
            Value = str
          });
      }
      this.NextOffsetArea();
      scsTelemetry.TrailerValues = this.GetTrailers();
      return scsTelemetry;
    }

    private bool GetBool()
    {
      byte num = this._data[this._offset];
      ++this._offset;
      return num > (byte) 0;
    }

    private uint GetUint()
    {
      while ((uint) (this._offset % 4) > 0U)
        ++this._offset;
      uint num = (uint) ((int) this._data[this._offset + 3] << 24 | (int) this._data[this._offset + 2] << 16 | (int) this._data[this._offset + 1] << 8) | (uint) this._data[this._offset];
      this._offset += 4;
      return num;
    }

    private float GetFloat()
    {
      while ((uint) (this._offset % 4) > 0U)
        ++this._offset;
      byte[] numArray = new byte[4]
      {
        this._data[this._offset],
        this._data[this._offset + 1],
        this._data[this._offset + 2],
        this._data[this._offset + 3]
      };
      this._offset += 4;
      return BitConverter.ToSingle(numArray, 0);
    }

    private double GetDouble()
    {
      while ((uint) (this._offset % 4) > 0U)
        ++this._offset;
      byte[] numArray = new byte[8]
      {
        this._data[this._offset],
        this._data[this._offset + 1],
        this._data[this._offset + 2],
        this._data[this._offset + 3],
        this._data[this._offset + 4],
        this._data[this._offset + 5],
        this._data[this._offset + 6],
        this._data[this._offset + 7]
      };
      this._offset += 8;
      return BitConverter.ToDouble(numArray, 0);
    }

    private int GetInt()
    {
      while ((uint) (this._offset % 4) > 0U)
        ++this._offset;
      int num = (int) this._data[this._offset + 3] << 24 | (int) this._data[this._offset + 2] << 16 | (int) this._data[this._offset + 1] << 8 | (int) this._data[this._offset];
      this._offset += 4;
      return num;
    }

    private byte[] GetSubArray(int length)
    {
      byte[] numArray = new byte[length];
      for (int index = 0; index < length; ++index)
        numArray[index] = this._data[this._offset + index];
      this._offset += length;
      return numArray;
    }

    private void NextOffsetArea()
    {
      ++this._offsetArea;
      this.SetOffset();
    }

    private void SetOffset()
    {
      if (this._offsetArea >= this._offsetAreas.Length)
        return;
      this._offset = this._offsetAreas[this._offsetArea];
    }

    private void SetOffset(int off)
    {
      this._offset += off;
    }

    private string GetString(int length = 64)
    {
      return Encoding.UTF8.GetString(this.GetSubArray(length)).Replace(char.MinValue, ' ').Trim();
    }

    private uint[] GetUintArray(int length)
    {
      uint[] numArray = new uint[length];
      for (int index = 0; index < length; ++index)
        numArray[index] = this.GetUint();
      return numArray;
    }

    private int[] GetIntArray(int length)
    {
      int[] numArray = new int[length];
      for (int index = 0; index < length; ++index)
        numArray[index] = this.GetInt();
      return numArray;
    }

    private float[] GetFloatArray(int length)
    {
      float[] numArray = new float[length];
      for (int index = 0; index < length; ++index)
        numArray[index] = this.GetFloat();
      return numArray;
    }

    private bool[] GetBoolArray(int length)
    {
      bool[] flagArray = new bool[length];
      for (int index = 0; index < length; ++index)
        flagArray[index] = this.GetBool();
      return flagArray;
    }

    private SCSTelemetry.FVector GetFVector()
    {
      return new SCSTelemetry.FVector()
      {
        X = this.GetFloat(),
        Y = this.GetFloat(),
        Z = this.GetFloat()
      };
    }

    private SCSTelemetry.FVector[] GetFVectorArray(int length)
    {
      SCSTelemetry.FVector[] fvectorArray = new SCSTelemetry.FVector[length];
      for (int index = 0; index < length; ++index)
        fvectorArray[index] = new SCSTelemetry.FVector()
        {
          X = this.GetFloat()
        };
      for (int index = 0; index < length; ++index)
        fvectorArray[index].Y = this.GetFloat();
      for (int index = 0; index < length; ++index)
        fvectorArray[index].Z = this.GetFloat();
      return fvectorArray;
    }

    private SCSTelemetry.DVector GetDVector()
    {
      return new SCSTelemetry.DVector()
      {
        X = this.GetDouble(),
        Y = this.GetDouble(),
        Z = this.GetDouble()
      };
    }

    private SCSTelemetry.Euler GetEuler()
    {
      return new SCSTelemetry.Euler()
      {
        Heading = this.GetFloat(),
        Pitch = this.GetFloat(),
        Roll = this.GetFloat()
      };
    }

    private SCSTelemetry.Euler GetDEuler()
    {
      return new SCSTelemetry.Euler()
      {
        Heading = (float) this.GetDouble(),
        Pitch = (float) this.GetDouble(),
        Roll = (float) this.GetDouble()
      };
    }

    private SCSTelemetry.FPlacement GetFPlacement()
    {
      return new SCSTelemetry.FPlacement()
      {
        Position = this.GetFVector(),
        Orientation = this.GetEuler()
      };
    }

    private SCSTelemetry.DPlacement GetDPlacement()
    {
      return new SCSTelemetry.DPlacement()
      {
        Position = this.GetDVector(),
        Orientation = this.GetDEuler()
      };
    }

    private long GetLong()
    {
      byte[] numArray = new byte[8]
      {
        this._data[this._offset],
        this._data[this._offset + 1],
        this._data[this._offset + 2],
        this._data[this._offset + 3],
        this._data[this._offset + 4],
        this._data[this._offset + 5],
        this._data[this._offset + 6],
        this._data[this._offset + 7]
      };
      this._offset += 8;
      return BitConverter.ToInt64(numArray, 0);
    }

    private ulong GetULong()
    {
      byte[] numArray = new byte[8]
      {
        this._data[this._offset],
        this._data[this._offset + 1],
        this._data[this._offset + 2],
        this._data[this._offset + 3],
        this._data[this._offset + 4],
        this._data[this._offset + 5],
        this._data[this._offset + 6],
        this._data[this._offset + 7]
      };
      this._offset += 8;
      return BitConverter.ToUInt64(numArray, 0);
    }

    private SCSTelemetry.Trailer[] GetTrailers()
    {
      SCSTelemetry.Trailer[] trailerArray = new SCSTelemetry.Trailer[10];
      for (int index = 0; index < 10; ++index)
        trailerArray[index] = this.GetTrailer();
      return trailerArray;
    }

    private SCSTelemetry.Trailer GetTrailer()
    {
      SCSTelemetry.Trailer trailer = new SCSTelemetry.Trailer();
      trailer.WheelsConstant.Steerable = this.GetBoolArray(16);
      trailer.WheelsConstant.Simulated = this.GetBoolArray(16);
      trailer.WheelsConstant.Powered = this.GetBoolArray(16);
      trailer.WheelsConstant.Liftable = this.GetBoolArray(16);
      trailer.Wheelvalues.OnGround = this.GetBoolArray(16);
      trailer.Attached = this.GetBool();
      this.SetOffset(3);
      trailer.Wheelvalues.Substance = this.GetUintArray(16);
      trailer.WheelsConstant.Count = this.GetUint();
      trailer.DamageValues.Cargo = this.GetFloat();
      trailer.DamageValues.Chassis = this.GetFloat();
      trailer.DamageValues.Wheels = this.GetFloat();
      trailer.Wheelvalues.SuspDeflection = this.GetFloatArray(16);
      trailer.Wheelvalues.Velocity = this.GetFloatArray(16);
      trailer.Wheelvalues.Steering = this.GetFloatArray(16);
      trailer.Wheelvalues.Rotation = this.GetFloatArray(16);
      trailer.Wheelvalues.Lift = this.GetFloatArray(16);
      trailer.Wheelvalues.LiftOffset = this.GetFloatArray(16);
      trailer.WheelsConstant.Radius = this.GetFloatArray(16);
      trailer.AccelerationValues.LinearVelocity = this.GetFVector();
      trailer.AccelerationValues.AngularVelocity = this.GetFVector();
      trailer.AccelerationValues.LinearAcceleration = this.GetFVector();
      trailer.AccelerationValues.AngularAcceleration = this.GetFVector();
      trailer.Hook = this.GetFVector();
      trailer.WheelsConstant.PositionValues = this.GetFVectorArray(16);
      trailer.Position = this.GetDPlacement();
      trailer.Id = this.GetString(64);
      trailer.CargoAccessoryId = this.GetString(64);
      trailer.BodyType = this.GetString(64);
      trailer.BrandId = this.GetString(64);
      trailer.Brand = this.GetString(64);
      trailer.Name = this.GetString(64);
      trailer.ChainType = this.GetString(64);
      trailer.LicensePlate = this.GetString(64);
      trailer.LicensePlateCountry = this.GetString(64);
      trailer.LicensePlateCountryId = this.GetString(64);
      return trailer;
    }
  }
}
