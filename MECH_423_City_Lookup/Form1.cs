using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml.XPath;

namespace MECH_423_City_Lookup
{
    public partial class Form1 : Form
    {
        byte[] TxBytesArduino = new Byte[1];
        byte[] TxBytesMSP = new Byte[5];
        double currentPosition = 0;
        int amountStepped = -200;
        Pen myPen = new Pen(Color.Red, 3);

        ConcurrentQueue<int> outputDataQueueLongitude = new ConcurrentQueue<int>();   // Concurrent queue for reading data stream from serial port
        int removedItemInDataQueueLongitude;
        ConcurrentQueue<int> outputDataQueueMonth = new ConcurrentQueue<int>();   // Concurrent queue for reading data stream from serial port
        int removedItemInDataQueueMonth;

        int currentMonth = 1;
        bool autoMode = false;

        int circlePosX;
        int circlePosY;

        int circleSize = 200;
        int circleOffset = 70;
       

        public Form1()
        {
            InitializeComponent();
        }

        public class Result
        {
            public string sunrise { get; set; }
            public string sunset { get; set; }
            public string solar_noon { get; set; }
            public string day_length { get; set; }
            public string civil_twilight_begin { get; set; }
            public string civil_twilight_end { get; set; }
            public string nautical_twilight_begin { get; set; }
            public string nautical_twilight_end { get; set; }
            public string astronomical_twilight_begin { get; set; }
            public string astronomical_twilight_end { get; set; }
        }

        public class SunriseSunsetResult
        {
            public Result results { get; set; }
            public string status { get; set; }
        }

        private void btnGetResults_Click(object sender, EventArgs e)
        {
            // Source: http://stackoverflow.com/questions/16274508/how-to-call-google-geocoding-service-from-c-sharp-code
            var requestUri = string.Format("http://maps.googleapis.com/maps/api/geocode/xml?address={0}&sensor=false", Uri.EscapeDataString(txtbxCityName.Text));

            var request = WebRequest.Create(requestUri);
            var response = request.GetResponse();
            var xdoc = XDocument.Load(response.GetResponseStream());

            var result = xdoc.Element("GeocodeResponse").Element("result");
            var locationElement = result.Element("geometry").Element("location");
            var lat = locationElement.Element("lat").Value;
            var lng = locationElement.Element("lng").Value;

            txtbxLat.Text = lat.ToString();
            txtbxLong.Text = lng.ToString();

            var requestUriSunriseSunset = "http://api.sunrise-sunset.org/json?lat=" +
                                 lat.ToString() +
                                 "&lng=" +
                                 lng.ToString() +
                                 "&date=" + dateTimePicker1.Value.Year.ToString() + "-" +
                                 dateTimePicker1.Value.Month.ToString() + "-" + dateTimePicker1.Value.Day.ToString();

            // Source: http://www.hanselman.com/blog/NuGetPackageOfTheWeek4DeserializingJSONWithJsonNET.aspx
            var client = new WebClient();
            client.Headers.Add("User-Agent", "Nobody"); //my endpoint needs this...
            var responseSunriseSunset = client.DownloadString(new Uri(requestUriSunriseSunset));

            var j = JsonConvert.DeserializeObject<SunriseSunsetResult>(responseSunriseSunset);

            txtbxSunrise.Text = j.results.sunrise.ToString();
            txtbxSunset.Text = j.results.sunset.ToString();
            txtbxTwilightBegins.Text = j.results.civil_twilight_begin.ToString();
            txtbxTwilightEnds.Text = j.results.civil_twilight_end.ToString();
        }
        private void btnSendMonth_Click(object sender, EventArgs e)
        {
            try
            {
                if (serArduino.IsOpen)
                {
                    TxBytesArduino[0] = Convert.ToByte(dateTimePicker1.Value.Month);
                    serArduino.Write(TxBytesArduino, 0, 1);
                    outputDataQueueMonth.Enqueue(dateTimePicker1.Value.Month);
                }
                autoMode = false;
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void btnSendAuto_Click(object sender, EventArgs e)
        {
            try
            {
                if (serMSP.IsOpen)
                {
                    int milliseconds = 200;

                    Thread.Sleep(milliseconds);
                    TxBytesMSP[0] = 255;
                    serMSP.Write(TxBytesMSP, 0, 1);

                    Thread.Sleep(milliseconds);
                    if (autoMode == false) TxBytesMSP[1] = Convert.ToByte(1);  // This is the flag to set auto mode for MSP
                    else TxBytesMSP[1] = Convert.ToByte(0);
                    serMSP.Write(TxBytesMSP, 1, 1);


                    Thread.Sleep(milliseconds);
                    TxBytesMSP[2] = Convert.ToByte(0);
                    serMSP.Write(TxBytesMSP, 2, 1);


                    Thread.Sleep(milliseconds);
                    TxBytesMSP[3] = Convert.ToByte(0);
                    serMSP.Write(TxBytesMSP, 3, 1);


                    Thread.Sleep(milliseconds);
                    TxBytesMSP[4] = 255;
                    serMSP.Write(TxBytesMSP, 4, 1);
                }
                if (autoMode == false)
                {
                    autoMode = true;
                    currentMonth = 1;
                    outputDataQueueMonth.Enqueue(currentMonth);
                    btnSendAuto.Text = "Manual";
                }
                else
                {
                    btnSendAuto.Text = "Auto";
                    autoMode = false;
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
            //try
            //{
            //    if (serArduino.IsOpen)
            //    {
            //        TxBytesArduino[0] = Convert.ToByte(arduinoAutoModeMonth);
            //        serArduino.Write(TxBytesArduino, 0, 1);
            //    }
            //}
            //catch (Exception Ex)
            //{
            //    MessageBox.Show(Ex.Message);
            //}
        }

        private void cmbbxCOMPortsArduino_DropDown(object sender, EventArgs e)
        {
            string[] COMPortNames = System.IO.Ports.SerialPort.GetPortNames().ToArray();
            cmbbxCOMPortsArduino.Items.Clear();
            for (int cntr = 0; cntr < COMPortNames.Length; cntr++)
                cmbbxCOMPortsArduino.Items.Add(COMPortNames[cntr]);
        }

        private void btnConnectArduino_Click(object sender, EventArgs e)
        {
            if (serArduino.IsOpen)
            {
                serArduino.Close();
                btnConnectArduino.Text = "Connect";
                cmbbxCOMPortsArduino.Enabled = true;
            }
            else
            {
                try
                {
                    serArduino.PortName = cmbbxCOMPortsArduino.Text;
                    serArduino.Open();
                    btnConnectArduino.Text = "Disconnect";
                    cmbbxCOMPortsArduino.Enabled = false;
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void cmbbxCOMPortsMSP_DropDown(object sender, EventArgs e)
        {
            string[] COMPortNames = System.IO.Ports.SerialPort.GetPortNames().ToArray();
            cmbbxCOMPortsMSP.Items.Clear();
            for (int cntr = 0; cntr < COMPortNames.Length; cntr++)
                cmbbxCOMPortsMSP.Items.Add(COMPortNames[cntr]);
        }

        private void btnConnectMSP_Click(object sender, EventArgs e)
        {
            if (serMSP.IsOpen)
            {
                serMSP.Close();
                btnConnectMSP.Text = "Connect";
                cmbbxCOMPortsMSP.Enabled = true;
            }
            else
            {
                try
                {
                    serMSP.PortName = cmbbxCOMPortsMSP.Text;
                    serMSP.Open();
                    btnConnectMSP.Text = "Disconnect";
                    cmbbxCOMPortsMSP.Enabled = false;
                }
                catch(Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }

            }
        }

        private void btnMoveStepper_Click(object sender, EventArgs e)
        {

            try
            {
                if (serMSP.IsOpen && autoMode)
                {
                    int milliseconds = 200;

                    Thread.Sleep(milliseconds);
                    TxBytesMSP[0] = 255;
                    serMSP.Write(TxBytesMSP, 0, 1);

                    Thread.Sleep(milliseconds);
                    TxBytesMSP[1] = Convert.ToByte(0);
                    serMSP.Write(TxBytesMSP, 1, 1);


                    Thread.Sleep(milliseconds);
                    TxBytesMSP[2] = Convert.ToByte(0);
                    serMSP.Write(TxBytesMSP, 2, 1);


                    Thread.Sleep(milliseconds);
                    TxBytesMSP[3] = Convert.ToByte(0);
                    serMSP.Write(TxBytesMSP, 3, 1);


                    Thread.Sleep(milliseconds);
                    TxBytesMSP[4] = 255;
                    serMSP.Write(TxBytesMSP, 4, 1);
                }

                currentPosition = 0.9 * amountStepped + 180;
                double textboxLongValue = Convert.ToDouble(txtbxLong.Text);
                double stepAmount;
                if (currentPosition < textboxLongValue)
                    stepAmount = (-textboxLongValue + 360 + currentPosition) / 0.9;
                else
                    stepAmount = (-textboxLongValue + currentPosition) / 0.9;
                int steptAmountInt = Convert.ToInt16(stepAmount);
                int stepAmountToSend = Convert.ToInt16(Math.Abs(stepAmount));
                int directionToSend = 0;

                if (serMSP.IsOpen)
                {
                    int milliseconds = 200;

                    Thread.Sleep(milliseconds);
                    TxBytesMSP[0] = 255;
                    serMSP.Write(TxBytesMSP, 0, 1);
                    
                    Thread.Sleep(milliseconds);
                    TxBytesMSP[1] = Convert.ToByte(directionToSend);
                    serMSP.Write(TxBytesMSP, 1, 1);


                    Thread.Sleep(milliseconds);
                    TxBytesMSP[2] = Convert.ToByte(stepAmountToSend & 255);
                    serMSP.Write(TxBytesMSP, 2, 1);


                    Thread.Sleep(milliseconds);
                    TxBytesMSP[3] = Convert.ToByte(stepAmountToSend >> 8);
                    serMSP.Write(TxBytesMSP, 3, 1);


                    Thread.Sleep(milliseconds);
                    TxBytesMSP[4] = 255;
                    serMSP.Write(TxBytesMSP, 4, 1);
                }

                autoMode = false;
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void serMSP_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            while (serMSP.IsOpen && serMSP.BytesToRead != 0)
            {
                int currentByte = serMSP.ReadByte();
                amountStepped--;
                if (amountStepped < -400) amountStepped += 400;

                outputDataQueueLongitude.Enqueue(amountStepped);
                if (autoMode && amountStepped == -200)
                {
                    currentMonth++;
                    if (currentMonth > 12) currentMonth = 1;

                    TxBytesArduino[0] = Convert.ToByte(currentMonth);
                    serArduino.Write(TxBytesArduino, 0, 1);

                    outputDataQueueMonth.Enqueue(currentMonth);

                    //try
                    //{
                    //    if (serArduino.IsOpen)
                    //    {
                    //        TxBytesArduino[0] = Convert.ToByte(arduinoAutoModeMonth);
                    //        serArduino.Write(TxBytesArduino, 0, 1);
                    //    }
                    //}
                    //catch (Exception Ex)
                    //{
                    //    MessageBox.Show(Ex.Message);
                    //}
                }
            }
            
        }

        private void tmrUpdatePos_Tick(object sender, EventArgs e)
        {
            while (outputDataQueueLongitude.Count() > 1)                                       // While statement to ensure we read the latest data from queue
            {
                outputDataQueueLongitude.TryDequeue(out removedItemInDataQueueLongitude);
            }

            if (outputDataQueueLongitude.TryDequeue(out removedItemInDataQueueLongitude))
            {
                txtbxCurrentLongitude.Text = (0.9*removedItemInDataQueueLongitude + 180).ToString();
                circlePosX = (int) ((removedItemInDataQueueLongitude+350) * 2.5 - circleSize * 1 / 4);
            }

            while (outputDataQueueMonth.Count() > 1)                                       // While statement to ensure we read the latest data from queue
            {
                outputDataQueueMonth.TryDequeue(out removedItemInDataQueueMonth);
            }

            if (outputDataQueueMonth.TryDequeue(out removedItemInDataQueueMonth))
            {
                if (removedItemInDataQueueMonth == 1)
                {
                    txtbxCurrentMonth.Text = "January";
                    circlePosY = 6 * circleOffset - circleSize * 3 / 4;
                }
                if (removedItemInDataQueueMonth == 2)
                {
                    txtbxCurrentMonth.Text = "February";
                    circlePosY = 5 * circleOffset - circleSize * 3 / 4;
                }
                if (removedItemInDataQueueMonth == 3)
                {
                    txtbxCurrentMonth.Text = "March";
                    circlePosY = 4 * circleOffset - circleSize * 3 / 4;
                }
                if (removedItemInDataQueueMonth == 4)
                {
                    txtbxCurrentMonth.Text = "April"; 
                    circlePosY = 3 * circleOffset - circleSize * 3 / 4;
                }
                if (removedItemInDataQueueMonth == 5)
                {
                    txtbxCurrentMonth.Text = "May";
                    circlePosY = 2 * circleOffset - circleSize * 3 / 4;
                }
                if (removedItemInDataQueueMonth == 6)
                {
                    txtbxCurrentMonth.Text = "June";
                    circlePosY = 1 * circleOffset - circleSize * 3 / 4;
                }
                if (removedItemInDataQueueMonth == 7)
                {
                    txtbxCurrentMonth.Text = "July";
                    circlePosY = 2 * circleOffset - circleSize * 3 / 4;
                }
                if (removedItemInDataQueueMonth == 8)
                {
                    txtbxCurrentMonth.Text = "August";
                    circlePosY = 3 * circleOffset - circleSize * 3 / 4;
                }
                if (removedItemInDataQueueMonth == 9)
                {
                    txtbxCurrentMonth.Text = "September";
                    circlePosY = 4 * circleOffset - circleSize * 3 / 4;
                }
                if (removedItemInDataQueueMonth == 10)
                {
                    txtbxCurrentMonth.Text = "October";
                    circlePosY = 5 * circleOffset - circleSize * 3 / 4;
                }
                if (removedItemInDataQueueMonth == 11)
                {
                    txtbxCurrentMonth.Text = "November";
                    circlePosY = 6 * circleOffset - circleSize * 3 / 4;
                }
                if (removedItemInDataQueueMonth == 12)
                {
                    txtbxCurrentMonth.Text = "December";
                    circlePosY = 7 * circleOffset - circleSize * 3 / 4;
                }
            }
            
            
            pictureBox1.Refresh();

        }


        // Pressing the 'Home' button will reset the amountStepped variable to 0 to indiciate 0 degree longitude
        private void btnHome_Click(object sender, EventArgs e)
        {
            amountStepped = -200;

            outputDataQueueLongitude.Enqueue(amountStepped);
        }
        
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawEllipse(myPen, circlePosX, circlePosY, circleSize, circleSize);
        }
    }
    
}
