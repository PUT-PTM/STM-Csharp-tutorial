using Microsoft.SPOT.Hardware;

namespace Button
{
    public class Program
    {
        public static void Main()
        {
            InterruptPort button =
                new InterruptPort((Cpu.Pin)0, false, Port.ResistorMode.PullDown, Port.InterruptMode.InterruptEdgeLevelHigh);
             OutputPort led = new OutputPort((Cpu.Pin)63, false);
             OutputPort led0 = new OutputPort((Cpu.Pin)62, false);
             OutputPort led1 = new OutputPort((Cpu.Pin)61, false);
             OutputPort led2 = new OutputPort((Cpu.Pin)60, false);
            while (true)
            {
                if (!button.Read() == true)
                {
                    led.Write(true);
                    led0.Write(true);
                    led1.Write(false);
                    led2.Write(false);
                }
                else
                {
                    led.Write(false);
                    led0.Write(false);
                    led1.Write(true);
                    led2.Write(true);
                }
            }
        }
    }
}