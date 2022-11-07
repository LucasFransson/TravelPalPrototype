using System;
using System.Collections.Generic;
using TravelPalPrototype.Enums;
using TravelPalPrototype.Interfaces;
using TravelPalPrototype.Managers;

namespace TravelPalPrototype.Models
{
    public class Travel
    {
        public List<IPackingListItem> PackingList { get; set; } = new();

        public string Destination { get; set; }
        public Countries Country { get; set; }
        public int NumberOfTravellers { get; set; }
        public int TravelDuration { get; set; }
        public int BookedByUserID { get; set; }  
        public int TravelID { get; set; }   
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    

        public Travel(string destination, Countries country, int numberOfTravelleres, DateTime? startDate, DateTime? endDate)
        {
            Destination = destination;
            Country = country;
            NumberOfTravellers = numberOfTravelleres;
            StartDate = startDate;
            EndDate = endDate;

            SetTravelID();
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
        public void SetTravelID()
        {
            TravelID = StaticMethods.GenerateGUID();
        }
    }
}