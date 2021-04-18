using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using Funbit.Ets.Telemetry.Server.Data;
using Funbit.Ets.Telemetry.Server.Helpers;
using SCSSdkClient;
using SCSSdkClient.Object;
using TB_Client.classes;
using Microsoft.Win32;

namespace WindowsFormsApp6
{

    public partial class Form1 : Form
    {
        private float max_speed_var = 0;
        private float current_speed_var = 0;

        private float cruise_speed = 0;
        private bool isCruiseOn = false;

        private float cargoDamage = 0;

        private static bool maxSpeedWarn = false;
        private static bool cruiseSpeedWarn = false;
        private static bool tbNotOpenWarn = false;
        private static bool cruiseOnSpeedWarn = false;

        private bool isTBOpen = false;
        private bool isETS2Open = false;

        private int drivenDistance = 0;
        private int startOdometer = 0;


        Config config = new Config();

        private static String config_path = null;

        private Thread warningSoundThread;
        private Thread dataReadFromGameThread;

        private static string ets2SpeedRecorderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) +
                                                      "\\ETS2 Speed Recorder";







        public Form1()
        {
            InitializeComponent();

            this.startOdometer = (int)Math.Round((double)Ets2TelemetryDataReader.Instance.Read().Truck.Odometer,0);
            this.drivenDistance = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (Directory.Exists(ets2SpeedRecorderPath))
            {
                config_path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\ETS2 Speed Recorder\\config_ETS2speedRecorder.txt";
                this.config = Method.deserialize(config_path);
            }
            else
            {
                Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\ETS2 Speed Recorder");
                config_path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\config_ETS2speedRecorder.txt";

                if (File.Exists(config_path))
                {
                    this.config = Method.deserialize(config_path);
                    config_path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\ETS2 Speed Recorder\\config_ETS2speedRecorder.txt";
                    Method.Serialize(this.config, config_path);
                }
                else
                {
                    config_path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\ETS2 Speed Recorder\\config_ETS2speedRecorder.txt";
                    Method.Serialize(this.config, config_path);
                }
            }
            setConfig(this.config);

            

            timer1.Start();

            this.warningSoundThread = new System.Threading.Thread(
                new System.Threading.ThreadStart(
                    delegate()
                    {
                        while (true)
                        {
                            if (maxSpeedWarn)
                            {
                                Console.Beep(config.max_speed_sound, 800);
                            }

                            if (cruiseSpeedWarn)
                            {
                                Console.Beep(config.cruise_speed_sound, 800);
                            }

                            if (tbNotOpenWarn)
                            {
                                Console.Beep(config.tb_client_sound, 800);
                            }
                            if (cruiseOnSpeedWarn)
                            {
                                Console.Beep(config.cruiseOnSpeedSound, 800);
                            }

                            Thread.Sleep(800);

                        }

                    }
                ));


            this.dataReadFromGameThread = new System.Threading.Thread(
                new System.Threading.ThreadStart(
                    delegate ()
                    {
                        while (true)
                        {
                            this.current_speed_var = (float)Math.Round((double)Ets2TelemetryDataReader.Instance.Read().Truck.Speed,2);
                            this.isCruiseOn = Ets2TelemetryDataReader.Instance.Read().Truck.CruiseControlOn;
                            this.cruise_speed = (float)Math.Round((double)Ets2TelemetryDataReader.Instance.Read().Truck.CruiseControlSpeed,2);
                            this.isTBOpen = TruckBookProcessHelper.IsTruckBookRunning;
                            this.isETS2Open = Ets2ProcessHelper.IsEts2Running;

                            //this.drivenDistance = (int)Math.Round((double)Ets2TelemetryDataReader.Instance.Read().Truck.Odometer, 0) - this.startOdometer;

                            //float x = Ets2TelemetryDataReader.Instance.Read().Truck.Placement.X;
                            //float y = Ets2TelemetryDataReader.Instance.Read().Truck.Placement.Y;
                            //float z = Ets2TelemetryDataReader.Instance.Read().Truck.Placement.Z;

                            //float m = (float)Math.Sqrt(Math.Pow(x,2) + Math.Pow(y,2) + Math.Pow(z,2));

                            if (this.startOdometer==0)
                            {
                                this.startOdometer = (int)Math.Round(Ets2TelemetryDataReader.Instance.Read().Truck.Odometer, 0);
                            }




                            if ((int)Math.Round(this.current_speed_var,0)!=0)
                            {
                                this.drivenDistance = ((int)Math.Round((double)Ets2TelemetryDataReader.Instance.Read().Truck.Odometer, 0) - this.startOdometer);
                                //System.Console.WriteLine("AAAAAA");
                            }
                            else
                            {
                                if ((int)Math.Round((double)Ets2TelemetryDataReader.Instance.Read().Truck.Odometer, 0) - this.drivenDistance!= 0)
                                {
                                    this.startOdometer = (int)Math.Round(Ets2TelemetryDataReader.Instance.Read().Truck.Odometer, 0) - this.drivenDistance;
                                }
                            }


                            


                            Thread.Sleep(config.dataUpdateDelay);
                        }

                    }
                ));
            warningSoundThread.Start();
            dataReadFromGameThread.Start();

        }


        public void GetAndUpdateDataFromGame()
        {
            
            

            label1.Text = this.current_speed_var.ToString() + " Kmph";
            label12.Text = this.drivenDistance + " Km";


            if (config.isSetcruseOnSpeed && !this.isCruiseOn && this.current_speed_var>config.cruseOnSpeed)
            {
                cruiseOnSpeedWarn = true;
            }
            else
            {
                cruiseOnSpeedWarn = false;
            }
            

            if (this.max_speed_var < this.current_speed_var)
            {
                this.max_speed_var = this.current_speed_var;
                label2.Text = this.max_speed_var.ToString() + " Kmph";
            }

            if (this.isCruiseOn)
            {
                label4.Text = "ON";
                label4.BackColor = Color.Lime;
                label6.Text = this.cruise_speed.ToString() + " Kmph";
            }
            else
            {
                label4.Text = "OFF";
                label4.BackColor = Color.Red;
                label6.Text = "0 Kmph";
            }

            if (this.config.max_speed <= this.max_speed_var && this.config.isSetMaxSpeed)
            {
                maxSpeedWarn = true;
            }
            else
            {
                maxSpeedWarn = false;
            }

            if (this.isCruiseOn && this.config.cruise_speed < this.cruise_speed && this.config.isSetCruiseSpeed)
            {
                cruiseSpeedWarn = true;
            }
            else
            {
                cruiseSpeedWarn = false;
            }

            if (!isTBOpen && this.config.isSetTBNotOpen && this.isETS2Open)
            {
                tbNotOpenWarn = true;
            }
            else
            {
                tbNotOpenWarn = false;
            }

            if (isTBOpen)
            {
                label7.Text = "Running";
                label7.ForeColor = Color.Lime;
            }
            else
            {
                label7.Text = "Not Running";
                label7.ForeColor = Color.Red;
            }

            if (isETS2Open)
            {
                label8.Text = "Running";
                label8.ForeColor = Color.Lime;
            }
            else
            {
                label8.Text = "Not Running";
                label8.ForeColor = Color.Red;
            }

            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            GetAndUpdateDataFromGame();
        }

        private void setWarnningSoundsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            Method.Serialize(this.config, config_path);
            f2.ShowDialog();
            this.config = Method.deserialize(config_path);
            setConfig(this.config);


        }

        public void setConfig(Config config)
        {
            if (config.topMost)
            {
                this.TopMost = true;
                this.istopMost.CheckState = CheckState.Checked;
            }
            else
            {
                this.TopMost = false;
                this.istopMost.CheckState = CheckState.Unchecked;
            }

            if (config.isSetMaxSpeed)
            {
                this.maxSpeedToolStripMenuItem.CheckState = CheckState.Checked;
            }
            else
            {
                this.maxSpeedToolStripMenuItem.CheckState = CheckState.Unchecked;
            }



            if (config.isSetCruiseSpeed)
            {
                this.cruiseSpeedToolStripMenuItem.CheckState = CheckState.Checked;
            }
            else
            {
                this.cruiseSpeedToolStripMenuItem.CheckState = CheckState.Unchecked;
            }



            if (config.isSetTBNotOpen)
            {
                this.tBNotOpenToolStripMenuItem.CheckState = CheckState.Checked;
            }
            else
            {
                this.tBNotOpenToolStripMenuItem.CheckState = CheckState.Unchecked;
            }

            if (config.isSetTBOn)
            {
                this.checkBox2.CheckState = CheckState.Checked;
            }
            else
            {
                this.checkBox2.CheckState = CheckState.Unchecked;
            }

            if (config.isSetcruseOnSpeed)
            {
                this.CruiseOnItem1.CheckState = CheckState.Checked;
            }
            else
            {
                this.CruiseOnItem1.CheckState = CheckState.Unchecked;
            }

            if (config.dataUpdateDelay == 10)
            {
                this.delay1.CheckState = CheckState.Checked;
                this.delay2.CheckState = CheckState.Unchecked;
                this.delay3.CheckState = CheckState.Unchecked;
                this.delay4.CheckState = CheckState.Unchecked;
                this.delay5.CheckState = CheckState.Unchecked;
                this.delay6.CheckState = CheckState.Unchecked;
            }
            else if (config.dataUpdateDelay == 50)
            {
                this.delay1.CheckState = CheckState.Unchecked;
                this.delay2.CheckState = CheckState.Checked;
                this.delay3.CheckState = CheckState.Unchecked;
                this.delay4.CheckState = CheckState.Unchecked;
                this.delay5.CheckState = CheckState.Unchecked;
                this.delay6.CheckState = CheckState.Unchecked;
            }
            else if (config.dataUpdateDelay == 100)
            {
                this.delay1.CheckState = CheckState.Unchecked;
                this.delay2.CheckState = CheckState.Unchecked;
                this.delay3.CheckState = CheckState.Checked;
                this.delay4.CheckState = CheckState.Unchecked;
                this.delay5.CheckState = CheckState.Unchecked;
                this.delay6.CheckState = CheckState.Unchecked;
            }
            else if (config.dataUpdateDelay == 200)
            {
                this.delay1.CheckState = CheckState.Unchecked;
                this.delay2.CheckState = CheckState.Unchecked;
                this.delay3.CheckState = CheckState.Unchecked;
                this.delay4.CheckState = CheckState.Checked;
                this.delay5.CheckState = CheckState.Unchecked;
                this.delay6.CheckState = CheckState.Unchecked;
            }
            else if (config.dataUpdateDelay == 500)
            {
                this.delay1.CheckState = CheckState.Unchecked;
                this.delay2.CheckState = CheckState.Unchecked;
                this.delay3.CheckState = CheckState.Unchecked;
                this.delay4.CheckState = CheckState.Unchecked;
                this.delay5.CheckState = CheckState.Checked;
                this.delay6.CheckState = CheckState.Unchecked;
            }
            else
            {
                this.delay1.CheckState = CheckState.Unchecked;
                this.delay2.CheckState = CheckState.Unchecked;
                this.delay3.CheckState = CheckState.Unchecked;
                this.delay4.CheckState = CheckState.Unchecked;
                this.delay5.CheckState = CheckState.Unchecked;
                this.delay6.CheckState = CheckState.Checked;
            }

            label9.Text = this.config.max_speed.ToString() + " Kmph";
            label10.Text = this.config.cruise_speed.ToString() + " Kmph";
            label13.Text = this.config.cruseOnSpeed + " Kmph";

            

            timer1.Interval = this.config.dataUpdateDelay;


        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBox2.Checked)
            {
                this.config.isSetTBOn = true;
            }
            else
            {
                this.config.isSetTBOn = false;
            }

            Method.Serialize(this.config, config_path);
        }

        private void singlePlayerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.config.sp_path = Method.chooseFile();
            Method.Serialize(this.config, config_path);

        }

        private void tMPPathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string temp = Method.chooseFile();
            ;

            if (!String.IsNullOrEmpty(temp))
            {
                this.config.tmp_path = temp;
                Method.Serialize(this.config, config_path);
            }

        }

        private void tBClientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string temp = Method.chooseFile();
            ;

            if (!String.IsNullOrEmpty(temp))
            {
                this.config.tb_clientpath = temp;
                Method.Serialize(this.config, config_path);
            }

        }

        private void maxSpeedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (maxSpeedToolStripMenuItem.CheckState == CheckState.Checked)
            {
                maxSpeedToolStripMenuItem.CheckState = CheckState.Unchecked;
                this.config.isSetMaxSpeed = false;
            }
            else
            {
                maxSpeedToolStripMenuItem.CheckState = CheckState.Checked;
                this.config.isSetMaxSpeed = true;
            }

            Method.Serialize(this.config, config_path);
        }

        private void cruiseSpeedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cruiseSpeedToolStripMenuItem.CheckState == CheckState.Checked)
            {
                cruiseSpeedToolStripMenuItem.CheckState = CheckState.Unchecked;
                this.config.isSetCruiseSpeed = false;
            }
            else
            {
                cruiseSpeedToolStripMenuItem.CheckState = CheckState.Checked;
                this.config.isSetCruiseSpeed = true;
            }

            Method.Serialize(this.config, config_path);
        }

        private void tBNotOpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tBNotOpenToolStripMenuItem.CheckState == CheckState.Checked)
            {
                tBNotOpenToolStripMenuItem.CheckState = CheckState.Unchecked;
                this.config.isSetTBNotOpen = false;
            }
            else
            {
                tBNotOpenToolStripMenuItem.CheckState = CheckState.Checked;
                this.config.isSetTBNotOpen = true;
            }

            Method.Serialize(this.config, config_path);
        }

        private void delay1_Click(object sender, EventArgs e)
        {
            this.config.dataUpdateDelay = 10;

            delay1.CheckState = CheckState.Checked;
            delay2.CheckState = CheckState.Unchecked;
            delay3.CheckState = CheckState.Unchecked;
            delay4.CheckState = CheckState.Unchecked;
            delay5.CheckState = CheckState.Unchecked;
            delay6.CheckState = CheckState.Unchecked;

            Method.Serialize(this.config, config_path);
        }

        private void delay2_Click(object sender, EventArgs e)
        {
            this.config.dataUpdateDelay = 50;

            delay1.CheckState = CheckState.Unchecked;
            delay2.CheckState = CheckState.Checked;
            delay3.CheckState = CheckState.Unchecked;
            delay4.CheckState = CheckState.Unchecked;
            delay5.CheckState = CheckState.Unchecked;
            delay6.CheckState = CheckState.Unchecked;

            Method.Serialize(this.config, config_path);
        }

        private void delay3_Click(object sender, EventArgs e)
        {
            this.config.dataUpdateDelay = 100;

            delay1.CheckState = CheckState.Unchecked;
            delay2.CheckState = CheckState.Unchecked;
            delay3.CheckState = CheckState.Checked;
            delay4.CheckState = CheckState.Unchecked;
            delay5.CheckState = CheckState.Unchecked;
            delay6.CheckState = CheckState.Unchecked;

            Method.Serialize(this.config, config_path);
        }

        private void delay4_Click(object sender, EventArgs e)
        {
            this.config.dataUpdateDelay = 200;

            delay1.CheckState = CheckState.Unchecked;
            delay2.CheckState = CheckState.Unchecked;
            delay3.CheckState = CheckState.Unchecked;
            delay4.CheckState = CheckState.Checked;
            delay5.CheckState = CheckState.Unchecked;
            delay6.CheckState = CheckState.Unchecked;

            Method.Serialize(this.config, config_path);
        }

        private void delay5_Click(object sender, EventArgs e)
        {
            this.config.dataUpdateDelay = 500;

            delay1.CheckState = CheckState.Unchecked;
            delay2.CheckState = CheckState.Unchecked;
            delay3.CheckState = CheckState.Unchecked;
            delay4.CheckState = CheckState.Unchecked;
            delay5.CheckState = CheckState.Checked;
            delay6.CheckState = CheckState.Unchecked;

            Method.Serialize(this.config, config_path);
        }

        private void delay6_Click(object sender, EventArgs e)
        {
            this.config.dataUpdateDelay = 1000;

            delay1.CheckState = CheckState.Unchecked;
            delay2.CheckState = CheckState.Unchecked;
            delay3.CheckState = CheckState.Unchecked;
            delay4.CheckState = CheckState.Unchecked;
            delay5.CheckState = CheckState.Unchecked;
            delay6.CheckState = CheckState.Checked;

            Method.Serialize(this.config, config_path);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (File.Exists(config.sp_path))
            {
                if (checkBox2.CheckState == CheckState.Checked)
                {
                    if (TruckBookProcessHelper.IsTruckBookRunning)
                    {
                        Method.ProcessStart(config.sp_path);
                    }
                    else
                    {
                        if (File.Exists(config.tb_clientpath))
                        {
                            Method.ProcessStart(config.tb_clientpath);
                            Thread.Sleep(4000);
                            if (TruckBookProcessHelper.IsTruckBookRunning)
                            {
                                Method.ProcessStart(config.sp_path);
                            }
                        }
                        else
                        {
                            string message = "Choose TrucksBook Client Path";
                            string title = "File Not Exist";
                            MessageBox.Show(message, title);

                            string temp = Method.chooseFile();
                            ;

                            if (!String.IsNullOrEmpty(temp))
                            {
                                this.config.tb_clientpath = temp;
                                Method.Serialize(this.config, config_path);
                            }
                        }
                    }
                }
                else
                {
                    Method.ProcessStart(config.sp_path);
                }

            }
            else
            {
                string message = "Choose Euro Truck Simulator 2 Path";
                string title = "File Not Exist";
                MessageBox.Show(message, title);

                string temp = Method.chooseFile();
                ;

                if (!String.IsNullOrEmpty(temp))
                {
                    this.config.sp_path = temp;
                    Method.Serialize(this.config, config_path);
                }

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (File.Exists(config.tmp_path))
            {
                if (checkBox2.CheckState == CheckState.Checked)
                {
                    if (TruckBookProcessHelper.IsTruckBookRunning)
                    {
                        Method.ProcessStart(config.tmp_path);
                    }
                    else
                    {
                        if (File.Exists(config.tb_clientpath))
                        {
                            Method.ProcessStart(config.tb_clientpath);
                            Thread.Sleep(4000);
                            if (TruckBookProcessHelper.IsTruckBookRunning)
                            {
                                Method.ProcessStart(config.tmp_path);
                            }
                        }
                        else
                        {
                            string message = "Choose TrucksBook Client Path";
                            string title = "File Not Exist";
                            MessageBox.Show(message, title);

                            string temp = Method.chooseFile();
                            ;

                            if (!String.IsNullOrEmpty(temp))
                            {
                                this.config.tb_clientpath = temp;
                                Method.Serialize(this.config, config_path);
                            }
                        }
                    }
                }
                else
                {
                    Method.ProcessStart(config.tmp_path);
                }
                
            }
            else
            {
                string message = "Choose TruckersMP Path";
                string title = "File Not Exist";
                MessageBox.Show(message, title);

                string temp = Method.chooseFile();
                ;

                if (!String.IsNullOrEmpty(temp))
                {
                    this.config.tmp_path = temp;
                    Method.Serialize(this.config, config_path);
                }

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (File.Exists(config.tb_clientpath))
            {
                Method.ProcessStart(config.tb_clientpath);
            }
            else
            {
                string message = "Choose TruckBook Client Path";
                string title = "File Not Exist";
                MessageBox.Show(message, title);
                string temp = Method.chooseFile();
                ;

                if (!String.IsNullOrEmpty(temp))
                {
                    this.config.tb_clientpath = temp;
                    Method.Serialize(this.config, config_path);
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.max_speed_var = 0;
            label2.Text = "0 Kmph";
            maxSpeedWarn = false;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            warningSoundThread.Abort();
            dataReadFromGameThread.Abort();
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            warningSoundThread.Abort();
            dataReadFromGameThread.Abort();
            this.Close();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.ShowDialog();
        }

        private void siiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.config.sii_decryptorPath = Method.chooseFile();
            Method.Serialize(this.config, config_path);
        }

        private void eTS2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string temp = Method.chooseFolder();
            if (!String.IsNullOrEmpty(temp))
            {
                config.ets2Path = temp;
                Method.Serialize(config, config_path);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.startOdometer = (int)Math.Round((double)Ets2TelemetryDataReader.Instance.Read().Truck.Odometer, 0);
            this.drivenDistance = 0;
        }

        private void istopMost_Click(object sender, EventArgs e)
        {
            if (config.topMost)
            {
                config.topMost = false;
                istopMost.CheckState = CheckState.Unchecked;
                this.TopMost = false;
            }
            else
            {
                config.topMost = true;
                istopMost.CheckState = CheckState.Checked;
                this.TopMost = true;
            }

            Method.Serialize(this.config, config_path);
        }

        private void CruiseOnItem1_Click(object sender, EventArgs e)
        {
            if (CruiseOnItem1.CheckState == CheckState.Checked)
            {
                CruiseOnItem1.CheckState = CheckState.Unchecked;
                this.config.isSetcruseOnSpeed = false;
            }
            else
            {
                CruiseOnItem1.CheckState = CheckState.Checked;
                this.config.isSetcruseOnSpeed = true;
            }

            Method.Serialize(this.config, config_path);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            RegistryKey tbRegVal = Registry.CurrentUser.OpenSubKey("SOFTWARE\\TrucksBook");

            Dictionary<string, string> etsNav = new Dictionary<string, string>();
            Dictionary<string, string> etsSpeed = new Dictionary<string, string>();

            Dictionary<string, string> atsNav = new Dictionary<string, string>();
            Dictionary<string, string> atsSpeed = new Dictionary<string, string>();

            foreach (string valueName in tbRegVal.GetValueNames())
            {
                //Console.WriteLine(valueName);

                if (valueName.Split('_')[0] == "nav" || valueName.Split('_')[0] == "speed")
                {
                    string[] s = valueName.Split('_');
                    if (s[1] == "ets")
                    {

                        if (s[0] == "nav")
                        {
                            etsNav.Add(s[2], tbRegVal.GetValue(valueName).ToString());
                        }
                        else
                        {
                            etsSpeed.Add(s[2], tbRegVal.GetValue(valueName).ToString());
                        }
                    }
                    else
                    {
                        if (s[0] == "nav")
                        {
                            atsNav.Add(s[2], tbRegVal.GetValue(valueName).ToString());
                        }
                        else
                        {
                            atsSpeed.Add(s[2], tbRegVal.GetValue(valueName).ToString());
                        }
                    }


                }
            }

            string outp = "";


            if (etsNav.Count >= etsSpeed.Count)
            {
                foreach (var v in etsNav)
                {
                    if (etsSpeed.ContainsKey(v.Key))
                    {
                        outp += "ETS2 " + "[" + hexToString(v.Key) + "]" + " Planned Distance : " + Decrypt_num(v.Value)/1000 + " , Max Speed : " + Decrypt_num(etsSpeed[v.Key]) + "\n";
                    }
                    else
                    {
                        outp += "ETS2 " + "[" + hexToString(v.Key) + "]" + " Planned Distance : " + Decrypt_num(v.Value)/1000 + " , Max Speed : null\n";
                    }
                }
            }
            else
            {
                foreach (var v in etsSpeed)
                {
                    if (etsNav.ContainsKey(v.Key))
                    {
                        outp += "ETS2 " + "[" + hexToString(v.Key) + "]" + " Planned Distance : " + Decrypt_num(etsNav[v.Key])/1000 + " , Max Speed : " + Decrypt_num(v.Value) + "\n";
                    }
                    else
                    {
                        outp += "ETS2 " + "[" + hexToString(v.Key) + "]" + " Planned Distance : null" + " , Max Speed : " + Decrypt_num(v.Value) + "\n";
                    }
                }
            }

            outp += "\n";

            if (atsNav.Count >= atsSpeed.Count)
            {
                foreach (var v in atsNav)
                {
                    if (atsSpeed.ContainsKey(v.Key))
                    {
                        outp += "ATS " + "[" + hexToString(v.Key) + "]" + " Planned Distance : " + Decrypt_num(v.Value)/1000 + " , Max Speed : " + Decrypt_num(atsSpeed[v.Key]) + "\n";
                    }
                    else
                    {
                        outp += "ATS " + "[" + hexToString(v.Key) + "]" + " Planned Distance : " + Decrypt_num(v.Value)/1000 + " , Max Speed : null\n";
                    }
                }
            }
            else
            {
                foreach (var v in atsSpeed)
                {
                    if (atsNav.ContainsKey(v.Key))
                    {
                        outp += "ATS " + "[" + hexToString(v.Key) + "]" + " Planned Distance : " + Decrypt_num(atsNav[v.Key])/1000 + " , Max Speed : " + Decrypt_num(v.Value) + "\n";
                    }
                    else
                    {
                        outp += "ATS " + "[" + hexToString(v.Key) + "]" + " Planned Distance : null" + " , Max Speed : " + v.Value + "\n";
                    }
                }
            }
            
            MessageBox.Show(outp, "Registry Values");
        }

        public static string hexToString(String hex)
        {
            int NumberChars = hex.Length;
            byte[] bytes = new byte[NumberChars / 2];
            for (int i = 0; i < NumberChars; i += 2)
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            return Encoding.UTF8.GetString(bytes);
        }

        public string Encrypt_num(string number)
        {
            string[] strArray = new string[number.Length];
            int startIndex = 0;
            for (int index = 0; index < number.Length; ++index)
            {
                string str = number.Substring(startIndex, 1);
                if (str == "0")
                    str = "G";
                if (str == "1")
                    str = "w";
                if (str == "2")
                    str = "M";
                if (str == "3")
                    str = "V";
                if (str == "4")
                    str = "t";
                if (str == "5")
                    str = "z";
                if (str == "6")
                    str = "S";
                if (str == "7")
                    str = "i";
                if (str == "8")
                    str = "K";
                if (str == "9")
                    str = "p";
                strArray[index] = str;
                ++startIndex;
            }
            string str1 = "";
            foreach (string str2 in strArray)
                str1 += str2;
            return str1;
        }

        public int Decrypt_num(string encrypted)
        {
            string[] strArray = new string[encrypted.Length];
            int startIndex = 0;
            for (int index = 0; index < encrypted.Length; ++index)
            {
                string str = encrypted.Substring(startIndex, 1);
                if (str == "G")
                    str = "0";
                if (str == "w")
                    str = "1";
                if (str == "M")
                    str = "2";
                if (str == "V")
                    str = "3";
                if (str == "t")
                    str = "4";
                if (str == "z")
                    str = "5";
                if (str == "S")
                    str = "6";
                if (str == "i")
                    str = "7";
                if (str == "K")
                    str = "8";
                if (str == "p")
                    str = "9";
                strArray[index] = str;
                ++startIndex;
            }
            string str1 = "";
            foreach (string str2 in strArray)
                str1 += str2;
            return int.Parse(str1);
        }
    }
}


