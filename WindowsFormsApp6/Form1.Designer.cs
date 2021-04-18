namespace WindowsFormsApp6
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.c_speed = new System.Windows.Forms.Label();
            this.max_speed = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.configToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setSPPathToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.singlePlayerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tMPPathToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tBClientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tBNotOpenWarningToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.maxSpeedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cruiseSpeedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CruiseOnItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tBNotOpenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setWarnningSoundsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataUpdateDelayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.delay1 = new System.Windows.Forms.ToolStripMenuItem();
            this.delay2 = new System.Windows.Forms.ToolStripMenuItem();
            this.delay3 = new System.Windows.Forms.ToolStripMenuItem();
            this.delay4 = new System.Windows.Forms.ToolStripMenuItem();
            this.delay5 = new System.Windows.Forms.ToolStripMenuItem();
            this.delay6 = new System.Windows.Forms.ToolStripMenuItem();
            this.istopMost = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // c_speed
            // 
            this.c_speed.AutoSize = true;
            this.c_speed.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c_speed.Location = new System.Drawing.Point(12, 42);
            this.c_speed.Name = "c_speed";
            this.c_speed.Size = new System.Drawing.Size(142, 20);
            this.c_speed.TabIndex = 0;
            this.c_speed.Text = "Current Speed :-";
            // 
            // max_speed
            // 
            this.max_speed.AutoSize = true;
            this.max_speed.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.max_speed.Location = new System.Drawing.Point(12, 69);
            this.max_speed.Name = "max_speed";
            this.max_speed.Size = new System.Drawing.Size(114, 20);
            this.max_speed.TabIndex = 1;
            this.max_speed.Text = "Max Speed :-";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(172, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "0 Kmph";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Maroon;
            this.label2.Location = new System.Drawing.Point(171, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "0 Kmph";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DarkTurquoise;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(112, 95);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(118, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Reset Max Speed";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 159);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(139, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "Cruise Control :-";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Red;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(160, 159);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "OFF";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 184);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(133, 20);
            this.label5.TabIndex = 10;
            this.label5.Text = "Cruise Speed :-";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(158, 184);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 20);
            this.label6.TabIndex = 11;
            this.label6.Text = "0 Kmph";
            // 
            // button2
            // 
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.Location = new System.Drawing.Point(399, 129);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(70, 70);
            this.button2.TabIndex = 12;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button3.BackgroundImage")));
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button3.Location = new System.Drawing.Point(399, 214);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(70, 70);
            this.button3.TabIndex = 13;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox2.Location = new System.Drawing.Point(352, 27);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(142, 17);
            this.checkBox2.TabIndex = 14;
            this.checkBox2.Text = "TB Client Auto Open";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(396, 103);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Not Running";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(508, 24);
            this.menuStrip1.TabIndex = 18;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // configToolStripMenuItem
            // 
            this.configToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setSPPathToolStripMenuItem,
            this.tBNotOpenWarningToolStripMenuItem,
            this.setWarnningSoundsToolStripMenuItem,
            this.dataUpdateDelayToolStripMenuItem,
            this.istopMost,
            this.exitToolStripMenuItem,
            this.exitToolStripMenuItem1});
            this.configToolStripMenuItem.Name = "configToolStripMenuItem";
            this.configToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.configToolStripMenuItem.Text = "Config";
            // 
            // setSPPathToolStripMenuItem
            // 
            this.setSPPathToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.singlePlayerToolStripMenuItem,
            this.tMPPathToolStripMenuItem,
            this.tBClientToolStripMenuItem});
            this.setSPPathToolStripMenuItem.Name = "setSPPathToolStripMenuItem";
            this.setSPPathToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.setSPPathToolStripMenuItem.Text = "Set Path";
            // 
            // singlePlayerToolStripMenuItem
            // 
            this.singlePlayerToolStripMenuItem.Name = "singlePlayerToolStripMenuItem";
            this.singlePlayerToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.singlePlayerToolStripMenuItem.Text = "SP Path";
            this.singlePlayerToolStripMenuItem.Click += new System.EventHandler(this.singlePlayerToolStripMenuItem_Click);
            // 
            // tMPPathToolStripMenuItem
            // 
            this.tMPPathToolStripMenuItem.Name = "tMPPathToolStripMenuItem";
            this.tMPPathToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.tMPPathToolStripMenuItem.Text = "TMP Path";
            this.tMPPathToolStripMenuItem.Click += new System.EventHandler(this.tMPPathToolStripMenuItem_Click);
            // 
            // tBClientToolStripMenuItem
            // 
            this.tBClientToolStripMenuItem.Name = "tBClientToolStripMenuItem";
            this.tBClientToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.tBClientToolStripMenuItem.Text = "TB Client";
            this.tBClientToolStripMenuItem.Click += new System.EventHandler(this.tBClientToolStripMenuItem_Click);
            // 
            // tBNotOpenWarningToolStripMenuItem
            // 
            this.tBNotOpenWarningToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.maxSpeedToolStripMenuItem,
            this.cruiseSpeedToolStripMenuItem,
            this.CruiseOnItem1,
            this.tBNotOpenToolStripMenuItem});
            this.tBNotOpenWarningToolStripMenuItem.Name = "tBNotOpenWarningToolStripMenuItem";
            this.tBNotOpenWarningToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.tBNotOpenWarningToolStripMenuItem.Text = "Warning";
            // 
            // maxSpeedToolStripMenuItem
            // 
            this.maxSpeedToolStripMenuItem.Name = "maxSpeedToolStripMenuItem";
            this.maxSpeedToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.maxSpeedToolStripMenuItem.Text = "Max Speed";
            this.maxSpeedToolStripMenuItem.Click += new System.EventHandler(this.maxSpeedToolStripMenuItem_Click);
            // 
            // cruiseSpeedToolStripMenuItem
            // 
            this.cruiseSpeedToolStripMenuItem.Name = "cruiseSpeedToolStripMenuItem";
            this.cruiseSpeedToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.cruiseSpeedToolStripMenuItem.Text = "Cruise Speed";
            this.cruiseSpeedToolStripMenuItem.Click += new System.EventHandler(this.cruiseSpeedToolStripMenuItem_Click);
            // 
            // CruiseOnItem1
            // 
            this.CruiseOnItem1.Name = "CruiseOnItem1";
            this.CruiseOnItem1.Size = new System.Drawing.Size(142, 22);
            this.CruiseOnItem1.Text = "Cruise On";
            this.CruiseOnItem1.Click += new System.EventHandler(this.CruiseOnItem1_Click);
            // 
            // tBNotOpenToolStripMenuItem
            // 
            this.tBNotOpenToolStripMenuItem.Name = "tBNotOpenToolStripMenuItem";
            this.tBNotOpenToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.tBNotOpenToolStripMenuItem.Text = "TB Not Open";
            this.tBNotOpenToolStripMenuItem.Click += new System.EventHandler(this.tBNotOpenToolStripMenuItem_Click);
            // 
            // setWarnningSoundsToolStripMenuItem
            // 
            this.setWarnningSoundsToolStripMenuItem.Name = "setWarnningSoundsToolStripMenuItem";
            this.setWarnningSoundsToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.setWarnningSoundsToolStripMenuItem.Text = "Warning Settings";
            this.setWarnningSoundsToolStripMenuItem.Click += new System.EventHandler(this.setWarnningSoundsToolStripMenuItem_Click);
            // 
            // dataUpdateDelayToolStripMenuItem
            // 
            this.dataUpdateDelayToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.delay1,
            this.delay2,
            this.delay3,
            this.delay4,
            this.delay5,
            this.delay6});
            this.dataUpdateDelayToolStripMenuItem.Name = "dataUpdateDelayToolStripMenuItem";
            this.dataUpdateDelayToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.dataUpdateDelayToolStripMenuItem.Text = "Data Update Delay";
            // 
            // delay1
            // 
            this.delay1.Name = "delay1";
            this.delay1.Size = new System.Drawing.Size(114, 22);
            this.delay1.Text = "10ms";
            this.delay1.Click += new System.EventHandler(this.delay1_Click);
            // 
            // delay2
            // 
            this.delay2.Name = "delay2";
            this.delay2.Size = new System.Drawing.Size(114, 22);
            this.delay2.Text = "50ms";
            this.delay2.Click += new System.EventHandler(this.delay2_Click);
            // 
            // delay3
            // 
            this.delay3.Name = "delay3";
            this.delay3.Size = new System.Drawing.Size(114, 22);
            this.delay3.Text = "100ms";
            this.delay3.Click += new System.EventHandler(this.delay3_Click);
            // 
            // delay4
            // 
            this.delay4.Name = "delay4";
            this.delay4.Size = new System.Drawing.Size(114, 22);
            this.delay4.Text = "200ms";
            this.delay4.Click += new System.EventHandler(this.delay4_Click);
            // 
            // delay5
            // 
            this.delay5.Name = "delay5";
            this.delay5.Size = new System.Drawing.Size(114, 22);
            this.delay5.Text = "500ms";
            this.delay5.Click += new System.EventHandler(this.delay5_Click);
            // 
            // delay6
            // 
            this.delay6.Name = "delay6";
            this.delay6.Size = new System.Drawing.Size(114, 22);
            this.delay6.Text = "1000ms";
            this.delay6.Click += new System.EventHandler(this.delay6_Click);
            // 
            // istopMost
            // 
            this.istopMost.Name = "istopMost";
            this.istopMost.Size = new System.Drawing.Size(171, 22);
            this.istopMost.Text = "Top Most";
            this.istopMost.Click += new System.EventHandler(this.istopMost_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.exitToolStripMenuItem.Text = "About";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem1
            // 
            this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            this.exitToolStripMenuItem1.Size = new System.Drawing.Size(171, 22);
            this.exitToolStripMenuItem1.Text = "Exit";
            this.exitToolStripMenuItem1.Click += new System.EventHandler(this.exitToolStripMenuItem1_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.MediumBlue;
            this.label9.Location = new System.Drawing.Point(13, 97);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(80, 17);
            this.label9.TabIndex = 20;
            this.label9.Text = "181 Kmph";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.MediumBlue;
            this.label10.Location = new System.Drawing.Point(124, 214);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(80, 17);
            this.label10.TabIndex = 21;
            this.label10.Text = "181 Kmph";
            // 
            // button5
            // 
            this.button5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button5.BackgroundImage")));
            this.button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button5.Location = new System.Drawing.Point(399, 50);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(50, 50);
            this.button5.TabIndex = 24;
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(396, 287);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 13);
            this.label8.TabIndex = 25;
            this.label8.Text = "Not Running";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(11, 255);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(152, 20);
            this.label11.TabIndex = 26;
            this.label11.Text = "Driven Distance :-";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(185, 254);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(49, 20);
            this.label12.TabIndex = 27;
            this.label12.Text = "0 Km";
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.DarkTurquoise;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(174, 283);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(59, 23);
            this.button4.TabIndex = 28;
            this.button4.Text = "Reset";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.MediumBlue;
            this.label13.Location = new System.Drawing.Point(13, 214);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(80, 17);
            this.label13.TabIndex = 29;
            this.label13.Text = "181 Kmph";
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.SystemColors.HotTrack;
            this.button6.Location = new System.Drawing.Point(273, 64);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(105, 26);
            this.button6.TabIndex = 30;
            this.button6.Text = "Registry Values";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(508, 311);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.max_speed);
            this.Controls.Add(this.c_speed);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "ETS2 Speed Recorder";
            this.TransparencyKey = System.Drawing.SystemColors.ControlDarkDark;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label c_speed;
        private System.Windows.Forms.Label max_speed;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem configToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setSPPathToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tBNotOpenWarningToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setWarnningSoundsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dataUpdateDelayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem singlePlayerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tMPPathToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem maxSpeedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cruiseSpeedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tBNotOpenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem delay1;
        private System.Windows.Forms.ToolStripMenuItem delay2;
        private System.Windows.Forms.ToolStripMenuItem delay3;
        private System.Windows.Forms.ToolStripMenuItem delay4;
        private System.Windows.Forms.ToolStripMenuItem delay5;
        private System.Windows.Forms.ToolStripMenuItem delay6;
        private System.Windows.Forms.ToolStripMenuItem tBClientToolStripMenuItem;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ToolStripMenuItem istopMost;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ToolStripMenuItem CruiseOnItem1;
        private System.Windows.Forms.Button button6;
    }
}

