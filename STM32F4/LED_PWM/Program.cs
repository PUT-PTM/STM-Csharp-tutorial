using Microsoft.SPOT.Hardware;
using System.Threading;
namespace LED_PWM
{
    public class Program
    {
        public static void Main()
        {
            var green = new PWM(Cpu.PWMChannel.PWM_0, 300, 0, false);
            var orange = new PWM(Cpu.PWMChannel.PWM_1, 300, 0, false);
            var red = new PWM(Cpu.PWMChannel.PWM_2, 300, 0, false);
            var blue = new PWM(Cpu.PWMChannel.PWM_3, 300, 0, false);
            green.Start();
            orange.Start();
            red.Start();
            blue.Start();
            while (true)
            {
                for (int i = 0; i <= 10; i++)
                {
                    red.DutyCycle = 1 - ((double)i / 10);
                    Thread.Sleep(1000);
                }
                for (int i = 0; i <= 10; i++)
                {
                    blue.DutyCycle = 1 - ((double)i / 10);
                    Thread.Sleep(1000);
                }
                for (int i = 0; i <= 10; i++)
                {
                    green.DutyCycle = 1 - ((double)i / 10);
                    Thread.Sleep(1000);
                }
                for (int i = 0; i <= 10; i++)
                {
                    orange.DutyCycle = 1 - ((double)i / 10);
                    Thread.Sleep(1000);
                }
            }
        }
    }
}
