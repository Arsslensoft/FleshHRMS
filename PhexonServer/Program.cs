using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhexonServer
{
    class Program
    {
        static void Main(string[] args)
        {
          
            FHRMS.Automatics.PhexonPilot pilot = new FHRMS.Automatics.PhexonPilot(new TimeSpan(06,00,00),new TimeSpan(20,00,00), new TimeSpan(00,01,00));
            Console.Title = "Phexon Server";
            Console.WriteLine("Daily routine : " + pilot.DailyCheckTime);
            Console.WriteLine("Nightly routine : " + pilot.NightCheckTime);
            Console.WriteLine("Reset : " + pilot.ResetTime);
            Console.WriteLine("Press any key to exit...");
            pilot.Start();
            Console.ReadKey();
            pilot.Stop();
        }
    }
}
