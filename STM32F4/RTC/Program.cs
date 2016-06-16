using System;
using Microsoft.SPOT;
namespace RTC
{
    public class Program
    {
        public static void Main()
        {
            long Ticks = 0; 
            bool check = true;
            while (true)//control loop
            {
                if (DateTime.Now.Second% 2==0)
                {
                    if (check == true)//Taking actual number of ticks.
                    {
                        Ticks = DateTime.Now.Ticks;
                        Debug.Print("Ticks:" + Ticks);
                        check = false;
                    }
                }
                else
                    if (check == true)//Checking how many ticks are made in 1 second
                    {
                        Ticks = DateTime.Now.Ticks - Ticks; 
                        Debug.Print("Ticks in 1 sec:" + Ticks);
                        check = false;
                    }
            }
        }
    }
}
