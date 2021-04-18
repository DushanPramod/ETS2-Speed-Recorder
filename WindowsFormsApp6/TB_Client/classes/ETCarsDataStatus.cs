// Decompiled with JetBrains decompiler
// Type: TB_Client.classes.ETCarsDataStatus
// Assembly: TB Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1A007F5D-635A-4205-BA63-50EE7F34DE72
// Assembly location: C:\Program Files (x86)\TrucksBook Client\TB Client.exe

using System.Runtime.InteropServices;

namespace TB_Client.classes
{
  [StructLayout(LayoutKind.Sequential, Size = 1)]
  public struct ETCarsDataStatus
  {
    public const string INITIALIZED = "INITIALIZED";
    public const string PAUSED = "PAUSED";
    public const string UNPAUSED = "UNPAUSED";
    public const string TELEMETRYSHUTDOWN = "TELEMETRY SHUT DOWN";
    public const string JOBFINISHED = "JOB FINISHED";
    public const string JOBSTARTED = "JOB STARTED";
    public const string TELEMETRY = "TELEMETRY";
    public const string COLLISION = "COLLISION";
  }
}
