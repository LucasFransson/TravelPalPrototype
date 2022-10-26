using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPalPrototype.Enums;
using TravelPalPrototype.Interfaces;

namespace TravelPalPrototype.Models
{
    public class Customer : IUser
    {
        public List<int> bookedTravelIDs { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Countries Location { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int UserID { get; }

        public Customer(string firstName, string lastName, string username, string password, Countries location)
        {
            this.Username = username;
            this.Password = password;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Location = location;
            UserID = GenerateUserID();
        }
        public int GenerateUserID()
        {
            return Guid.NewGuid().GetHashCode();
        }
    }
}

