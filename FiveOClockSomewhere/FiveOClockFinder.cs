using System;
using System.Collections.Generic;
using System.Linq;

namespace FiveOClockSomewhere
{
    public class FiveOClockFinder
    {

        public IList<Location> Locations { get; }
        public ILocationFactory LocationFactory { get; set; }

        public FiveOClockFinder()
        {

            LocationFactory = new LocationFactoryHardCoded();
            Locations = LocationFactory.GetLocations();
        }


        public Location GetFiveOClockLocation(DateTime currentTime, decimal currentUTCOffset)
        {

            //get UTC shift
            //if it's 4 o'clock in the midwest UTC -6 then its 5 o'clock in the east UTC -5
            //currently assuming we are talking about UTC -6

            int currentHour = currentTime.Hour;

            //how many hours until 5pm
            int hoursToFive;

            if (currentHour <= 17)
            {
                hoursToFive = 17 - currentHour;
            } else
            {
                //if it's 18 it is 23 hours to 5, 19, 22 hours
                hoursToFive = 24 - (currentHour - 17);
            }

            
            //what time zone to look for
            decimal tzToFind = currentUTCOffset + hoursToFive;

            //since tz's are defined as -12 to +12 from UTC if the value we are looking for is >12 or <-12 then adjust - wrap around
            if (tzToFind > 12) { tzToFind -= 24; }
            else if (tzToFind < -12) { tzToFind += 24; }

            return Locations.Where(item => item.UTCOffset == tzToFind).First();

        }

    }
}
