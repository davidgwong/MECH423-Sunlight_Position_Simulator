using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web;
using System.Xml.Linq;
using System.Xml.XPath;
using System.Net;
using System.Runtime.Serialization.Json;

namespace MECH_423_City_Lookup
{
    public partial class Form1 : Form
    {
        byte[] TxBytesArduino = new Byte[1];
        byte[] TxBytesMSP = new Byte[5];
        int desiredPosition = 0;
        int currentPosition = 0;

        public Form1()
        {
            InitializeComponent();
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

            txtbxMonth.Text = dateTimePicker1.Value.Month.ToString();
        }
        private void btnSendMonth_Click(object sender, EventArgs e)
        {
            try
            {
                if (serArduino.IsOpen)
                {
                    TxBytesArduino[0] = Convert.ToByte(txtbxMonth.Text);
                    serArduino.Write(TxBytesArduino, 0, 1);
                }
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
                if (serArduino.IsOpen)
                {
                    TxBytesArduino[0] = 13;
                    serArduino.Write(TxBytesArduino, 0, 1);
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
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
                if (!string.IsNullOrWhiteSpace(cmbbxCOMPortsArduino.Text))
                {
                    serArduino.PortName = cmbbxCOMPortsArduino.Text;
                    serArduino.Open();
                    btnConnectArduino.Text = "Disconnect";
                    cmbbxCOMPortsArduino.Enabled = false;
                }
                else
                {
                    MessageBox.Show("No COM port selected. Please try again.", "ERROR");
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

                double textboxLongValue = Convert.ToDouble(txtbxLong.Text);
                double stepAmount = (textboxLongValue - currentPosition) / 1.8;
                int steptAmountInt = Convert.ToInt16(stepAmount);
                int stepAmountToSend = Convert.ToInt16(Math.Abs(stepAmount));
                int directionToSend;

                if (stepAmount > 0) directionToSend = 0;
                else directionToSend = 1;

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
                    TxBytesMSP[3] = Convert.ToByte(stepAmountToSend >> 4);
                    serMSP.Write(TxBytesMSP, 3, 1);


                    Thread.Sleep(milliseconds);
                    TxBytesMSP[4] = 255;
                    serMSP.Write(TxBytesMSP, 4, 1);

                    txtbxCurrent.Text = Convert.ToString(currentPosition);
                    txtbxAmount.Text = Convert.ToString(steptAmountInt);
                    currentPosition += Convert.ToInt16(1.8 * steptAmountInt);
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
    }
    
}
