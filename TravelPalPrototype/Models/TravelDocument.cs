using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPalPrototype.Interfaces;

namespace TravelPalPrototype.Models
{
    public class TravelDocument : PackingListItem
    {
        public string Name { get; set; }
        public bool Required { get; set; }
        public TravelDocument(string name, bool required)
        {
            Name = name;
            this.Required = required;
        }
        public string GetInfo()
        {
            return $"{Name}";
        }
    }
}
