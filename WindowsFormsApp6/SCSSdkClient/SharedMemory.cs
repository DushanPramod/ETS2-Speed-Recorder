// Decompiled with JetBrains decompiler
// Type: SCSSdkClient.SharedMemory
// Assembly: TB Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1A007F5D-635A-4205-BA63-50EE7F34DE72
// Assembly location: C:\Program Files (x86)\TrucksBook Client\TB Client.exe

using SCSSdkClient.Object;
using System;
using System.IO.MemoryMappedFiles;

namespace SCSSdkClient
{
  public class SharedMemory
  {
    private readonly SCSSdkConvert _sdkconvert = new SCSSdkConvert();
    private const uint defaultMapSize = 32768;
    private MemoryMappedFile _memoryMappedHandle;
    private MemoryMappedViewAccessor _memoryMappedView;

    public bool Hooked { get; private set; }

    public Exception HookException { get; private set; }

    public byte[] RawData { get; private set; }

    public void Connect(string map)
    {
      this.Connect(map, 32768U);
    }

    public void Connect(string map, uint mapSize)
    {
      if (this.Hooked)
        this.Disconnect();
      this.HookException = (Exception) null;
      try
      {
        this.RawData = new byte[(int) mapSize];
        this._memoryMappedHandle = MemoryMappedFile.CreateOrOpen(map, (long) mapSize, MemoryMappedFileAccess.ReadWrite);
        this._memoryMappedView = this._memoryMappedHandle.CreateViewAccessor(0L, (long) mapSize);
        this.Hooked = true;
      }
      catch (Exception ex)
      {
        this.Hooked = false;
        this.HookException = ex;
      }
    }

    public void Disconnect()
    {
      this.Hooked = false;
      this._memoryMappedView.Dispose();
      this._memoryMappedHandle.Dispose();
    }

    public SCSTelemetry Update<T>()
    {
      this.Update();
      return this.ToObject<T>(this.RawData);
    }

    public void Update()
    {
      if (!this.Hooked || this._memoryMappedView == null)
        return;
      this._memoryMappedView.ReadArray<byte>(0L, this.RawData, 0, this.RawData.Length);
    }

    protected SCSTelemetry ToObject<T>(byte[] structureDataBytes)
    {
      return this._sdkconvert.Convert(structureDataBytes);
    }
  }
}
