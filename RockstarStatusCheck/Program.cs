using RockstarStatusCheck.Controllers;
using RockstarStatusCheck.Enums;
using RockstarStatusCheck.Handlers;
using System;

namespace RockstarStatusCheck
{
    class Program
    {
        static void Main()
        {
            try
            {
                RockstarServices.RunChecks();
            }
            catch (Exception ex)
            {
                ConsoleHandler.WriteWithColor(ex.Message, ConsoleColor.Red, LogLevel.Error);
            }
        }
    }
}