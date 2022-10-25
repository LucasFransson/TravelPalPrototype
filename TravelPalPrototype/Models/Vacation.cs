using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPalPrototype.Enums;
using TravelPalPrototype.Interfaces;

namespace TravelPalPrototype.Models
{
    public class Vacation : Travel
    {
        public Vacation(string destination, Countries country, int travellers, int travelDays, List<PackingListItem> packingList, DateTime startDate, DateTime endTime) : base(destination, country, travellers, travelDays, packingList, startDate, endTime)
        {
        }

        public TripTypes Type { get; } = TripTypes.Leisure;
        public bool IsAllInClusive { get; set; }

        public override void GetInfo()
        {

        }
    }
}
