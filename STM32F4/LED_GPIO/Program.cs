using Microsoft.SPOT.Hardware;
namespace LED_GPIO
{
    public class Program
    {
        public static void Main()
        {
            OutputPort led = new OutputPort((Cpu.Pin)63, false);
            OutputPort led0 = new OutputPort((Cpu.Pin)62, false);
            OutputPort led1 = new OutputPort((Cpu.Pin)61, false);
            OutputPort led2 = new OutputPort((Cpu.Pin)60, false);
            while (true)
            {
                led.Write(true);
                led0.Write(true);
                led1.Write(true);
                led2.Write(true);
                for (int i = 0; i < 100000; i++) { }
                led.Write(false);
                led0.Write(false);
                led1.Write(false);
                led2.Write(false);
                for (int i = 0; i < 100000; i++) { }
            }
        }
    }
}
