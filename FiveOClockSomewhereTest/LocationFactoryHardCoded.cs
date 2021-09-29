using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiveOClockSomewhere
{
    public class LocationFactoryHardCoded : ILocationFactory
    {

        private readonly IList<Location> locations;

        public LocationFactoryHardCoded()
        {
            locations = new List<Location>() { new Location { Name = "Wausau", UTCOffset = -6 } };
            locations.Add(new Location() { Name = "Plover", UTCOffset = -6 });
            locations.Add(new Location() { Name = "Denver", UTCOffset = -7 });
            locations.Add(new Location() { Name = "Vancover", UTCOffset = -8 });
            locations.Add(new Location() { Name = "Chicago", UTCOffset = -6 });
            locations.Add(new Location() { Name = "Dallas", UTCOffset = -6 });
            locations.Add(new Location() { Name = "Toronto", UTCOffset = -5 });
            locations.Add(new Location() { Name = "New York", UTCOffset = -5 });
            locations.Add(new Location() { Name = "Bermuda", UTCOffset = -4 });
            locations.Add(new Location() { Name = "Antigua", UTCOffset = -4 });
            locations.Add(new Location() { Name = "Nuuk Greenland", UTCOffset = -3 });
            locations.Add(new Location() { Name = "South Sandwich Islands", UTCOffset = -2 });
            locations.Add(new Location() { Name = "Cabo Verde", UTCOffset = -1 });
            locations.Add(new Location() { Name = "London", UTCOffset = 0 });
            locations.Add(new Location() { Name = "Paris", UTCOffset = 1 });
            locations.Add(new Location() { Name = "Rome", UTCOffset = 1 });
            locations.Add(new Location() { Name = "Algiers", UTCOffset = 1 });
            locations.Add(new Location() { Name = "Warsaw", UTCOffset = 1 });
            locations.Add(new Location() { Name = "Helsinki", UTCOffset = 2 });
            locations.Add(new Location() { Name = "Moscow", UTCOffset = 3 });
            locations.Add(new Location() { Name = "Seychelles", UTCOffset = 4 });
            locations.Add(new Location() { Name = "Pakistan", UTCOffset = 5 });
            locations.Add(new Location() { Name = "Kazikhstan", UTCOffset = 6 });
            locations.Add(new Location() { Name = "Novosibirsk", UTCOffset = 7 });
            locations.Add(new Location() { Name = "Beijing", UTCOffset = 8 });
            locations.Add(new Location() { Name = "Perth", UTCOffset = 8 });
            locations.Add(new Location() { Name = "Tokyo", UTCOffset = 9 });
            locations.Add(new Location() { Name = "Vladivostok", UTCOffset = 10 });
            locations.Add(new Location() { Name = "Vanuatu", UTCOffset = 11 });
            locations.Add(new Location() { Name = "Fiji", UTCOffset = 12 });
            locations.Add(new Location() { Name = "Howland Island", UTCOffset = -12 });
            locations.Add(new Location() { Name = "Midway Islands", UTCOffset = -11 });
            locations.Add(new Location() { Name = "Anchorage", UTCOffset = -9 });
            locations.Add(new Location() { Name = "Honolulu", UTCOffset = -10 });
        }


        public IList<Location> GetLocations()
        {
            return locations;
        }

        public void Add(Location l)
        {
            if (locations.Contains(l))
            {
                throw new ArgumentException("Attempt to add duplicate location: " + l.ToString());
            }
            locations.Add(l);
        }

        public void Remove(Location l)
        {
            locations.Remove(l);
        }

    }
}
