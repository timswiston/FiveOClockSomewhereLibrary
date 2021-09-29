using System;
using System.Linq;
using NUnit.Framework;
using FiveOClockSomewhere;

namespace FiveOClockSomewhereTest
{
    public class LocationFactoryHardCodedTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ConstructorTest()
        {
            LocationFactoryHardCoded lfhc = new();

            Assert.AreEqual(34, lfhc.GetLocations().Count, "Location count in hard coded test list does not match expectations.");

        }

        [Test]
        public void CompleteSetTest() 
        {
            //Test that the hard coded list of values has at least one value for -12 to 12 UTC offset which is needed for other unit tests
            LocationFactoryHardCoded lfhc = new();

            for (int i = -12; i <=12; i++) 
            {
                Assert.IsNotEmpty(lfhc.GetLocations().Where(x => x.UTCOffset == i), $"Missing UTCOffset: {i}");
            }

        }


        [Test]
        public void UTCValueTest()
        {
            //Currently logic only supports UTC's of even numbers (no halves like Tehran and no -13 like Tonga)
            //locations.Add(new Location() { Name = "Tehran", UTCOffset = 3.5m });

            LocationFactoryHardCoded lfhc = new();

            Assert.IsEmpty(lfhc.GetLocations().Where(x => x.UTCOffset % 1 != 0), "Should have empty list of items that are fractional time zones.");

            Assert.IsEmpty(lfhc.GetLocations().Where(x => x.UTCOffset > 12), "Should have empty list of items that are > 12 UTC Offset.");

            Assert.IsEmpty(lfhc.GetLocations().Where(x => x.UTCOffset < -12), "Should have empty list of items that are < -12 UTC Offset.");

        }

        [Test]
        public void AddTest()
        {
            LocationFactoryHardCoded lfhc = new();
            Assert.IsEmpty(lfhc.GetLocations().Where(x => x.Name == "Seattle"));
            Location l = new() { Name = "Seattle", UTCOffset = -8 };
            lfhc.Add(l);
            Assert.IsNotEmpty(lfhc.GetLocations().Where(x => x.Name == "Seattle"));

            //add throws exception if you try to add a duplicate
            Assert.Throws<ArgumentException>(()=>lfhc.Add(l));
        }

        [Test]
        public void RemoveTest()
        {
            LocationFactoryHardCoded lfhc = new();
            Assert.IsNotEmpty(lfhc.GetLocations().Where(x => x.Name == "Plover"));
            lfhc.Remove(lfhc.GetLocations().Where(x => x.Name=="Plover").First());
            Assert.IsEmpty(lfhc.GetLocations().Where(x => x.Name == "Plover"));

            //remove a location that doesn't exist just to show nothing bad happens
            lfhc.Remove(new Location() { Name = "Seattle", UTCOffset = -8 });
        }

    }
}