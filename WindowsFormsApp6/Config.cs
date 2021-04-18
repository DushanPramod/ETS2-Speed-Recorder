using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp6
{
    public class Config
    {
        public String config_ETS2_speedRecorder;
        public String sp_path;
        public String tmp_path;
        public String tb_clientpath;
        public string sii_decryptorPath;
        public string ets2Path;


        public bool isSetMaxSpeed;
        public bool isSetCruiseSpeed;
        public bool isSetTBNotOpen;
        public bool isSetTBOn;

        public int dataUpdateDelay;

        public float max_speed;
        public int cruise_speed;

        public int max_speed_sound;
        public int cruise_speed_sound;
        public int tb_client_sound;

        public bool topMost;

        public int cruseOnSpeed;
        public bool isSetcruseOnSpeed;
        public int cruiseOnSpeedSound;


        public Config()
        {
            config_ETS2_speedRecorder = "DO NOT EDIT IT IF YOU ARE NOT SURE ABOUT THAT WHAT YOU ARE DOING.";
            sp_path = null;
            tmp_path = null;
            tb_clientpath = null;
            ets2Path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Euro Truck Simulator 2";
            sii_decryptorPath = "SII_Decrypt.exe";

            isSetMaxSpeed = true;
            isSetCruiseSpeed = true;
            isSetTBNotOpen = true;
            isSetTBOn = true;

            topMost = false;

            dataUpdateDelay = 50;

            max_speed = 181;
            cruise_speed = 180;

            max_speed_sound = 1000;
            cruise_speed_sound = 1000;
            tb_client_sound = 1000;

            cruseOnSpeed = 90;
            isSetcruseOnSpeed = false;
            cruiseOnSpeedSound = 1000;

        }
    }
}
