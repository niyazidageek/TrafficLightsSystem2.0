using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficLightsSystem2._0.Entities;
using TrafficLightsSystem2._0.Entities.Common;

namespace TrafficLightsSystem2._0.Services
{
    public class LightsSystem : Block
    {      
        public List<Block> Blocks { get; set; }
        public LightsSystem()
        {
            Blocks = new();
        }
        public void AddBlock(string blockname)
        {
            Block block = new();
            block.Name = blockname;
            Blocks.Add(block);
        }
        public static int check = 0;
        public void AddStreet(string blockname, string name, string type)
        {
            var block = Blocks.Find(s => s.Name == blockname);
            Street street = new(name, type);
            if (type == "parallel")
            {
                block.ParallelStreets.Add(street);
            }
            else
            {
                block.PerpendicularStreets.Add(street);
            }
        }
        public void RemoveBlock(string blockname)
        {
            var block = Blocks.Find(s=>s.Name == blockname);
            block.ParallelStreets.Clear();
            block.PerpendicularStreets.Clear();
            Blocks.Remove(block);
        }
        public void RemoveStreet(string blockname, string name)
        {
            var block = Blocks.Find(s => s.Name == blockname);
            if (block == null)
                throw new ArgumentNullException("There is no such block.");
            var parallelresult = block.ParallelStreets.FindIndex(s => s.Name == name);
            var perpendicularresult = block.PerpendicularStreets.FindIndex(s => s.Name == name);
            if (parallelresult == -1 && perpendicularresult == -1)
                throw new KeyNotFoundException("There is no such street.");
            if (parallelresult == -1)
            {
                block.PerpendicularStreets.RemoveAt(perpendicularresult);
            }
            else
            {
                block.ParallelStreets.RemoveAt(parallelresult);
            }
        }
        public void Lights()
        {
            Timer time = new();
            while (check != 1)
            {
                if (check == 1)
                    throw new KeyNotFoundException("System has stopped.");
                time.Time = DateTime.Now;
                time.FutureTime = time.Time.AddSeconds(10);
                foreach (var item in ParallelStreets )
                {
                    if (item.Status != "Disabled")
                    {
                        item.Status = "Red";
                    }
                    Console.WriteLine($"{item.Name}, {item.Status}, {item.Type.First().ToString().ToUpper() + item.Type.Substring(1)}");
                }

                foreach (var item in PerpendicularStreets)
                {
                    if (item.Status != "Disabled")
                    {
                        item.Status = "Green";
                    }
                    Console.WriteLine($"{item.Name}, {item.Status}, {item.Type.First().ToString().ToUpper() + item.Type.Substring(1)}");
                }
                Console.WriteLine("============================");

                while (time.Time.Second != time.FutureTime.Second)
                {
                    if (check == 1)
                        throw new KeyNotFoundException("System has stopped.");
                    time.Time = DateTime.Now;
                }

                foreach (var item in ParallelStreets)
                {
                    if (item.Status != "Disabled")
                    {
                        item.Status = "Green";
                    }
                    Console.WriteLine($"{item.Name}, {item.Status}, {item.Type.First().ToString().ToUpper() + item.Type.Substring(1)}");
                }

                foreach (var item in PerpendicularStreets)
                {
                    if (item.Status != "Disabled")
                    {
                        item.Status = "Red";
                    }
                    Console.WriteLine($"{item.Name}, {item.Status}, {item.Type.First().ToString().ToUpper() + item.Type.Substring(1)}");
                }

                time.FutureTime = time.Time.AddSeconds(10);
                while (time.Time.Second != time.FutureTime.Second)
                {
                    if (check == 1)
                        throw new KeyNotFoundException("System has stopped.");
                    time.Time = DateTime.Now;
                }
                Console.WriteLine("=============================");
            }
        }
        public void StopLightsByStreet(string blockname, string name)
        {
            var block = Blocks.Find(s => s.Name == blockname);
            var parallelresult = block.ParallelStreets.FindIndex(s => s.Name == name);
            var perpendicularresult = block.PerpendicularStreets.FindIndex(s => s.Name == name);
            if (parallelresult == -1 && perpendicularresult == -1)
                throw new KeyNotFoundException("There is no such street");
            if (parallelresult == -1)
            {
                var street = block.PerpendicularStreets[perpendicularresult];
                street.Status = "Disabled";
            }
            else
            {
                var street = block.ParallelStreets[parallelresult];
                street.Status = "Disabled";
            }
        }
        public void StartLightByStreet(string blockname, string name)
        {
            var block = Blocks.Find(s => s.Name == blockname);
            var parallelresult = block.ParallelStreets.FindIndex(s => s.Name == name);
            var perpendicularresult = block.PerpendicularStreets.FindIndex(s => s.Name == name);
            if (parallelresult == -1 && perpendicularresult == -1)
                throw new KeyNotFoundException("There is no such street");
            if (parallelresult == -1)
            {
                var street = block.PerpendicularStreets[perpendicularresult];
                street.Status = string.Empty;
            }
            else
            {
                var street = block.ParallelStreets[parallelresult];
                street.Status = string.Empty;
            }
        }
        public void HiddenMenu()
        {
            int option = 0;
            do
            {
                Console.WriteLine("1. Add block");
                Console.WriteLine("2. Add street");
                Console.WriteLine("3. Remove block");
                Console.WriteLine("4. Remove street");
                Console.WriteLine("5. Stop the lights by street");
                Console.WriteLine("6. Start the lights by street");
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
                        MenuService.StopLightsByStreetMenu();
                        break;
                    case 6:
                        MenuService.StartLightByStreetMenu();
                        break;
                    case 0:
                        Console.WriteLine("Shutting down...");
                        break;
                    default:
                        Console.WriteLine("There is no such option");
                        break;
                }
            } while (option != 0);
        }
        public void StartSystem()
        {
            Parallel.Invoke(HiddenMenu, Lights);
        }
    }
}
