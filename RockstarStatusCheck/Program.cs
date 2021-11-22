using System.Linq;
using RockstarStatusCheck.Classes;
using RockstarStatusCheck.Tools;
using System;

namespace RockstarStatusCheck
{
    class Program
    {
        static void Main()
        {
            try
            {
                var statuses = StatusHandler.GetServiceStatuses();
                if (statuses.All(s => s.Status is Status.Up))
                {
                    ConsoleColors.WriteWithColor("All Rockstar Services Operational");
                }
                else
                {
                    foreach (var status in statuses)
                    {
                        ConsoleColors.WriteWithColor(status);
                    }
                }
                Console.WriteLine("Press Enter to exit...");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}