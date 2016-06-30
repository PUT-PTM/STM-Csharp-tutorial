using Microsoft.SPOT.Hardware;

namespace Button
{
    public class Program
    {
        public static void Main()
        {
            InterruptPort button = 
                new InterruptPort((Cpu.Pin)0, false, Port.ResistorMode.PullDown, Port.InterruptMode.InterruptEdgeLevelHigh);//Button Declaration. 
            OutputPort led = new OutputPort((Cpu.Pin)63, false);    //Blue led
            OutputPort led0 = new OutputPort((Cpu.Pin)62, false);   //Red led
            OutputPort led1 = new OutputPort((Cpu.Pin)61, false);   //Orange led
            OutputPort led2 = new OutputPort((Cpu.Pin)60, false);   //Green led

            while (true)//control loop
            {
                if (button.Read() == true) //if button click
                {
                    //Turn on red and blue led, turn off orange and green led
                    led.Write(true);
                    led0.Write(true);
                    led1.Write(false);
                    led2.Write(false);
                }
                else
                {
                    //Turn on orange and green led, turn off red and blue led
                    led.Write(false);
                    led0.Write(false);
                    led1.Write(true);
                    led2.Write(true);
                }
            }
        }
    }
}