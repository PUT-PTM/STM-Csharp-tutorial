using System;
using Microsoft.SPOT;
namespace RTC
{
    public class Program
    {
        public static void Main()
        {
            long x = 0;
            int check = 0;
            while (true)
            {
                if (DateTime.Now.Second% 2==0)
                {
                    if (check == 0)
                    {
                        x = DateTime.Now.Ticks;
                        Debug.Print("Ticks:" + x);
                        check = 1;
                    }
                }
                else
                    if (check == 1)
                    {
                        x = DateTime.Now.Ticks-x;
                        Debug.Print("Ticks in 1 sec:" + x);
                        check = 0;
                    }
            }
        }
    }
}
