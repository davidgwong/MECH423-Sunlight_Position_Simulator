namespace MECH_423_City_Lookup
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
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label label6;
            System.Windows.Forms.Label label7;
            System.Windows.Forms.Label label8;
            System.Windows.Forms.Label label9;
            System.Windows.Forms.Label label10;
            System.Windows.Forms.Label label11;
            System.Windows.Forms.Label label12;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.txtbxCityName = new System.Windows.Forms.TextBox();
            this.txtbxLat = new System.Windows.Forms.TextBox();
            this.txtbxLong = new System.Windows.Forms.TextBox();
            this.btnGetResults = new System.Windows.Forms.Button();
            this.btnSendMonth = new System.Windows.Forms.Button();
            this.btnSendAuto = new System.Windows.Forms.Button();
            this.cmbbxCOMPortsArduino = new System.Windows.Forms.ComboBox();
            this.btnConnectArduino = new System.Windows.Forms.Button();
            this.serArduino = new System.IO.Ports.SerialPort(this.components);
            this.cmbbxCOMPortsMSP = new System.Windows.Forms.ComboBox();
            this.btnConnectMSP = new System.Windows.Forms.Button();
            this.serMSP = new System.IO.Ports.SerialPort(this.components);
            this.btnMoveStepper = new System.Windows.Forms.Button();
            this.txtbxCurrentLongitude = new System.Windows.Forms.TextBox();
            this.txtbxCurrentMonth = new System.Windows.Forms.TextBox();
            this.tmrUpdatePos = new System.Windows.Forms.Timer(this.components);
            this.btnHome = new System.Windows.Forms.Button();
            this.txtbxSunrise = new System.Windows.Forms.TextBox();
            this.txtbxSunset = new System.Windows.Forms.TextBox();
            this.txtbxTwilightBegins = new System.Windows.Forms.TextBox();
            this.txtbxTwilightEnds = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            label9 = new System.Windows.Forms.Label();
            label10 = new System.Windows.Forms.Label();
            label11 = new System.Windows.Forms.Label();
            label12 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.Location = new System.Drawing.Point(13, 16);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(142, 25);
            label1.TabIndex = 0;
            label1.Text = "Enter city here:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label2.Location = new System.Drawing.Point(13, 104);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(87, 25);
            label2.TabIndex = 0;
            label2.Text = "Latitude:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label3.Location = new System.Drawing.Point(13, 140);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(104, 25);
            label3.TabIndex = 0;
            label3.Text = "Longitude:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label4.Location = new System.Drawing.Point(13, 52);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(167, 25);
            label4.TabIndex = 0;
            label4.Text = "Enter month here:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label5.Location = new System.Drawing.Point(13, 355);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(186, 25);
            label5.TabIndex = 0;
            label5.Text = "Connect to Arduino:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label6.Location = new System.Drawing.Point(13, 389);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(195, 25);
            label6.TabIndex = 0;
            label6.Text = "Connect to MSP430:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label7.Location = new System.Drawing.Point(13, 272);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(167, 25);
            label7.TabIndex = 0;
            label7.Text = "Current longitude:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label8.Location = new System.Drawing.Point(13, 310);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(142, 25);
            label8.TabIndex = 0;
            label8.Text = "Current month:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label9.Location = new System.Drawing.Point(13, 188);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(90, 25);
            label9.TabIndex = 0;
            label9.Text = "Sun rise:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label10.Location = new System.Drawing.Point(13, 224);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(85, 25);
            label10.TabIndex = 0;
            label10.Text = "Sun set:";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label11.Location = new System.Drawing.Point(292, 186);
            label11.Name = "label11";
            label11.Size = new System.Drawing.Size(181, 25);
            label11.TabIndex = 0;
            label11.Text = "Civil twilight begins:";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label12.Location = new System.Drawing.Point(292, 227);
            label12.Name = "label12";
            label12.Size = new System.Drawing.Size(166, 25);
            label12.TabIndex = 0;
            label12.Text = "Civil twilight ends:";
            // 
            // txtbxCityName
            // 
            this.txtbxCityName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbxCityName.Location = new System.Drawing.Point(186, 13);
            this.txtbxCityName.Name = "txtbxCityName";
            this.txtbxCityName.Size = new System.Drawing.Size(451, 30);
            this.txtbxCityName.TabIndex = 1;
            // 
            // txtbxLat
            // 
            this.txtbxLat.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbxLat.Location = new System.Drawing.Point(161, 101);
            this.txtbxLat.Name = "txtbxLat";
            this.txtbxLat.Size = new System.Drawing.Size(476, 30);
            this.txtbxLat.TabIndex = 1;
            // 
            // txtbxLong
            // 
            this.txtbxLong.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbxLong.Location = new System.Drawing.Point(161, 137);
            this.txtbxLong.Name = "txtbxLong";
            this.txtbxLong.Size = new System.Drawing.Size(476, 30);
            this.txtbxLong.TabIndex = 1;
            // 
            // btnGetResults
            // 
            this.btnGetResults.Location = new System.Drawing.Point(656, 13);
            this.btnGetResults.Name = "btnGetResults";
            this.btnGetResults.Size = new System.Drawing.Size(142, 30);
            this.btnGetResults.TabIndex = 2;
            this.btnGetResults.Text = "Get Results";
            this.btnGetResults.UseVisualStyleBackColor = true;
            this.btnGetResults.Click += new System.EventHandler(this.btnGetResults_Click);
            // 
            // btnSendMonth
            // 
            this.btnSendMonth.Location = new System.Drawing.Point(656, 49);
            this.btnSendMonth.Name = "btnSendMonth";
            this.btnSendMonth.Size = new System.Drawing.Size(142, 30);
            this.btnSendMonth.TabIndex = 2;
            this.btnSendMonth.Text = "Send Month";
            this.btnSendMonth.UseVisualStyleBackColor = true;
            this.btnSendMonth.Click += new System.EventHandler(this.btnSendMonth_Click);
            // 
            // btnSendAuto
            // 
            this.btnSendAuto.Location = new System.Drawing.Point(658, 137);
            this.btnSendAuto.Name = "btnSendAuto";
            this.btnSendAuto.Size = new System.Drawing.Size(142, 30);
            this.btnSendAuto.TabIndex = 2;
            this.btnSendAuto.Text = "Auto";
            this.btnSendAuto.UseVisualStyleBackColor = true;
            this.btnSendAuto.Click += new System.EventHandler(this.btnSendAuto_Click);
            // 
            // cmbbxCOMPortsArduino
            // 
            this.cmbbxCOMPortsArduino.FormattingEnabled = true;
            this.cmbbxCOMPortsArduino.Location = new System.Drawing.Point(205, 352);
            this.cmbbxCOMPortsArduino.Name = "cmbbxCOMPortsArduino";
            this.cmbbxCOMPortsArduino.Size = new System.Drawing.Size(121, 28);
            this.cmbbxCOMPortsArduino.TabIndex = 4;
            this.cmbbxCOMPortsArduino.DropDown += new System.EventHandler(this.cmbbxCOMPortsArduino_DropDown);
            // 
            // btnConnectArduino
            // 
            this.btnConnectArduino.Location = new System.Drawing.Point(332, 350);
            this.btnConnectArduino.Name = "btnConnectArduino";
            this.btnConnectArduino.Size = new System.Drawing.Size(142, 30);
            this.btnConnectArduino.TabIndex = 2;
            this.btnConnectArduino.Text = "Connect";
            this.btnConnectArduino.UseVisualStyleBackColor = true;
            this.btnConnectArduino.Click += new System.EventHandler(this.btnConnectArduino_Click);
            // 
            // cmbbxCOMPortsMSP
            // 
            this.cmbbxCOMPortsMSP.FormattingEnabled = true;
            this.cmbbxCOMPortsMSP.Location = new System.Drawing.Point(204, 386);
            this.cmbbxCOMPortsMSP.Name = "cmbbxCOMPortsMSP";
            this.cmbbxCOMPortsMSP.Size = new System.Drawing.Size(121, 28);
            this.cmbbxCOMPortsMSP.TabIndex = 4;
            this.cmbbxCOMPortsMSP.DropDown += new System.EventHandler(this.cmbbxCOMPortsMSP_DropDown);
            // 
            // btnConnectMSP
            // 
            this.btnConnectMSP.Location = new System.Drawing.Point(331, 384);
            this.btnConnectMSP.Name = "btnConnectMSP";
            this.btnConnectMSP.Size = new System.Drawing.Size(142, 30);
            this.btnConnectMSP.TabIndex = 2;
            this.btnConnectMSP.Text = "Connect";
            this.btnConnectMSP.UseVisualStyleBackColor = true;
            this.btnConnectMSP.Click += new System.EventHandler(this.btnConnectMSP_Click);
            // 
            // serMSP
            // 
            this.serMSP.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serMSP_DataReceived);
            // 
            // btnMoveStepper
            // 
            this.btnMoveStepper.Location = new System.Drawing.Point(656, 101);
            this.btnMoveStepper.Name = "btnMoveStepper";
            this.btnMoveStepper.Size = new System.Drawing.Size(142, 30);
            this.btnMoveStepper.TabIndex = 2;
            this.btnMoveStepper.Text = "Move Motor";
            this.btnMoveStepper.UseVisualStyleBackColor = true;
            this.btnMoveStepper.Click += new System.EventHandler(this.btnMoveStepper_Click);
            // 
            // txtbxCurrentLongitude
            // 
            this.txtbxCurrentLongitude.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbxCurrentLongitude.Location = new System.Drawing.Point(186, 269);
            this.txtbxCurrentLongitude.Name = "txtbxCurrentLongitude";
            this.txtbxCurrentLongitude.Size = new System.Drawing.Size(451, 30);
            this.txtbxCurrentLongitude.TabIndex = 1;
            // 
            // txtbxCurrentMonth
            // 
            this.txtbxCurrentMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbxCurrentMonth.Location = new System.Drawing.Point(186, 305);
            this.txtbxCurrentMonth.Name = "txtbxCurrentMonth";
            this.txtbxCurrentMonth.Size = new System.Drawing.Size(451, 30);
            this.txtbxCurrentMonth.TabIndex = 1;
            // 
            // tmrUpdatePos
            // 
            this.tmrUpdatePos.Enabled = true;
            this.tmrUpdatePos.Tick += new System.EventHandler(this.tmrUpdatePos_Tick);
            // 
            // btnHome
            // 
            this.btnHome.Location = new System.Drawing.Point(656, 269);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(142, 30);
            this.btnHome.TabIndex = 2;
            this.btnHome.Text = "Home";
            this.btnHome.UseVisualStyleBackColor = true;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // txtbxSunrise
            // 
            this.txtbxSunrise.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbxSunrise.Location = new System.Drawing.Point(110, 185);
            this.txtbxSunrise.Name = "txtbxSunrise";
            this.txtbxSunrise.Size = new System.Drawing.Size(164, 30);
            this.txtbxSunrise.TabIndex = 1;
            // 
            // txtbxSunset
            // 
            this.txtbxSunset.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbxSunset.Location = new System.Drawing.Point(110, 221);
            this.txtbxSunset.Name = "txtbxSunset";
            this.txtbxSunset.Size = new System.Drawing.Size(164, 30);
            this.txtbxSunset.TabIndex = 1;
            // 
            // txtbxTwilightBegins
            // 
            this.txtbxTwilightBegins.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbxTwilightBegins.Location = new System.Drawing.Point(473, 183);
            this.txtbxTwilightBegins.Name = "txtbxTwilightBegins";
            this.txtbxTwilightBegins.Size = new System.Drawing.Size(164, 30);
            this.txtbxTwilightBegins.TabIndex = 1;
            // 
            // txtbxTwilightEnds
            // 
            this.txtbxTwilightEnds.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbxTwilightEnds.Location = new System.Drawing.Point(473, 219);
            this.txtbxTwilightEnds.Name = "txtbxTwilightEnds";
            this.txtbxTwilightEnds.Size = new System.Drawing.Size(164, 30);
            this.txtbxTwilightEnds.TabIndex = 1;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(186, 53);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(451, 26);
            this.dateTimePicker1.TabIndex = 5;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(821, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(993, 492);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1834, 517);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.cmbbxCOMPortsMSP);
            this.Controls.Add(this.cmbbxCOMPortsArduino);
            this.Controls.Add(this.btnConnectMSP);
            this.Controls.Add(this.btnConnectArduino);
            this.Controls.Add(this.btnHome);
            this.Controls.Add(this.btnSendAuto);
            this.Controls.Add(this.btnSendMonth);
            this.Controls.Add(this.btnMoveStepper);
            this.Controls.Add(this.btnGetResults);
            this.Controls.Add(this.txtbxCurrentMonth);
            this.Controls.Add(this.txtbxCurrentLongitude);
            this.Controls.Add(this.txtbxTwilightEnds);
            this.Controls.Add(this.txtbxSunset);
            this.Controls.Add(this.txtbxLong);
            this.Controls.Add(this.txtbxTwilightBegins);
            this.Controls.Add(this.txtbxSunrise);
            this.Controls.Add(this.txtbxLat);
            this.Controls.Add(label6);
            this.Controls.Add(label5);
            this.Controls.Add(label8);
            this.Controls.Add(label7);
            this.Controls.Add(label12);
            this.Controls.Add(label4);
            this.Controls.Add(label10);
            this.Controls.Add(label11);
            this.Controls.Add(this.txtbxCityName);
            this.Controls.Add(label9);
            this.Controls.Add(label3);
            this.Controls.Add(label2);
            this.Controls.Add(label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Sunlight Simulator";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtbxCityName;
        private System.Windows.Forms.TextBox txtbxLat;
        private System.Windows.Forms.TextBox txtbxLong;
        private System.Windows.Forms.Button btnGetResults;
        private System.Windows.Forms.Button btnSendMonth;
        private System.Windows.Forms.Button btnSendAuto;
        private System.Windows.Forms.Button btnConnectArduino;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox cmbbxCOMPortsArduino;
        private System.IO.Ports.SerialPort serArduino;
        private System.Windows.Forms.ComboBox cmbbxCOMPortsMSP;
        private System.Windows.Forms.Button btnConnectMSP;
        private System.IO.Ports.SerialPort serMSP;
        private System.Windows.Forms.Button btnMoveStepper;
        private System.Windows.Forms.TextBox txtbxCurrentLongitude;
        private System.Windows.Forms.TextBox txtbxCurrentMonth;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Timer tmrUpdatePos;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.TextBox txtbxSunrise;
        private System.Windows.Forms.TextBox txtbxSunset;
        private System.Windows.Forms.TextBox txtbxTwilightBegins;
        private System.Windows.Forms.TextBox txtbxTwilightEnds;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

