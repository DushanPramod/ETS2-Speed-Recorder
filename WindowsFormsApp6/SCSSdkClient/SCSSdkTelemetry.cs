// Decompiled with JetBrains decompiler
// Type: SCSSdkClient.SCSSdkTelemetry
// Assembly: TB Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1A007F5D-635A-4205-BA63-50EE7F34DE72
// Assembly location: C:\Program Files (x86)\TrucksBook Client\TB Client.exe

using SCSSdkClient.Object;
using System;
using System.Threading;

namespace SCSSdkClient
{
  public class SCSSdkTelemetry : IDisposable
  {
    private readonly int pausedUpdateInterval = 1000;
    private ulong lastTime = ulong.MaxValue;
    private const string DefaultSharedMemoryMap = "Local\\SCSTelemetry";
    private const int DefaultUpdateInterval = 100;
    private const int DefaultPausedUpdateInterval = 1000;
    private int updateInterval;
    private Timer _updateTimer;
    private SharedMemory SharedMemory;
    private bool wasOnJob;
    private bool wasConnected;
    private bool cancelled;
    private bool delivered;
    private bool fined;
    private bool tollgate;
    private bool ferry;
    private bool train;
    private bool paused;
    private bool refuel;
    private bool refuelPayed;
    private bool wasPaused;

    public void Dispose()
    {
      this._updateTimer?.Dispose();
    }

    public SCSSdkTelemetry()
    {
      this.Setup("Local\\SCSTelemetry", 100);
    }

    public SCSSdkTelemetry(string map)
    {
      this.Setup(map, 100);
    }

    public SCSSdkTelemetry(int interval)
    {
      this.Setup("Local\\SCSTelemetry", interval);
    }

    public SCSSdkTelemetry(string map, int interval)
    {
      this.Setup(map, interval);
    }

    public string Map { get; private set; }

    public int UpdateInterval
    {
      get
      {
        return !this.paused ? this.updateInterval : this.pausedUpdateInterval;
      }
    }

    public Exception Error { get; private set; }

    public event TelemetryData Data;

    public event EventHandler JobStarted;

    public event EventHandler JobCancelled;

    public event EventHandler JobDelivered;

    public event EventHandler Fined;

    public event EventHandler Tollgate;

    public event EventHandler Ferry;

    public event EventHandler Train;

    public event EventHandler RefuelStart;

    public event EventHandler RefuelEnd;

    public event EventHandler RefuelPayed;

    public void pause()
    {
      this._updateTimer.Change(-1, -1);
    }

    public void resume()
    {
      TimeSpan timeSpan = new TimeSpan(0, 0, 0, 0, this.UpdateInterval);
      this._updateTimer.Change(timeSpan, timeSpan);
    }

    private void Setup(string map, int interval)
    {
      this.Map = map;
      this.updateInterval = interval;
      this.SharedMemory = new SharedMemory();
      this.SharedMemory.Connect(map);
      if (!this.SharedMemory.Hooked)
      {
        this.Error = this.SharedMemory.HookException;
      }
      else
      {
        TimeSpan timeSpan = new TimeSpan(0, 0, 0, 0, interval);
        this._updateTimer = new Timer(new TimerCallback(this._updateTimer_Elapsed), (object) null, timeSpan.Add(timeSpan), timeSpan);
      }
    }

    private void _updateTimer_Elapsed(object sender)
    {
      SCSTelemetry data1 = this.SharedMemory.Update<SCSTelemetry>();
      if (!data1.SdkActive && !this.paused)
      {
        TimeSpan timeSpan = new TimeSpan(0, 0, 0, 0, 1000);
        this._updateTimer.Change(timeSpan.Add(timeSpan), timeSpan);
        this.paused = true;
      }
      else
      {
        if (this.paused && data1.SdkActive)
        {
          this.paused = false;
          this.resume();
        }
        ulong timestamp = data1.Timestamp;
        bool flag = false;
        if (this.wasOnJob != data1.SpecialEventsValues.OnJob)
        {
          this.wasOnJob = data1.SpecialEventsValues.OnJob;
          flag = true;
          if (data1.SpecialEventsValues.OnJob)
          {
            EventHandler jobStarted = this.JobStarted;
            if (jobStarted != null)
              jobStarted((object) this, new EventArgs());
          }
        }
        if (this.cancelled != data1.SpecialEventsValues.JobCancelled)
        {
          this.cancelled = data1.SpecialEventsValues.JobCancelled;
          flag = true;
          if (data1.SpecialEventsValues.JobCancelled)
          {
            EventHandler jobCancelled = this.JobCancelled;
            if (jobCancelled != null)
              jobCancelled((object) this, new EventArgs());
          }
        }
        if (this.delivered != data1.SpecialEventsValues.JobDelivered)
        {
          flag = true;
          this.delivered = data1.SpecialEventsValues.JobDelivered;
          if (data1.SpecialEventsValues.JobDelivered)
          {
            EventHandler jobDelivered = this.JobDelivered;
            if (jobDelivered != null)
              jobDelivered((object) this, new EventArgs());
          }
        }
        if (this.fined != data1.SpecialEventsValues.Fined)
        {
          this.fined = data1.SpecialEventsValues.Fined;
          if (data1.SpecialEventsValues.Fined)
          {
            EventHandler fined = this.Fined;
            if (fined != null)
              fined((object) this, new EventArgs());
          }
        }
        if (this.tollgate != data1.SpecialEventsValues.Tollgate)
        {
          this.tollgate = data1.SpecialEventsValues.Tollgate;
          if (data1.SpecialEventsValues.Tollgate)
          {
            EventHandler tollgate = this.Tollgate;
            if (tollgate != null)
              tollgate((object) this, new EventArgs());
          }
        }
        if (this.ferry != data1.SpecialEventsValues.Ferry)
        {
          this.ferry = data1.SpecialEventsValues.Ferry;
          flag = true;
          if (data1.SpecialEventsValues.Ferry)
          {
            EventHandler ferry = this.Ferry;
            if (ferry != null)
              ferry((object) this, new EventArgs());
          }
        }
        if (this.train != data1.SpecialEventsValues.Train)
        {
          this.train = data1.SpecialEventsValues.Train;
          flag = true;
          if (data1.SpecialEventsValues.Train)
          {
            EventHandler train = this.Train;
            if (train != null)
              train((object) this, new EventArgs());
          }
        }
        if (this.refuel != data1.SpecialEventsValues.Refuel)
        {
          this.refuel = data1.SpecialEventsValues.Refuel;
          if (data1.SpecialEventsValues.Refuel)
          {
            EventHandler refuelStart = this.RefuelStart;
            if (refuelStart != null)
              refuelStart((object) this, new EventArgs());
          }
          else
          {
            EventHandler refuelEnd = this.RefuelEnd;
            if (refuelEnd != null)
              refuelEnd((object) this, new EventArgs());
          }
        }
        if (this.refuelPayed != data1.SpecialEventsValues.RefuelPayed)
        {
          this.refuelPayed = data1.SpecialEventsValues.RefuelPayed;
          if (data1.SpecialEventsValues.RefuelPayed)
          {
            EventHandler refuelPayed = this.RefuelPayed;
            if (refuelPayed != null)
              refuelPayed((object) this, new EventArgs());
          }
        }
        TelemetryData data2 = this.Data;
        if (data2 != null)
          data2(data1, (long) timestamp != (long) this.lastTime | flag || this.wasPaused != data1.Paused);
        this.wasPaused = data1.Paused;
        this.lastTime = timestamp;
      }
    }
  }
}
