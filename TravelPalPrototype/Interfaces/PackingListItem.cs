using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelPalPrototype.Interfaces
{
    public interface PackingListItem // Kunden vill bryta mot alla konventionella namngivningsregler
    {
        public string Name { get; set; }
        public string GetInfo();
    }
}
