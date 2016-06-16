using Microsoft.SPOT.Hardware;
using System.Threading;

namespace SPI_Accelerometer
{
    public class Program
    {

        static SPI MySPI = null;
        public static void WriteRegister(byte register, byte data)
        {
            byte[] tx_data = new byte[2];           //Write data
            tx_data[0] = (byte)(register | 0x00);   //LSB is 0 to write
            tx_data[1] = data;                      
            MySPI.Write(tx_data);
        }
        public static byte ReadRegister(byte register)//Reading from register SPI. 
        {
            byte[] tx_data = new byte[2];           //Write data
            byte[] rx_data = new byte[2];           //Read data
            tx_data[0] = (byte)(register | 0x80);   //MSB is 1 to read
            tx_data[1] = 0;                         //In read it doesn't matters what we write
            MySPI.WriteRead(tx_data, rx_data);      
            return rx_data[1];                      
        }
        public static void Main()
        {
            OutputPort led = new OutputPort((Cpu.Pin)63, false);    //Red led
            OutputPort led0 = new OutputPort((Cpu.Pin)62, false);   //Blue led
            OutputPort led1 = new OutputPort((Cpu.Pin)61, false);   //Green led
            OutputPort led2 = new OutputPort((Cpu.Pin)60, false);   //Orange led

            //Config Accelerometer
            SPI.Configuration MyConfig =
                new SPI.Configuration((Cpu.Pin)67, false, 0, 0, true, true, 1000, SPI.SPI_module.SPI1);
            MySPI = new SPI(MyConfig);
            WriteRegister(0x20, 0xC7);

            while (true)
            {
                //Turn off all LED's
                led.Write(false);
                led0.Write(false);
                led1.Write(false);
                led2.Write(false);
                if ((ReadRegister(0x2D) > 150) && (ReadRegister(0x2D) < 230))//If STM32f4 is flipped
                {
                    //Turn on all LED's
                    led.Write(true);
                    led0.Write(true);
                    led1.Write(true);
                    led2.Write(true);
                }
                
                if ((ReadRegister(0x29) > 160) && (ReadRegister(0x29) < 230))
                    led2.Write(true);//orange
                if ((ReadRegister(0x29) < 140) && (ReadRegister(0x29) > 20))
                    led0.Write(true);//blue
                if ((ReadRegister(0x2B) > 160) && (ReadRegister(0x2B) < 230))
                    led.Write(true);//red
                if ((ReadRegister(0x2B) < 140) && (ReadRegister(0x2B) > 20))
                    led1.Write(true);//green
                Thread.Sleep(100);//Wait 100 milliseconds to reduce the amount of erroneous results.
            }
        }
    }
}
