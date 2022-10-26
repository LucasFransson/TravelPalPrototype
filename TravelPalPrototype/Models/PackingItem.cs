using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPalPrototype.Interfaces;

namespace TravelPalPrototype.Models
{
    public class PackingItem : IPackingListItem
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public PackingItem(string name, int quantity)
        {
            Name = name;
            Quantity = quantity;
        }
        public string GetInfo()
        {
            return Name;
        }
    }
}
