// Decompiled with JetBrains decompiler
// Type: SCSSdkClient.Object.SCSTelemetry
// Assembly: TB Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1A007F5D-635A-4205-BA63-50EE7F34DE72
// Assembly location: C:\Program Files (x86)\TrucksBook Client\TB Client.exe

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace SCSSdkClient.Object
{
  public class SCSTelemetry
  {
    private const float PiTimes2 = 6.283185f;

    public static SCSTelemetry instance;

    public SCSTelemetry()
    {
      this.GameVersion = new SCSTelemetry.Version();
      this.TelemetryVersion = new SCSTelemetry.Version();
      this.TruckValues = new SCSTelemetry.Truck();
      this.JobValues = new SCSTelemetry.Job();
      this.CommonValues = new SCSTelemetry.Common();
      this.ControlValues = new SCSTelemetry.Control();
      this.NavigationValues = new SCSTelemetry.Navigation();
      this.SpecialEventsValues = new SCSTelemetry.SpecialEvents();
      this.Substances = new List<SCSTelemetry.Substance>();
      this.GamePlay = new SCSTelemetry.GamePlayEvents();
    }


    public bool SdkActive { get; internal set; }

    public ulong Timestamp { get; internal set; }

    public ulong SimulationTimestamp { get; internal set; }

    public ulong RenderTimestamp { get; internal set; }

    public bool Paused { get; internal set; }

    public SCSGame Game { get; internal set; }

    public SCSTelemetry.Version GameVersion { get; internal set; }

    public uint DllVersion { get; internal set; }

    public SCSTelemetry.Version TelemetryVersion { get; internal set; }

    public SCSTelemetry.Common CommonValues { get; internal set; }

    public SCSTelemetry.Truck TruckValues { get; internal set; }

    public SCSTelemetry.Trailer[] TrailerValues { get; internal set; }

    public SCSTelemetry.Job JobValues { get; internal set; }

    public SCSTelemetry.Control ControlValues { get; internal set; }

    public SCSTelemetry.Navigation NavigationValues { get; internal set; }

    public SCSTelemetry.SpecialEvents SpecialEventsValues { get; internal set; }

    public List<SCSTelemetry.Substance> Substances { get; internal set; }

    public uint MaxTrailerCount { get; internal set; }

    public SCSTelemetry.GamePlayEvents GamePlay { get; internal set; }

    internal static DateTime MinutesToDate(uint minutes)
    {
      return new DateTime((long) minutes * 10000000L * 60L, DateTimeKind.Utc);
    }

    internal static DateTime MinutesToDate(int minutes)
    {
      return new DateTime((long) Math.Abs(minutes) * 10000000L * 60L, DateTimeKind.Utc);
    }

    public static SCSTelemetry.FVector Add(
      SCSTelemetry.FVector first,
      SCSTelemetry.FVector second)
    {
      return new SCSTelemetry.FVector()
      {
        X = first.X + second.X,
        Y = first.Y + second.Y,
        Z = first.Z + second.Z
      };
    }

    public static SCSTelemetry.DVector Add(
      SCSTelemetry.DVector first,
      SCSTelemetry.FVector second)
    {
      return new SCSTelemetry.DVector()
      {
        X = first.X + (double) second.X,
        Y = first.Y + (double) second.Y,
        Z = first.Z + (double) second.Z
      };
    }

    public static SCSTelemetry.FVector Rotate(
      SCSTelemetry.Euler orientation,
      SCSTelemetry.FVector vector)
    {
      float num1 = orientation.Heading * 6.283185f;
      float num2 = orientation.Pitch * 6.283185f;
      float num3 = orientation.Roll * 6.283185f;
      double num4 = Math.Cos((double) num1);
      double num5 = Math.Sin((double) num1);
      double num6 = Math.Cos((double) num2);
      double num7 = Math.Sin((double) num2);
      double num8 = Math.Cos((double) num3);
      double num9 = Math.Sin((double) num3);
      double num10 = (double) vector.X * num8 - (double) vector.Y * num9;
      double num11 = (double) vector.X * num9 + (double) vector.Y * num8;
      float z = vector.Z;
      double num12 = num10;
      double num13 = num11 * num6 - (double) z * num7;
      double num14 = num11 * num7 + (double) z * num6;
      return new SCSTelemetry.FVector()
      {
        X = (float) (num12 * num4 + num14 * num5),
        Y = (float) num13,
        Z = (float) (-num12 * num5 + num14 * num4)
      };
    }

    internal void SetGameTime(uint gameTime)
    {
      this.CommonValues.GameTime.Value = gameTime;
      if (gameTime > 0U && gameTime < 4000000000U && this.JobValues.DeliveryTime.Value > 0U)
        this.JobValues.RemainingDeliveryTime.Value = (int) this.JobValues.DeliveryTime.Value - (int) gameTime;
      else
        this.JobValues.RemainingDeliveryTime.Value = 0;
    }

    internal void SetTruckPosition(SCSTelemetry.DPlacement position)
    {
      this.TruckValues.CurrentValues.PositionValue = position;
      this.TruckValues.Positioning.TruckPosition = position;
    }

    public class Common
    {
      public Common()
      {
        this.GameTime = new SCSTelemetry.Time();
        this.NextRestStop = new SCSTelemetry.Frequency();
      }

      public float Scale { get; internal set; }

      public SCSTelemetry.Time GameTime { get; protected internal set; }

      public SCSTelemetry.Frequency NextRestStop { get; internal set; }

      public SCSTelemetry.Time NextRestStopTime
      {
        get
        {
          return new SCSTelemetry.Time()
          {
            Value = this.GameTime.Value + (uint) this.NextRestStop.Value
          };
        }
      }
    }

    public class Control
    {
      public Control()
      {
        this.InputValues = new SCSTelemetry.Control.Input();
        this.GameValues = new SCSTelemetry.Control.Game();
      }

      public SCSTelemetry.Control.Input InputValues { get; internal set; }

      public SCSTelemetry.Control.Game GameValues { get; internal set; }

      public override string ToString()
      {
        return "Input Values:\n\t" + this.InputValues.ToString().StringFormater() + "\nGame Values:\n\t" + this.GameValues.ToString().StringFormater();
      }

      public class Input
      {
        public float Steering { get; internal set; }

        public float Throttle { get; internal set; }

        public float Brake { get; internal set; }

        public float Clutch { get; internal set; }
      }

      public class Game
      {
        public float Steering { get; internal set; }

        public float Throttle { get; internal set; }

        public float Brake { get; internal set; }

        public float Clutch { get; internal set; }
      }
    }

    public class DPlacement
    {
      public SCSTelemetry.DVector Position { get; internal set; }

      public SCSTelemetry.Euler Orientation { get; internal set; }
    }

    public class DVector
    {
      public double X { get; internal set; }

      public double Y { get; internal set; }

      public double Z { get; internal set; }
    }

    public class Euler
    {
      public float Heading { get; internal set; }

      public float Pitch { get; internal set; }

      public float Roll { get; internal set; }
    }

    public class FPlacement
    {
      public SCSTelemetry.FVector Position { get; internal set; }

      public SCSTelemetry.Euler Orientation { get; internal set; }
    }

    public class Frequency
    {
      public Frequency(int i)
      {
        this.Value = i;
      }

      public Frequency()
      {
      }

      public int Value { get; internal set; }

      public DateTime Date
      {
        get
        {
          return SCSTelemetry.MinutesToDate(this.Value);
        }
      }

      public static implicit operator SCSTelemetry.Frequency(int i)
      {
        return new SCSTelemetry.Frequency(i);
      }
    }

    public class FVector
    {
      public float X { get; internal set; }

      public float Y { get; internal set; }

      public float Z { get; internal set; }
    }

    public class GamePlayEvents
    {
      public SCSTelemetry.GamePlayEvents.Transport FerryEvent;
      public SCSTelemetry.GamePlayEvents.Fined FinedEvent;
      public SCSTelemetry.GamePlayEvents.Cancelled JobCancelled;
      public SCSTelemetry.GamePlayEvents.Delivered JobDelivered;
      public SCSTelemetry.GamePlayEvents.Tollgate TollgateEvent;
      public SCSTelemetry.GamePlayEvents.Transport TrainEvent;
      public SCSTelemetry.GamePlayEvents.Refuel RefuelEvent;

      public GamePlayEvents()
      {
        this.JobCancelled = new SCSTelemetry.GamePlayEvents.Cancelled();
        this.JobDelivered = new SCSTelemetry.GamePlayEvents.Delivered();
        this.FinedEvent = new SCSTelemetry.GamePlayEvents.Fined();
        this.TollgateEvent = new SCSTelemetry.GamePlayEvents.Tollgate();
        this.TrainEvent = new SCSTelemetry.GamePlayEvents.Transport();
        this.FerryEvent = new SCSTelemetry.GamePlayEvents.Transport();
        this.RefuelEvent = new SCSTelemetry.GamePlayEvents.Refuel();
      }

      public class Cancelled
      {
        public long Penalty { get; internal set; }

        public SCSTelemetry.Time Finished { get; internal set; }

        public SCSTelemetry.Time Started { get; internal set; }
      }

      public class Delivered
      {
        public bool AutoLoaded { get; internal set; }

        public bool AutoParked { get; internal set; }

        public float CargoDamage { get; internal set; }

        public SCSTelemetry.Time DeliveryTime { get; internal set; }

        public float DistanceKm { get; internal set; }

        public int EarnedXp { get; internal set; }

        public long Revenue { get; internal set; }

        public SCSTelemetry.Time Finished { get; internal set; }

        public SCSTelemetry.Time Started { get; internal set; }

        public SCSTelemetry.Time StartedBackup
        {
          get
          {
            return this.Finished - this.DeliveryTime;
          }
        }
      }

      public class Fined
      {
        public long Amount { get; internal set; }

        public Offence Offence { get; internal set; }
      }

      public class Tollgate
      {
        public long PayAmount { get; internal set; }
      }

      public class Transport
      {
        public long PayAmount { get; internal set; }

        public string SourceId { get; internal set; }

        public string SourceName { get; internal set; }

        public string TargetId { get; internal set; }

        public string TargetName { get; internal set; }
      }

      public class Refuel
      {
        public float Amount { get; internal set; }
      }
    }

    public class Job
    {
      public Job()
      {
        this.DeliveryTime = new SCSTelemetry.Time();
        this.RemainingDeliveryTime = new SCSTelemetry.Frequency();
        this.CargoValues = new SCSTelemetry.Job.Cargo();
      }

      public SCSTelemetry.Time DeliveryTime { get; internal set; }

      public SCSTelemetry.Frequency RemainingDeliveryTime { get; protected internal set; }

      public bool CargoLoaded { get; internal set; }

      public bool SpecialJob { get; internal set; }

      public JobMarket Market { get; internal set; }

      public uint PlannedDistanceKm { get; internal set; }

      public SCSTelemetry.Job.Cargo CargoValues { get; internal set; }

      public string CityDestinationId { get; internal set; }

      public string CityDestination { get; internal set; }

      public string CompanyDestinationId { get; internal set; }

      public string CompanyDestination { get; internal set; }

      public string CitySourceId { get; internal set; }

      public string CitySource { get; internal set; }

      public string CompanySourceId { get; internal set; }

      public string CompanySource { get; internal set; }

      public ulong Income { get; internal set; }

      public class Cargo
      {
        public float Mass { get; internal set; }

        public string Id { get; internal set; }

        public string Name { get; internal set; }

        public uint UnitCount { get; internal set; }

        public float UnitMass { get; internal set; }

        public float CargoDamage { get; internal set; }
      }
    }

    public class Movement
    {
      public Movement(float f)
      {
        this.Value = f;
      }

      public Movement()
      {
      }

      public float Value { get; internal set; }

      public float Kph
      {
        get
        {
          return this.Value * 3.6f;
        }
      }

      public float Mph
      {
        get
        {
          return this.Value * 2.25f;
        }
      }

      public static implicit operator SCSTelemetry.Movement(float f)
      {
        return new SCSTelemetry.Movement(f);
      }
    }

    public class Navigation
    {
      public Navigation()
      {
        this.SpeedLimit = new SCSTelemetry.Movement();
      }

      public float NavigationDistance { get; internal set; }

      public float NavigationTime { get; internal set; }

      public SCSTelemetry.Movement SpeedLimit { get; internal set; }
    }

    public class SpecialEvents
    {
      public bool OnJob { get; internal set; }

      public bool JobFinished { get; internal set; }

      public bool JobCancelled { get; internal set; }

      public bool JobDelivered { get; internal set; }

      public bool Fined { get; internal set; }

      public bool Tollgate { get; internal set; }

      public bool Ferry { get; internal set; }

      public bool Train { get; internal set; }

      public bool Refuel { get; internal set; }

      public bool RefuelPayed { get; internal set; }
    }

    public class Substance
    {
      public int Index { get; internal set; }

      public string Value { get; internal set; }
    }

    public class Time
    {
      public Time(uint i)
      {
        this.Value = i;
      }

      public Time()
      {
      }

      public uint Value { get; internal set; }

      public DateTime Date
      {
        get
        {
          return SCSTelemetry.MinutesToDate(this.Value);
        }
      }

      public static implicit operator SCSTelemetry.Time(uint i)
      {
        return new SCSTelemetry.Time(i);
      }

      public static SCSTelemetry.Time operator -(
        SCSTelemetry.Time a,
        SCSTelemetry.Time b)
      {
        return new SCSTelemetry.Time(a.Value - b.Value);
      }
    }

    public class Trailer
    {
      public Trailer()
      {
        this.Wheelvalues = new SCSTelemetry.Trailer.Wheels();
        this.AccelerationValues = new SCSTelemetry.Trailer.Acceleration();
        this.WheelsConstant = new SCSTelemetry.WheelsConstants();
        this.Hook = new SCSTelemetry.FVector();
        this.DamageValues = new SCSTelemetry.Trailer.Damage();
      }

      public bool Attached { get; internal set; }

      public SCSTelemetry.FVector Hook { get; internal set; }

      public SCSTelemetry.Trailer.Damage DamageValues { get; internal set; }

      public SCSTelemetry.Trailer.Wheels Wheelvalues { get; internal set; }

      public SCSTelemetry.WheelsConstants WheelsConstant { get; internal set; }

      public SCSTelemetry.Trailer.Acceleration AccelerationValues { get; internal set; }

      public SCSTelemetry.DPlacement Position { get; internal set; }

      public string Id { get; internal set; }

      public string CargoAccessoryId { get; internal set; }

      public string BodyType { get; internal set; }

      public string BrandId { get; internal set; }

      public string Brand { get; internal set; }

      public string Name { get; internal set; }

      public string ChainType { get; internal set; }

      public string LicensePlate { get; internal set; }

      public string LicensePlateCountry { get; internal set; }

      public string LicensePlateCountryId { get; internal set; }

      public class Damage
      {
        public float Cargo { get; internal set; }

        public float Wheels { get; internal set; }

        public float Chassis { get; internal set; }
      }

      public class Wheels
      {
        public uint[] Substance { get; internal set; }

        public float[] SuspDeflection { get; internal set; }

        public float[] Velocity { get; internal set; }

        public float[] Steering { get; internal set; }

        public float[] Rotation { get; internal set; }

        public bool[] OnGround { get; internal set; }

        public float[] Lift { get; internal set; }

        public float[] LiftOffset { get; internal set; }
      }

      public class Acceleration
      {
        public SCSTelemetry.FVector LinearVelocity { get; internal set; }

        public SCSTelemetry.FVector AngularVelocity { get; internal set; }

        public SCSTelemetry.FVector LinearAcceleration { get; internal set; }

        public SCSTelemetry.FVector AngularAcceleration { get; internal set; }
      }
    }

    public class Truck
    {
      public Truck()
      {
        this.ConstantsValues = new SCSTelemetry.Truck.Constants();
        this.CurrentValues = new SCSTelemetry.Truck.Current();
        this.Positioning = new SCSTelemetry.PositionData();
      }

      public SCSTelemetry.Truck.Constants ConstantsValues { get; internal set; }

      public SCSTelemetry.Truck.Current CurrentValues { get; internal set; }

      public SCSTelemetry.PositionData Positioning { get; internal set; }

      public class Constants
      {
        public Constants()
        {
          this.MotorValues = new SCSTelemetry.Truck.Constants.Motor();
          this.CapacityValues = new SCSTelemetry.Truck.Constants.Capacity();
          this.WarningFactorValues = new SCSTelemetry.Truck.Constants.WarningFactor();
          this.WheelsValues = new SCSTelemetry.WheelsConstants();
        }

        public SCSTelemetry.Truck.Constants.Motor MotorValues { get; internal set; }

        public SCSTelemetry.Truck.Constants.Capacity CapacityValues { get; internal set; }

        public SCSTelemetry.Truck.Constants.WarningFactor WarningFactorValues { get; internal set; }

        public SCSTelemetry.WheelsConstants WheelsValues { get; internal set; }

        public string BrandId { get; internal set; }

        public string Brand { get; internal set; }

        public string Id { get; internal set; }

        public string Name { get; internal set; }

        public string LicensePlate { get; internal set; }

        public string LicensePlateCountryId { get; internal set; }

        public string LicensePlateCountry { get; internal set; }

        public class Motor
        {
          public uint ForwardGearCount { get; internal set; }

          public uint ReverseGearCount { get; internal set; }

          public uint RetarderStepCount { get; internal set; }

          public uint SelectorCount { get; internal set; }

          public int[] SlotGear { get; internal set; }

          public uint[] SlotHandlePosition { get; internal set; }

          public uint[] SlotSelectors { get; internal set; }

          public float EngineRpmMax { get; internal set; }

          public float DifferentialRation { get; internal set; }

          public float[] GearRatiosForward { get; internal set; }

          public float[] GearRatiosReverse { get; internal set; }

          public ShifterType ShifterTypeValue { get; internal set; }
        }

        public class Capacity
        {
          public float Fuel { get; internal set; }

          public float AdBlue { get; internal set; }
        }

        public class WarningFactor
        {
          public float Fuel { get; internal set; }

          public float AdBlue { get; internal set; }

          public float AirPressure { get; internal set; }

          public float AirPressureEmergency { get; internal set; }

          public float OilPressure { get; internal set; }

          public float WaterTemperature { get; internal set; }

          public float BatteryVoltage { get; internal set; }
        }
      }

      public class Current
      {
        public Current()
        {
          this.MotorValues = new SCSTelemetry.Truck.Current.Motor();
          this.DashboardValues = new SCSTelemetry.Truck.Current.Dashboard();
          this.LightsValues = new SCSTelemetry.Truck.Current.Lights();
          this.WheelsValues = new SCSTelemetry.Truck.Current.Wheels();
          this.DamageValues = new SCSTelemetry.Truck.Current.Damage();
          this.PositionValue = new SCSTelemetry.DPlacement();
          this.AccelerationValues = new SCSTelemetry.Truck.Current.Acceleration();
        }

        public bool ElectricEnabled { get; internal set; }

        public bool EngineEnabled { get; internal set; }

        public SCSTelemetry.Truck.Current.Motor MotorValues { get; internal set; }

        public SCSTelemetry.Truck.Current.Dashboard DashboardValues { get; internal set; }

        public SCSTelemetry.Truck.Current.Lights LightsValues { get; internal set; }

        public SCSTelemetry.Truck.Current.Wheels WheelsValues { get; internal set; }

        public SCSTelemetry.Truck.Current.Damage DamageValues { get; internal set; }

        public SCSTelemetry.Truck.Current.Acceleration AccelerationValues { get; internal set; }

        public SCSTelemetry.DPlacement PositionValue { get; protected internal set; }

        public class Motor
        {
          public Motor()
          {
            this.GearValues = new SCSTelemetry.Truck.Current.Motor.Gear();
            this.BrakeValues = new SCSTelemetry.Truck.Current.Motor.Brakes();
          }

          public SCSTelemetry.Truck.Current.Motor.Gear GearValues { get; internal set; }

          public SCSTelemetry.Truck.Current.Motor.Brakes BrakeValues { get; internal set; }

          public class Gear
          {
            public uint HShifterSlot { get; internal set; }

            public int Selected { get; internal set; }

            public bool[] HShifterSelector { get; internal set; }
          }

          public class Brakes
          {
            public uint RetarderLevel { get; internal set; }

            public float AirPressure { get; internal set; }

            public float Temperature { get; internal set; }

            public bool ParkingBrake { get; internal set; }

            public bool MotorBrake { get; internal set; }
          }
        }

        public class Dashboard
        {
          public Dashboard()
          {
            this.FuelValue = new SCSTelemetry.Truck.Current.Dashboard.Fuel();
            this.WarningValues = new SCSTelemetry.Truck.Current.Dashboard.Warnings();
            this.Speed = new SCSTelemetry.Movement();
            this.CruiseControlSpeed = new SCSTelemetry.Movement();
          }

          public SCSTelemetry.Truck.Current.Dashboard.Fuel FuelValue { get; internal set; }

          public SCSTelemetry.Truck.Current.Dashboard.Warnings WarningValues { get; internal set; }

          public int GearDashboards { get; internal set; }

          public SCSTelemetry.Movement Speed { get; internal set; }

          public SCSTelemetry.Movement CruiseControlSpeed { get; internal set; }

          public float AdBlue { get; internal set; }

          public float OilPressure { get; internal set; }

          public float OilTemperature { get; internal set; }

          public float WaterTemperature { get; internal set; }

          public float BatteryVoltage { get; internal set; }

          public float RPM { get; internal set; }

          public float Odometer { get; internal set; }

          public bool Wipers { get; internal set; }

          public bool CruiseControl { get; internal set; }

          public class Fuel
          {
            public float Amount { get; internal set; }

            public float AverageConsumption { get; internal set; }

            public float Range { get; internal set; }
          }

          public class Warnings
          {
            public bool AirPressure { get; internal set; }

            public bool AirPressureEmergency { get; internal set; }

            public bool FuelW { get; internal set; }

            public bool AdBlue { get; internal set; }

            public bool OilPressure { get; internal set; }

            public bool WaterTemperature { get; internal set; }

            public bool BatteryVoltage { get; internal set; }
          }
        }

        public class Lights
        {
          public AuxLevel AuxFront { get; internal set; }

          public AuxLevel AuxRoof { get; internal set; }

          public float DashboardBacklight { get; internal set; }

          public bool BlinkerLeftActive { get; internal set; }

          public bool BlinkerLeftOn { get; internal set; }

          public bool BlinkerRightActive { get; internal set; }

          public bool BlinkerRightOn { get; internal set; }

          public bool Parking { get; internal set; }

          public bool BeamLow { get; internal set; }

          public bool BeamHigh { get; internal set; }

          public bool Beacon { get; internal set; }

          public bool Brake { get; internal set; }

          public bool Reverse { get; internal set; }
        }

        public class Wheels
        {
          public uint[] Substance { get; internal set; }

          public float[] SuspDeflection { get; internal set; }

          public float[] Velocity { get; internal set; }

          public float[] Steering { get; internal set; }

          public float[] Rotation { get; internal set; }

          public float[] Lift { get; internal set; }

          public float[] LiftOffset { get; internal set; }

          public bool[] OnGround { get; internal set; }
        }

        public class Damage
        {
          public float Engine { get; internal set; }

          public float Transmission { get; internal set; }

          public float Cabin { get; internal set; }

          public float Chassis { get; internal set; }

          public float WheelsAvg { get; internal set; }
        }

        public class Acceleration
        {
          public SCSTelemetry.FVector LinearVelocity { get; internal set; }

          public SCSTelemetry.FVector AngularVelocity { get; internal set; }

          public SCSTelemetry.FVector LinearAcceleration { get; internal set; }

          public SCSTelemetry.FVector AngularAcceleration { get; internal set; }

          public SCSTelemetry.FVector CabinAngularVelocity { get; internal set; }

          public SCSTelemetry.FVector CabinAngularAcceleration { get; internal set; }
        }
      }
    }

    public class PositionData
    {
      public PositionData()
      {
        this.Cabin = new SCSTelemetry.FVector();
        this.Head = new SCSTelemetry.FVector();
        this.Hook = new SCSTelemetry.FVector();
        this.HeadOffset = new SCSTelemetry.FPlacement();
        this.CabinOffset = new SCSTelemetry.FPlacement();
        this.TruckPosition = new SCSTelemetry.DPlacement();
      }

      public SCSTelemetry.FVector Cabin { get; internal set; }

      public SCSTelemetry.FVector Head { get; internal set; }

      public SCSTelemetry.FVector Hook { get; internal set; }

      public SCSTelemetry.FPlacement HeadOffset { get; internal set; }

      public SCSTelemetry.FPlacement CabinOffset { get; internal set; }

      internal SCSTelemetry.DPlacement TruckPosition { get; set; }

      public SCSTelemetry.FVector HeadPositionInCabinSpace
      {
        get
        {
          return SCSTelemetry.Add(this.Head, this.HeadOffset.Position);
        }
      }

      public SCSTelemetry.FVector HeadPositionInVehicleSpace
      {
        get
        {
          return SCSTelemetry.Add(SCSTelemetry.Add(this.Cabin, this.CabinOffset.Position), SCSTelemetry.Rotate(this.CabinOffset.Orientation, this.HeadPositionInCabinSpace));
        }
      }

      public SCSTelemetry.DVector HeadPositionInWorldSpace
      {
        get
        {
          return SCSTelemetry.Add(this.TruckPosition.Position, SCSTelemetry.Rotate(this.TruckPosition.Orientation, this.HeadPositionInVehicleSpace));
        }
      }

      public SCSTelemetry.DVector CabinPositionInWorlSpace
      {
        get
        {
          return SCSTelemetry.Add(this.TruckPosition.Position, SCSTelemetry.Rotate(this.TruckPosition.Orientation, this.Cabin));
        }
      }

      public SCSTelemetry.DVector HookPositionInWorldSpace
      {
        get
        {
          return SCSTelemetry.Add(this.TruckPosition.Position, SCSTelemetry.Rotate(this.TruckPosition.Orientation, this.Hook));
        }
      }
    }

    public class Version
    {
      public uint Major { get; internal set; }

      public uint Minor { get; internal set; }

      public override string ToString()
      {
        return string.Format("Version: {0}.{1}", (object) this.Major, (object) this.Minor);
      }
    }

    public class WheelsConstants
    {
      public uint Count { get; internal set; }

      public float[] Radius { get; internal set; }

      public bool[] Simulated { get; internal set; }

      public bool[] Powered { get; internal set; }

      public bool[] Liftable { get; internal set; }

      public bool[] Steerable { get; internal set; }

      public SCSTelemetry.FVector[] PositionValues { get; internal set; }
    }
  }
}
