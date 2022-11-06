using System;
using TravelPalPrototype.Enums;

namespace TravelPalPrototype.Models
{
    public class Trip : Travel
    {
        public TripTypes Type { get; set; }

        public Trip(string destination,
                Countries country,
                int numberOfTravellers,
                TripTypes type,
                DateTime? startDate,
                DateTime? endDate)

                : base(destination,
                     country,
                     numberOfTravellers,
                     startDate,
                     endDate)
        {
            Destination = destination;
            Country = country;
            NumberOfTravellers = numberOfTravellers;
            Type = type;
            StartDate = startDate;
            EndDate = endDate;
        }

        public override string GetInfo()
        {
            return $"Destination: {Destination}| Type: {Type}  | Country: {Country} | Number Of Travellers: {NumberOfTravellers} StartDate: {StartDate} | EndDate: {EndDate} | Duration:{TravelDuration}";
        }
    }
}