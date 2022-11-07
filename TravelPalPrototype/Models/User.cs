using System.Collections.Generic;
using TravelPalPrototype.Enums;
using TravelPalPrototype.Interfaces;
using TravelPalPrototype.Managers;

namespace TravelPalPrototype.Models
{
    public class User : IUser
    {
        public List<int> bookedTravelIDs { get; set; } = new();
        public string Username { get; set; }
        public string Password { get; set; }
        public Countries Location { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int UserID { get; set; }
        public int availableSQAnswerAttempts { get; set; } = 3;

        public User(string firstName, string lastName, string username, string password, Countries location)
        {
            Username = username;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
            Location = location;

            SetUserID();
        }

        public void SetUserID()
        {
            UserID = StaticMethods.GenerateGUID(); ;
        }
    }
}
