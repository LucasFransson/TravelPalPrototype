using TravelPalPrototype.Enums;

namespace TravelPalPrototype.Interfaces
{
    public interface IUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public string Username { get; set; }
        public string Password { get; set; }
        public int UserID { get; }
        public Countries Location { get; }
    }
}