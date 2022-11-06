using System;
using TravelPalPrototype.Enums;
using TravelPalPrototype.Interfaces;

namespace TravelPalPrototype.Models
{
    public class Admin : IUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int UserID { get; }
        public Countries Location { get; set; }

        public Admin(string username, string password)
        {
            this.Username = username;
            this.Password = password;
            this.UserID = GenerateUserID();
        }

        public int GenerateUserID()
        {
            return Guid.NewGuid().GetHashCode();
        }
    }
}