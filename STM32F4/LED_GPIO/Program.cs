using Microsoft.SPOT.Hardware;
namespace LED_GPIO
{
    public class Program
    {
        public static void Main()
        {
            OutputPort led = new OutputPort((Cpu.Pin)63, false);    //Red led
            OutputPort led0 = new OutputPort((Cpu.Pin)62, false);   //Blue led
            OutputPort led1 = new OutputPort((Cpu.Pin)61, false);   //Green led
            OutputPort led2 = new OutputPort((Cpu.Pin)60, false);   //Orange led

            while (true)//Control loop
            {
                //Turn on all leds
                led.Write(true);
                led0.Write(true);
                led1.Write(true);
                led2.Write(true);
                for (int i = 0; i < 100000; i++) { }//Simple wait loop
                //Turn off all leds
                led.Write(false);
                led0.Write(false);
                led1.Write(false);
                led2.Write(false);
                for (int i = 0; i < 100000; i++) { }//Simple wait loop
            }
        }
    }
}
