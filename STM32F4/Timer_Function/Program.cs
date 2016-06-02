using System;
using Microsoft.SPOT.Hardware;
using System.Threading;

namespace Timer_Function
{
    public class Program
    {
        public static int x;
        public static OutputPort led;
        public static OutputPort led0;
        public static OutputPort led1;
        public static OutputPort led2;
        public static void funTimer(object state)
        {
            if (x == 1)
            {
                led.Write(true);
                led0.Write(true);
                led1.Write(true);
                led2.Write(true);
                x = 0;
            }
            else
            {
                led.Write(false);
                led0.Write(false);
                led1.Write(false);
                led2.Write(false);
                x = 1;
            }
        }
        public static void Main()
        {
            x = 1;
            led = new OutputPort((Cpu.Pin)63, false);
            led0 = new OutputPort((Cpu.Pin)62, false);
            led1 = new OutputPort((Cpu.Pin)61, false);
            led2 = new OutputPort((Cpu.Pin)60, false);
            Timer timer = new System.Threading.Timer(funTimer, null, 0, 1000);
            while (true) { }
        }
    }
}
