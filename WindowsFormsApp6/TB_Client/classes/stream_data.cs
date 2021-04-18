// Decompiled with JetBrains decompiler
// Type: TB_Client.classes.stream_data
// Assembly: TB Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1A007F5D-635A-4205-BA63-50EE7F34DE72
// Assembly location: C:\Program Files (x86)\TrucksBook Client\TB Client.exe

using System;
using System.IO;

namespace TB_Client.classes
{
  internal class stream_data
  {
    private string folder = Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments) + "\\TB Client\\stream\\";

    private void foldersAndFiles(string file)
    {
      if (!Directory.Exists(this.folder))
      {
        //Log.update("Vytvářím složku STREAM v dokumentech");
        try
        {
          Directory.CreateDirectory(this.folder);
        }
        catch
        {
          //Log.update("Chyba při vytváření složky STREAM v dokumentech");
        }
      }
      if (File.Exists(this.folder + file))
        return;
      //Log.update("Vytvářím soubor " + file + " v dokumentech");
      try
      {
        File.Create(this.folder + file).Dispose();
      }
      catch
      {
        //Log.update("Chyba při vytváření souboru " + file + " v dokumentech");
      }
    }

    public void saveDataTo(string txt, string file)
    {
      this.foldersAndFiles(file);
      if (file == "server.txt")
      {
        if (txt == "err")
          txt = "";
      }
      else if (file == "truck_speed_kmh.txt")
      {
        if (txt.Substring(0, 1) == "-")
          txt = txt.Remove(0, 1);
      }
      else if (file == "truck_speed_mph.txt")
      {
        if (txt.Substring(0, 1) == "-")
          txt = txt.Remove(0, 1);
      }
      else if (!(file == "truck_damage.txt") && !(file == "delivery_damage.txt") && file == "delivery_weight_ton.txt")
      {
        double num = Math.Round(Convert.ToDouble(txt) / 1000.0, 1);
        txt = num == 0.0 ? "0" : num.ToString();
      }
      if (!File.Exists(this.folder + file))
        return;
      try
      {
        if (File.ReadAllText(this.folder + file) != txt)
          File.WriteAllText(this.folder + file, txt);
      }
      catch
      {
      }
    }
  }
}
