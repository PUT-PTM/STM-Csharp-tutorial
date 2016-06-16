using Microsoft.SPOT.Hardware;
using System.Threading;
namespace LED_PWM
{
    public class Program
    {
        public static void Main()
        {
            var green = new PWM(Cpu.PWMChannel.PWM_0, 300, 0, false);   //Green led
            var orange = new PWM(Cpu.PWMChannel.PWM_1, 300, 0, false);  //Orange led
            var red = new PWM(Cpu.PWMChannel.PWM_2, 300, 0, false);     //Red led
            var blue = new PWM(Cpu.PWMChannel.PWM_3, 300, 0, false);    //Blue led
            // PWM led initiation
            green.Start();
            orange.Start();
            red.Start();
            blue.Start();
            while (true)//Control loop
            {
                for (int i = 0; i <= 10; i++)
                {
                    red.DutyCycle = 1 - ((double)i / 10);       //Turn on red led with 100%-(i*10)% power light
                    Thread.Sleep(1000);                         //Wait for 1000 milisceonds(1 sec)
                }
                for (int i = 0; i <= 10; i++)
                {
                    blue.DutyCycle = 1 - ((double)i / 10);      //Turn on blue led with 100%-(i*10)% power light
                    Thread.Sleep(1000);                         //Wait for 1000 milisceonds(1 sec)
                }
                for (int i = 0; i <= 10; i++)
                {
                    green.DutyCycle = 1 - ((double)i / 10);     //Turn on green led with 100%-(i*10)% power light
                    Thread.Sleep(1000);                         //Wait for 1000 milisceonds(1 sec)
                }
                for (int i = 0; i <= 10; i++)
                {
                    orange.DutyCycle = 1 - ((double)i / 10);    //Turn on orange led with 100%-(i*10)% power light
                    Thread.Sleep(1000);                         //Wait for 1000 milisceonds(1 sec)
                }
            }
        }
    }
}
