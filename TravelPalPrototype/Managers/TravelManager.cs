using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPalPrototype.Interfaces;
using TravelPalPrototype.Models;

namespace TravelPalPrototype.Managers
{
    public class TravelManager
    {
        public List<Travel> travels = new();

        public void AddTravel(Travel travel)
        {
            travels.Add(travel);
        }
        public void RemoveTravel(Travel travel)
        {
            travels.Remove(travel);
        }
        // Booking Methods
        public virtual void ConfirmBooking(string password)
        {

        }
        public void LinkBookingWithUser()
        {

        }
        public virtual void BookTravel(IUser user)
        {

        }
        public virtual void RemoveTravel()
        {

        }
        public string GetTravelPoints(int travelID)
        {
            return $"Departure: {GetDeparture(travelID)} | Destination: {GetDestination(travelID)}";
        }

        public string GetDeparture(int travelID)
        {
            return "";
        }
        public string GetDestination(int travelID)
        {
            return "";
        }
    }
}
