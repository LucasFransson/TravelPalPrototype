using System;
using TravelPalPrototype.Enums;

namespace TravelPalPrototype.Models
{
    public class Vacation : Travel
    {
        public bool IsAllInClusive { get; set; }

        public Vacation(string destination,
                        Countries destinationCountry,
                        int numberOfTravellers,
                        bool isAllInclusive,
                        DateTime? startDate,
                        DateTime? endDate)

                        : base(destination,
                             destinationCountry,
                             numberOfTravellers,
                             startDate,
                             endDate)
        {
            Destination = destination;
            Country = destinationCountry;
            NumberOfTravellers = numberOfTravellers;
            IsAllInClusive = isAllInclusive;
            StartDate = startDate;
            EndDate = endDate;
        }

        public override string GetInfo()
        {
            return $"Destination: {Destination}| All Inclusive: {IsAllInClusive} |  Country: {Country} | Number Of Travellers: {NumberOfTravellers} StartDate: {StartDate} | EndDate: {EndDate} | Duration:{TravelDuration} ";
        }
    }
}