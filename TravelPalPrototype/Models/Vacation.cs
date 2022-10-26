using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPalPrototype.Enums;
using TravelPalPrototype.Interfaces;

namespace TravelPalPrototype.Models
{
    public class Vacation : Travel
    {
        public Vacation(string destination, 
                        Countries destinationCountry,
                        Countries departureCountry,
                        int numberOfTravellers,
                        DateTime startDate,
                        DateTime endDate)
            
                        :base(destination,
                             destinationCountry,
                             departureCountry,
                             numberOfTravellers,
                             startDate,
                             endDate)
        {

        }
        public TripTypes Type { get; } = TripTypes.Vacation;
        public bool IsAllInClusive { get; set; }

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
