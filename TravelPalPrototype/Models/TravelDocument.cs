using TravelPalPrototype.Interfaces;

namespace TravelPalPrototype.Models
{
    public class TravelDocument : IPackingListItem
    {
        public string Name { get; set; }
        public bool IsRequired { get; set; }

        public TravelDocument(string name, bool isRequired)
        {
            Name = name;
            IsRequired = isRequired;
        }

        public string GetInfo()
        {
            return $"{Name}";
        }

        public string GetBooleanInfo(bool b)
        {
            return $"{Name} = {b}";
        }
    }
}