using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPalPrototype.Enums;
using TravelPalPrototype.Interfaces;

namespace TravelPalPrototype.Models
{
    public  class Travel 
    {
        public List<IPackingListItem> PackingList { get; set; }

        public string Destination { get; set; }
        public Countries DestinationCountry { get; set; } 
        public Countries DepartureCountry { get; set; } 
        public int NumberOfTravellers { get; set; }
        public int TravelDuration { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public Travel(string destination, Countries destinationCountry, Countries departureCountry, int numberOfTravelleres,DateTime startDate, DateTime endDate)
        {
            Destination = destination;
            DestinationCountry = destinationCountry;
            DepartureCountry = departureCountry;
            NumberOfTravellers = numberOfTravelleres;
            StartDate = startDate;
            EndDate = endDate;
        }
        public string GetInfo()
        {
            return "";
        }
        public int GetTravelDuration()
        {
            return 0;
        }
  
    }
}
