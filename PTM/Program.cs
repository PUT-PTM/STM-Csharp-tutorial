using System;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using System.Diagnostics;
using System.Threading;
namespace PTM
{
    public class Program
    {
        public static void Main()
        {
            var green = new PWM(Cpu.PWMChannel.PWM_0, 300, 0, false);//zielona
            var orange = new PWM(Cpu.PWMChannel.PWM_1, 300, 0, false);//pomaranczowa
            var red = new PWM(Cpu.PWMChannel.PWM_2, 300, 0, false); //czerwona
            var blue = new PWM(Cpu.PWMChannel.PWM_3, 300, 0, false);//niebieska
            green.Start();
            orange.Start();
            red.Start();
            blue.Start();
            int i = 0;
            while (true)
            {
                red.DutyCycle = 1;
                for (i = 0; i <= 100000; i++) { }
                red.DutyCycle = 0;
                green.DutyCycle = 0.25;
                for (i = 0; i <= 100000; i++) { }
                green.DutyCycle = 0;
                blue.DutyCycle = 0.5;
                for (i = 0; i <= 100000; i++) { }
                blue.DutyCycle = 0;
                orange.DutyCycle = 0.75;
                for (i = 0; i <= 100000; i++) { }
                orange.DutyCycle = 0;
            }
        }
    }
}