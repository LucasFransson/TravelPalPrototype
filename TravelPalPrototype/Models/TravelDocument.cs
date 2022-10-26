using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPalPrototype.Interfaces;

namespace TravelPalPrototype.Models
{
    public class TravelDocument : IPackingListItem
    {
        public string Name { get; set; }
        public bool IsRequired { get; set; }
        public TravelDocument(string name, bool isRequired)
        {
            Name = name;
            this.IsRequired = isRequired;
        }
        public string GetInfo()
        {
            return $"{Name}";
        }
    }
}
