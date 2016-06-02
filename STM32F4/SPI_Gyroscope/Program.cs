using Microsoft.SPOT.Hardware;
using System.Threading;

namespace SPI_Gyroscope
{
    public class Program
    {

        static SPI MySPI = null;
        public static void WriteRegister(byte register, byte data)
        {
            byte[] tx_data = new byte[2];
            byte[] rx_data = new byte[2];
            tx_data[0] = (byte)(register | 0x00);
            tx_data[1] = data;
            MySPI.Write(tx_data);
        }
        public static byte ReadRegister(byte register)
        {
            byte[] tx_data = new byte[2];
            byte[] rx_data = new byte[2];
            tx_data[0] = (byte)(register | 0x80);
            tx_data[1] = 0;
            MySPI.WriteRead(tx_data, rx_data);
            return rx_data[1];
        }
        public static void Main()
        {
            OutputPort led = new OutputPort((Cpu.Pin)63, false);
            OutputPort led0 = new OutputPort((Cpu.Pin)62, false);
            OutputPort led1 = new OutputPort((Cpu.Pin)61, false);
            OutputPort led2 = new OutputPort((Cpu.Pin)60, false);
            SPI.Configuration MyConfig =
                new SPI.Configuration((Cpu.Pin)67, false, 0, 0, true, true, 1000, SPI.SPI_module.SPI1);
            MySPI = new SPI(MyConfig);
            WriteRegister(0x20, 0xC7);
            while (true)
            {
                    led.Write(false);
                    led0.Write(false);
                    led1.Write(false);
                    led2.Write(false);
                if ((ReadRegister(0x2D) > 150) && (ReadRegister(0x2D) < 230))
                {
                    led.Write(true);
                    led0.Write(true);
                    led1.Write(true);
                    led2.Write(true);
                }
                if ((ReadRegister(0x29) > 160) && (ReadRegister(0x29) < 230))
                    led2.Write(true); 
                if ((ReadRegister(0x29) < 140) && (ReadRegister(0x29) > 20))
                    led0.Write(true);
                if ((ReadRegister(0x2B) > 160) && (ReadRegister(0x2B) < 230))
                    led.Write(true);
                if ((ReadRegister(0x2B) < 140) && (ReadRegister(0x2B) > 20))
                     led1.Write(true);
                Thread.Sleep(100);
            }
        }
    }
}
