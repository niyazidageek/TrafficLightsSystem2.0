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
            string blockname = Console.ReadLine().ToLower();
            Console.WriteLine("Insert the start interval");
            int startinterval = int.Parse(Console.ReadLine());
            Console.WriteLine("Insert the stop interval");
            int stopinterval = int.Parse(Console.ReadLine());
            try
            {
                method.AddBlock(blockname, startinterval, stopinterval);
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong!");
                Console.WriteLine(e.Message);
            }           
        }
        public static void AddStreetMenu()
        {
            Console.WriteLine("Enter the name of the block");
            string blockname = Console.ReadLine().ToLower();
            Console.WriteLine("Enter the name of the street");
            string name = Console.ReadLine().ToLower();
            Console.WriteLine("Enter the type of the street(Parallel/Perpendicular)");
            string type = Console.ReadLine().ToLower();
            try
            {
                method.AddStreet(blockname, name, type);
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong!");
                Console.WriteLine(e.Message);
            }            
        }
        public static void RemoveBlockMenu()
        {
            Console.WriteLine("Enter the name of the block");
            string blockname = Console.ReadLine().ToLower();
            try
            {
                method.RemoveBlock(blockname);
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong!");
                Console.WriteLine(e.Message);
            }           
        }
        public static void RemoveStreetMenu()
        {
            Console.WriteLine("Enter the name of the block");
            string blockname = Console.ReadLine().ToLower();
            Console.WriteLine("Enter the name of the street");
            string name = Console.ReadLine().ToLower();
            try
            {
                method.RemoveStreet(blockname, name);
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong!");
                Console.WriteLine(e.Message);
            }            
        }
        public static void StartSystemMenu()
        {
            try
            {
                method.StartSystem();
            }
            catch (Exception e)
            {  
                Console.WriteLine(e.Message);
            }            
        }
        public static void StopLightsByStreetMenu()
        {
            Console.WriteLine("Enter the name of the block");
            string blockname = Console.ReadLine().ToLower();
            Console.WriteLine("Enter the name of the street");
            string name = Console.ReadLine().ToLower();
            try
            {
                method.StopLightsByStreet(blockname, name);
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong!");
                Console.WriteLine(e.Message);
            }           
        }
        public static void StartLightByStreetMenu()
        {
            Console.WriteLine("Enter the name of the block");
            string blockname = Console.ReadLine().ToLower();
            Console.WriteLine("Enter the name of the street");
            string name = Console.ReadLine().ToLower();
            try
            {
                method.StartLightByStreet(blockname, name);
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong!");
                Console.WriteLine(e.Message);
            }           
        }
        public static void StopLightByBlockMenu()
        {
            Console.WriteLine("Enter the name of the block");
            string blockname = Console.ReadLine().ToLower();
            try
            {
                method.StopLightByBlock(blockname);
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong!");
                Console.WriteLine(e.Message);
            } 
        }
        public static void StartLightByBlockMenu()
        {
            Console.WriteLine("Enter the name of the block");
            string blockname = Console.ReadLine().ToLower();
            try
            {
                method.StartLightByBlock(blockname);
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong!");
                Console.WriteLine(e.Message);
            }        
        }
    }    
}
