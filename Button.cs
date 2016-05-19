using Microsoft.SPOT.Hardware;

    public class Button
    {
        public static void Main()
        {
            OutputPort led = new OutputPort((Cpu.Pin)63, false);
            InterruptPort button =
                new InterruptPort((Cpu.Pin)0, false, Port.ResistorMode.PullDown, Port.InterruptMode.InterruptEdgeLevelHigh);
            while (true)
                if (button.Read() == true)
                    led.Write(true);
                else
                    led.Write(false);
        }
    }
