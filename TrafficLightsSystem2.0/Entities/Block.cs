using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficLightsSystem2._0.Entities
{
    public class Block
    {
        public string Name { get; set; }        
        public List<Street> ParallelStreets { get; set; }
        public List<Street> PerpendicularStreets { get; set; }
        public Block()
        {
            ParallelStreets = new(); 
            PerpendicularStreets = new();
        }
    }
}
