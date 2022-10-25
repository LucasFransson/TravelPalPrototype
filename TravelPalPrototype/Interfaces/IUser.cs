using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPalPrototype.Enums;

namespace TravelPalPrototype.Interfaces
{
    public interface IUser
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public Countries Location { get; set; }

        public IUser(string username,string password,Countries location) // Kunden vill ha en konstruktor till sitt interface, kontakta microsoft 
        {

        }

    }
}
