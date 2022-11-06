using System;
using System.Collections.Generic;
using TravelPalPrototype.Enums;
using TravelPalPrototype.Interfaces;

namespace TravelPalPrototype.Models
{
    public class Travel
    {
        public List<IPackingListItem> PackingList { get; set; }

        public string Destination { get; set; }
        public Countries Country { get; set; }
        public int NumberOfTravellers { get; set; }
        public int TravelDuration { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public Travel(string destination, Countries country, int numberOfTravelleres, DateTime? startDate, DateTime? endDate)
        {
            Destination = destination;
            Country = country;
            NumberOfTravellers = numberOfTravelleres;
            StartDate = startDate;
            EndDate = endDate;
        }

        public virtual string GetDisplayInfo()
        {
            return "";
        }

        public virtual string GetInfo()
        {
            return "";
        }

        public int GetTravelDuration()
        {
            return 0;
        }
    }
}