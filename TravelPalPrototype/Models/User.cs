using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPalPrototype.Enums;
using TravelPalPrototype.Interfaces;

namespace TravelPalPrototype.Models
{
    public class User : IUser
    {
        public string Username { get ; set; }
        public string Password { get; set; }
        public Countries Location { get; set; }
    }
}
