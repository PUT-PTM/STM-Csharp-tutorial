using System;
using Microsoft.SPOT.Hardware;
using System.Threading;

namespace Timer_Function
{
    public class Program
    {
        public static bool LED_ON; //state of LED
        public static OutputPort led;
        public static OutputPort led0;
        public static OutputPort led1;
        public static OutputPort led2;
        public static void funTimer(object state)
        {
                //Turn on or off all leds
                led.Write(LED_ON);
                led0.Write(LED_ON);
                led1.Write(LED_ON);
                led2.Write(LED_ON);
                LED_ON = !LED_ON;
        }
        public static void Main()
        {
            LED_ON = true;
            led = new OutputPort((Cpu.Pin)63, false);    //Blue led
            led0 = new OutputPort((Cpu.Pin)62, false);   //Red led
            led1 = new OutputPort((Cpu.Pin)61, false);   //Orange led
            led2 = new OutputPort((Cpu.Pin)60, false);   //Green led

            Timer timer = new System.Threading.Timer(funTimer, null, 0, 1000);//Set timer. Timer each second trigger "funTimer" function.
            while (true) { }//Control loop
        }
    }
}
