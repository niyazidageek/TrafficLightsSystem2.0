using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficLightsSystem2._0.Services
{
    public class MenuService
    {
        static LightsSystem method = new();
        public static void AddBlockMenu()
        {
            Console.WriteLine("Enter the name of the block");
            string blockname = Console.ReadLine();
            method.AddBlock(blockname);
        }
        public static void AddStreetMenu()
        {
            Console.WriteLine("Enter the name of the block");
            string blockname = Console.ReadLine();
            Console.WriteLine("Enter the name of the street");
            string name = Console.ReadLine();
            Console.WriteLine("Enter the type of the street(Parallel/Perpendicular)");
            string type = Console.ReadLine();
            method.AddStreet(blockname, name, type);
        }
        public static void RemoveBlockMenu()
        {
            Console.WriteLine("Enter the name of the block");
            string blockname = Console.ReadLine();
            method.RemoveBlock(blockname);
        }
        public static void RemoveStreetMenu()
        {
            Console.WriteLine("Enter the name of the block");
            string blockname = Console.ReadLine();
            Console.WriteLine("Enter the name of the street");
            string name = Console.ReadLine();
            method.RemoveStreet(blockname, name);
        }
        public static void StartSystemMenu()
        {
            method.StartSystem();
        }
        public static void StopLightsByStreetMenu()
        {
            Console.WriteLine("Enter the name of the block");
            string blockname = Console.ReadLine();
            Console.WriteLine("Enter the name of the street");
            string name = Console.ReadLine();
            method.StopLightsByStreet(blockname, name);
        }
        public static void StartLightByStreetMenu()
        {
            Console.WriteLine("Enter the name of the block");
            string blockname = Console.ReadLine();
            Console.WriteLine("Enter the name of the street");
            string name = Console.ReadLine();
            method.StartLightByStreet(blockname, name);
        }
    }    
}
