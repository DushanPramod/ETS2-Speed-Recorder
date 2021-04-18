using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp6
{
    public partial class Form2 : Form
    {
        private static String config_path = null;
        Config config = new Config();

        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Console.Beep((int)numericUpDown3.Value,800);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Console.Beep((int)numericUpDown4.Value, 800);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Console.Beep((int)numericUpDown5.Value, 800);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //config_path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\config_ETS2speedRecorder.txt";
            config_path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\ETS2 Speed Recorder\\config_ETS2speedRecorder.txt";

            this.config = Method.deserialize(config_path);
            numericUpDown1.Value = (decimal)config.max_speed;
            numericUpDown2.Value = config.cruise_speed;
            numericUpDown3.Value = config.max_speed_sound;
            numericUpDown4.Value = config.cruise_speed_sound;
            numericUpDown5.Value = config.tb_client_sound;

            numericUpDown6.Value = config.cruiseOnSpeedSound;
            numericUpDown7.Value = config.cruseOnSpeed;


        }

        private void button4_Click(object sender, EventArgs e)
        {
            config.max_speed = (float)numericUpDown1.Value;
            config.cruise_speed = (int)numericUpDown2.Value;
            config.max_speed_sound = (int)numericUpDown3.Value;
            config.cruise_speed_sound = (int)numericUpDown4.Value;
            config.tb_client_sound = (int) numericUpDown5.Value;

            config.cruiseOnSpeedSound = (int)numericUpDown6.Value;
            config.cruseOnSpeed = (int)numericUpDown7.Value;

            Method.Serialize(this.config,config_path);

            this.Close();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Console.Beep((int)numericUpDown6.Value, 800);
        }
    }
}
