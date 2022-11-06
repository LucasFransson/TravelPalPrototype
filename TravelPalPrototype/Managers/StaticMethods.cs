using System;

namespace TravelPalPrototype.Managers
{
    public class StaticMethods
    {
        public static int GenerateGUID()
        {
            return Guid.NewGuid().GetHashCode();
        }
    }
}