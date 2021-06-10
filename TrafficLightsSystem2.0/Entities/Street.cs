using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficLightsSystem2._0.Entities
{
    public class Street
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Status  { get; set; }
        public Street(string name, string type)
        {
            Name = name;
            Type = type;
            if (type == "parallel")
            {
               Status = "Green";
            }
            else
            {
               Status = "Red";
            }
        }
    }
}
