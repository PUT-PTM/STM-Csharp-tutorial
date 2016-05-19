using System;
using Microsoft.SPOT.Hardware;
namespace PTM
{
    public class Program
    {
        public static void Main()
        {
            OutputPort led = new OutputPort((Cpu.Pin)60, false);
            OutputPort led2 = new OutputPort((Cpu.Pin)61, false);
            OutputPort led3 = new OutputPort((Cpu.Pin)62, false);
            OutputPort led4 = new OutputPort((Cpu.Pin)63, false);
            while (true)
            {
                {
                    if (DateTime.Now.Second % 4 == 0)
                    {
                        led.Write(true);
                        led4.Write(false);
                    }
                    else
                        if (DateTime.Now.Second % 4 == 1)
                        {
                            led2.Write(true);
                            led.Write(false);
                        }
                        else
                            if (DateTime.Now.Second % 4 == 2)
                            {
                                led3.Write(true);
                                led2.Write(false);
                            }
                            else
                            {
                                led4.Write(true);
                                led3.Write(false);
                            }
                }
            }
        }
    }
}