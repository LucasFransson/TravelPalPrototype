using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPalPrototype.Enums;
using TravelPalPrototype.Interfaces;

namespace TravelPalPrototype.Models
{
    public abstract class Travel // Får jag ens göra den här till en abstract klass?
    {
        public string Destination { get; set; } 
        public Countries Country { get; set; } 
        public int Travellers { get; set; }
        public int TravelDays { get; set; }
        public List<PackingListItem> PackingList { get; set; } 

        public DateTime StartDate { get; set; }

        public DateTime EndTime { get; set; }

    

        public Travel(string destination, Countries country, int travellers,int travelDays,List<PackingListItem> packingList,DateTime startDate,DateTime endTime) // Måste jag ha en konstruktor då det inte ska skapas några instancer av klassen?
        {
            Destination = destination;
            Country = country;
            Travellers = travellers;
            TravelDays = travelDays;
            PackingList = packingList;
            StartDate = startDate;
            EndTime = endTime;
        }
        public abstract string GetInfo();
  
    }
}
