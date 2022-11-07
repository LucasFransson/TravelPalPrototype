using System;
using System.Collections.Generic;
using System.Linq;
using TravelPalPrototype.Enums;
using TravelPalPrototype.Interfaces;
using TravelPalPrototype.Models;

namespace TravelPalPrototype.Managers
{
    public class TravelManager
    {
        public List<Travel> travels = new();
        public List<Trip> trips = new();
        public List<Vacation> vacations = new();

        public void AddTravel(Travel travel)
        {
            travels.Add(travel);
            if (travel is Vacation vacation)
            {
                vacations.Add(vacation);
            }
            else if (travel is Trip trip)
            {
                trips.Add(trip);
            }
        }

        public void CreateTrip(string destination, Countries country, int nrTravellers, TripTypes type, DateTime? startDate, DateTime? endDate)
        {
            Trip trip = new(destination, country, nrTravellers, type, startDate, endDate);

            //bool isPassportNeeded = CheckIfPassportIsNeeded(country);
            //if (isPassportNeeded)
            //{
            //    CreateRequiredPassportTravelDocument(trip);
            //}
            AddTravel(trip);

            User foundUser = (User)StaticMethods.SignedInUser;                     
            trip.BookedByUserID = foundUser.UserID;                             // Bindar resan med användarens GUID
            AddTravelIDToUser(foundUser, trip);                               // Bindar användaren med resans GUID + lägger till resan i listan
        }

        public void CreateVacation(string destination, Countries country, int nrTravellers, bool isAllInclusive, DateTime? startDate, DateTime? endDate)
        {
            Vacation vacation = new(destination, country, nrTravellers, isAllInclusive, startDate, endDate);
            AddTravel(vacation);

            User foundUser = (User)StaticMethods.SignedInUser;
            vacation.BookedByUserID = foundUser.UserID;                             // Bindar resan med användarens GUID
            AddTravelIDToUser(foundUser, vacation);                               // Bindar användaren med resans GUID + lägger till resan i listan
        }

        public static void AddTravelIDToUser(User user, Travel travel)
        {
            user.bookedTravelIDs.Add(travel.TravelID);
        }

        // Packinglist
        public void AddPackingListToTravel(Travel travel, List<IPackingListItem> packingList)
        {
            foreach(var packing in packingList)
            {
                travel.PackingList.Add(packing);
            }
        }

        public void AddItemToPackingList(Travel travel, IPackingListItem item)
        {
            travel.PackingList.Add(item);
        }

        public void CreateTravelDocument(Travel travel, string name, bool isRequired)
        {
            TravelDocument travelDocument = new(name, isRequired);
            AddItemToPackingList(travel, travelDocument);
        }

        public void CreateRequiredPassportTravelDocument(Travel travel)
        {
            CreateTravelDocument(travel, "Passport", true);
        }

        public TravelDocument CreateTravelDocumentForList(string name, bool isRequired)
        {
            TravelDocument travelDocument = new(name, isRequired);
            return travelDocument;
        }

        public void CreateOtherItem(string name, int quantity)
        {
            OtherItem otherItem = new(name, quantity);
        }

        // Remove Methods

        public void RemoveTravel(Travel travel)
        {
            travels.Remove(travel);

            if (travel is Vacation)
            {
                vacations.Remove((Vacation)travel);
            }
            else if (travel is Trip)
            {
                trips.Remove((Trip)travel);
            }
        }

        // Update Methods

        public void UpdateVacationByOverriding(Vacation vacation, string destination, Countries country, int nrTravellers, bool isAllInclusive, DateTime startDate, DateTime endDate)
        {
            RemoveTravel(vacation);
            CreateVacation(destination, country, nrTravellers, isAllInclusive, startDate, endDate);
        }

        public void UpdateTripByOverriding(Trip trip, string destination, Countries country, int nrTravellers, TripTypes type, DateTime startDate, DateTime endDate)
        {
            RemoveTravel(trip);
            CreateTrip(destination, country, nrTravellers, type, startDate, endDate);
        }

        public void UpdateVacationByChanging(Vacation vacation, string destination, Countries country, int nrTravellers, bool isAllInclusive, DateTime startDate, DateTime endDate)
        {
            vacation.Destination = destination;
            vacation.Country = country;
            vacation.NumberOfTravellers = nrTravellers;
            vacation.IsAllInClusive = isAllInclusive;
            vacation.StartDate = startDate;
            vacation.EndDate = endDate;
        }

        public void UpdateTripByChanging(Trip trip, string destination, Countries country, int nrTravellers, TripTypes type, DateTime startDate, DateTime endDate)
        {
            trip.Destination = destination;
            trip.Country = country;
            trip.NumberOfTravellers = nrTravellers;
            trip.Type = type;
            trip.StartDate = startDate;
            trip.EndDate = endDate;
        }

        public DateTime ParseStringToDateTime(String fullDate)
        {
            int year = int.Parse(fullDate.Substring(0, 4));
            int month = int.Parse(fullDate.Substring(4, 2));
            int day = int.Parse(fullDate.Substring(6, 2));
            DateTime dateTime = new(year, month, day);
            return dateTime;
        }

        public static Countries ParseStringCountryToEnum(string stringToParse)
        {
            return (Countries)Enum.Parse(typeof(Countries), stringToParse);
        }

        public TripTypes ParseStringTtypeToEnum(string stringToParse)
        {
            return (TripTypes)Enum.Parse(typeof(TripTypes), stringToParse);
        }

        public bool CheckIfPassportIsNeeded(Countries country)
        {
            var EUCountryList = Enum.GetNames(typeof(EUCountries)).ToList();
            if (!EUCountryList.Contains(country.ToString()))
            {
                return true;
            }
            return false;
        }
    }
}