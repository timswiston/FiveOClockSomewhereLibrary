using System;
using System.Collections.Generic;
using System.Diagnostics;
using NUnit.Framework;
using FiveOClockSomewhere;

namespace FiveOClockSomewhereTest
{
    class FiveOClockFinderTest
    {

        [Test]
        public void GetFiveOClockLocationTest()
        {
            FiveOClockFinder fiveO = new();

            //pass in 17:00 - expect the same UTC offset to come back
            //e.g. it's 5:00pm in London, then expect London
            DateTime d = new (2012, 12, 31, 17, 0, 0, 0);
            Assert.AreEqual(0, fiveO.GetFiveOClockLocation(d, 0).UTCOffset, "Pass in 17:00 - expect a UTC equal to what is passed in to be returned.");

            //pass in 16:00 - expect UTC offset +1 to come back (exception case is UTC 13)
            //e.g. it's 4:00pm in Chicago, it's 5:00pm in New York
            d = new (2012, 12, 31, 16, 0, 0, 0);
            Assert.AreEqual(-5, fiveO.GetFiveOClockLocation(d, -6).UTCOffset, "Pass in 16:00 - expect a UTC equal +1 to be returned.");

            //pass in 18:00 - expect UTC offset -1 to come back
            //e.g. it's 6:00pm in Chicago, it's 5:00pm in Denver (-7 UTC)
            d = new (2012, 12, 31, 18, 0, 0, 0);
            Assert.AreEqual(-7, fiveO.GetFiveOClockLocation(d, -6).UTCOffset, "Pass in 18:00 - expect a UTC equal -1 to be returned.");

            //minutes don't matter pass in 18:59.59.999 expect UTC offset -1 to come back
            d = new (2012, 12, 31, 18, 59, 59, 999);
            Assert.AreEqual(-7, fiveO.GetFiveOClockLocation(d, -6).UTCOffset, "Pass in 18:59 - expect a UTC equal -1 to be returned.");

            //minutes don't matter pass in 18:01:00.001 expect UTC offset -1 to come back
            d = new (2012, 12, 31, 18, 0, 0, 1);
            Assert.AreEqual(-7, fiveO.GetFiveOClockLocation(d, -6).UTCOffset, "Pass in 18:01 - expect a UTC equal -1 to be returned.");

        }

        [Test]
        public void FiveOClockAroundTheWorldTest()
        {
            FiveOClockFinder fiveO = new();

            //loop through each location at 4pm and ensure you can find a location that is five oclock
            //(UTC shoudl be +1 or -23 from where you are at)

            LocationFactoryHardCoded lfhc = new();
            DateTime d = new(2012, 12, 31, 16, 0, 0, 0); //4pm

            IList<Location> locations = lfhc.GetLocations();

            foreach (Location l in locations)
            {
                Location val = fiveO.GetFiveOClockLocation(d, l.UTCOffset);
                Debug.WriteLine(" At four o'clock in " + l.Name + " " + l.UTCOffset + " it is five in " + val.Name + " " + val.UTCOffset.ToString());
                Assert.IsTrue((val.UTCOffset == l.UTCOffset + 1) || (val.UTCOffset == l.UTCOffset - 23), $"UTCOffset not +1 or -23 for: {l.UTCOffset}");
            }

        }

        [Test]
        public void AroundTheClockTest()
        {
            FiveOClockFinder fiveO = new();

            //loop through the time - each timezone should be -1 from where you are at until you hit -12 then to +12
            
            DateTime d = new(2012, 12, 31, 17, 0, 0, 0); //5pm

            Location val;
            
            for(int i=0;i<24;i++)
            {
                val = fiveO.GetFiveOClockLocation(d, 0);  //use London UTC 0
                Debug.WriteLine("At " + d.Hour.ToString() + " 'clock in London it is five in " + val.Name + " " + val.UTCOffset.ToString());
                // time zone progress as we move through the clock is UTC offsets 0 to -11 then 12 to 1
                if (i < 12)
                {
                    Assert.AreEqual(i, val.UTCOffset * -1);
                }
                else if(i == 12) { Assert.AreEqual(12, val.UTCOffset); }
                else if (i == 13) { Assert.AreEqual(11, val.UTCOffset); }
                else if (i == 14) { Assert.AreEqual(10, val.UTCOffset); }
                else if (i == 15) { Assert.AreEqual(9, val.UTCOffset); }
                else if (i == 16) { Assert.AreEqual(8, val.UTCOffset); }
                else if (i == 17) { Assert.AreEqual(7, val.UTCOffset); }
                else if (i == 18) { Assert.AreEqual(6, val.UTCOffset); }
                else if (i == 19) { Assert.AreEqual(5, val.UTCOffset); }
                else if (i == 20) { Assert.AreEqual(4, val.UTCOffset); }
                else if (i == 21) { Assert.AreEqual(3, val.UTCOffset); }
                else if (i == 22) { Assert.AreEqual(2, val.UTCOffset); }
                else if (i == 23) { Assert.AreEqual(1, val.UTCOffset); }


                d = d.AddHours(1);
            }

        }

    }

}
