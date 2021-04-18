using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using System.Xml.Serialization;
using WindowsFormsApp6;
using WindowsFormsApp6.Properties;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

public static class Method
{
    //public static System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
    public static void Serialize(Config config , String path )
    {

        using(FileStream fs = new FileStream(path, FileMode.Create)) {
            XmlSerializer xSer = new XmlSerializer(typeof(Config));

            xSer.Serialize(fs, config);
        }
    }
    public static void SerializeObject(Object obj, String path)
    {
        IFormatter formatter = new BinaryFormatter();
        Stream stream = new FileStream(path, FileMode.Create, FileAccess.Write);

        formatter.Serialize(stream, obj);
        stream.Close();
    }

    public static Config deserialize(String path)
    {
        using (FileStream fs = new FileStream(path, FileMode.Open)) //double check that...
        {
            XmlSerializer _xSer = new XmlSerializer(typeof(Config));

            var myObject = _xSer.Deserialize(fs);

            return (Config)myObject;
        }

    }

    public static Object deserializeObject(String path)
    {
        IFormatter formatter = new BinaryFormatter();
        Stream  stream = new FileStream(path, FileMode.Open, FileAccess.Read);
        Object obj = (Object)formatter.Deserialize(stream);
        stream.Close();
        return obj;
    }

    public static string chooseFile()
    {
        OpenFileDialog choofdlog = new OpenFileDialog();
        choofdlog.DefaultExt = "exe";
        choofdlog.Filter = "exe files (*.exe)|*.exe";
        choofdlog.FilterIndex = 1;
        choofdlog.Multiselect = true;

        if (choofdlog.ShowDialog() == DialogResult.OK)
            return choofdlog.FileName;
        else
        {
            return null;
        }
    }

    public static string chooseFileWithEx(string s)
    {
        OpenFileDialog choofdlog = new OpenFileDialog();
        choofdlog.DefaultExt = s;
        choofdlog.Filter = (s + " files (*." + s) + "|*." + s   ;
        choofdlog.FilterIndex = 1;
        choofdlog.Multiselect = true;

        if (choofdlog.ShowDialog() == DialogResult.OK)
            return choofdlog.FileName;
        else
        {
            return null;
        }
    }

    public static string chooseFolder()
    {
        FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();

        if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
        {
            return folderBrowserDialog1.SelectedPath;
        }
        else
        {
            return null;
        }
    }

    public static void ProcessStart(String path)
    {
        Process notePad = new Process();
        notePad.StartInfo.FileName = path;

        notePad.Start();
    }
    public static float hexToFloat(string HexRep)
    {

        // Converting to integer
        Int32 IntRep = Int32.Parse(HexRep, NumberStyles.AllowHexSpecifier);
        // Integer to Byte[] and presenting it for float conversion
        float f = BitConverter.ToSingle(BitConverter.GetBytes(IntRep), 0);
        // There you go
        return f;
    }

    public static float ToFloatFromString(string val)
    {
        if (val.Contains("&"))
        {
            return hexToFloat(val.Remove(0, 1));
        }
        else
        {
            return float.Parse(val);
        }
    }




}