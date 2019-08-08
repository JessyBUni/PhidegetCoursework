using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Phidget22;
using Phidget22.Events;
//using Phidget22.ExampleUtils;

namespace Phidget
{
    
    public partial class Form1 : Form
    {
        VoltageInput vin = new VoltageInput();
        int bank = 0;
        public void vin_InputChange(object sender, VoltageInputSensorChangeEventArgs e)
        {
            //this.textBox1.Text = e.SensorValue.ToString();
        }
        public void openPhidget()
        {
            vin.DeviceSerialNumber = 315981; //Address
            
            //vin.HubPort = 2;
            vin.Channel = 0;
            vin.SensorChange += new VoltageInputSensorChangeEventHandler (vin_InputChange);

            vin.Open(5000); //Open
        }

        
        public Form1()
        {
            InitializeComponent();

            openPhidget();

            //vin.VoltageChange += voltageChange;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            vin.VoltageChange += vin_VoltageChange;
        }
        void vin_VoltageChange(object sender, Phidget22.Events.VoltageInputVoltageChangeEventArgs e)
        {
            //textBox1.Text = vin.Voltage.ToString() + " V";
            int value = (int)(vin.Voltage / 0.3);
            TXT_WEIGH.Text = "£"+value.ToString()+".00";
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int price = 2;
            getBankValue(out int m, out bool pass);
            if (pass && m >= price)
            {
                setBank(-price);
            }
            else { message(); }
            setbuttons();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int price = 3;
            getBankValue(out int m, out bool pass);
            if (pass && m >= price)
            {
                setBank(-price);
            }
            else { message(); }
            setbuttons();
        }
        public void getBankValue(out int m, out bool pass)
        {
            string txt_money = TXT_BANK.Text;
            string[] value = txt_money.Split('.');
            string v = value[0];
            v = v.TrimStart('£');
            pass = Int32.TryParse(v, out int money);
            m = money;
        }
        public void setBank(int money)
        {
            bank += money;
            TXT_BANK.Text = "£" + bank + ".00";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string txt_money = TXT_WEIGH.Text;
            string[] value = txt_money.Split('.');
            string v = value[0];
            v = v.TrimStart('£');
            bool pass = Int32.TryParse(v, out int money);
            if (pass)
            {
                setBank(money);
            }
            else { message(); }
            setbuttons();
        }
        public void message()
        {
            MessageBox.Show("There is not enough money in the back to purchase this item","Insuficient funds",MessageBoxButtons.OK,MessageBoxIcon.Warning);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            int price = 1;
            getBankValue(out int m, out bool pass);
            if (pass && m >= price)
            {
                setBank(-price);
            }
            else { message(); }
            setbuttons();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int price = 2;
            getBankValue(out int m, out bool pass);
            if (pass && m >= price)
            {
                setBank(-price);
            }
            else { message(); }
            setbuttons();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int price = 1;
            getBankValue(out int m, out bool pass);
            if (pass && m >= price)
            {
                setBank(-price);
            }
            else { message(); }
            setbuttons();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int price = 4;
            getBankValue(out int m, out bool pass);
            if (pass && m >= price)
            {
                setBank(-price);
            }
            else { message(); }
            setbuttons();
        }
        public void setbuttons()
        {
            if (bank < 1){button2.Enabled = false;}
            else { button2.Enabled = true; }
            if (bank < 2) { button3.Enabled = false; }
            else { button3.Enabled = true; }
            if (bank < 2) { button4.Enabled = false; }
            else { button4.Enabled = true; }
            if (bank < 1) { button7.Enabled = false; }
            else { button7.Enabled = true; }
            if (bank < 3) { button6.Enabled = false; }
            else { button6.Enabled = true; }
            if (bank < 4) { button5.Enabled = false; }
            else { button5.Enabled = true; }

        }
    }
    
}
