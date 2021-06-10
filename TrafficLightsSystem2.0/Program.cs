using System;
using TrafficLightsSystem2._0.Services;

namespace TrafficLightsSystem2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            int option = 0;
            do
            {
                Console.WriteLine("1. Add block");
                Console.WriteLine("2. Add street");
                Console.WriteLine("3. Remove block");
                Console.WriteLine("4. Remove street");
                Console.WriteLine("5. Start the system");
                Console.WriteLine("6. Stop the lights by street");
                Console.WriteLine("7. Start the lights by street");
                Console.WriteLine("0. Exit");
                Console.WriteLine("Enter a selection, please");
                string optionstr = Console.ReadLine();
                while (!int.TryParse(optionstr, out option))
                {
                    Console.WriteLine("Enter a number, please!");
                    optionstr = Console.ReadLine();
                }
                switch (option)
                {
                    case 1:
                        MenuService.AddBlockMenu();
                        break;
                    case 2:
                        MenuService.AddStreetMenu();
                        break;
                    case 3:
                        MenuService.RemoveBlockMenu();
                        break;
                    case 4:
                        MenuService.RemoveStreetMenu();
                        break;
                    case 5:
                        MenuService.StartSystemMenu();
                        break;
                    case 6:
                        MenuService.StopLightsByStreetMenu();
                        break;
                    case 7:
                        MenuService.StartLightByStreetMenu();
                        break;
                    case 0:
                        Console.WriteLine("Shutting down...");
                        break;
                    default:
                        Console.WriteLine("There is no such option");
                        break;
                }
            } while (option!=0);
        }
    }
}
