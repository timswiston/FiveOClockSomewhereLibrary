using System;
using System.Linq;
using NUnit.Framework;
using FiveOClockSomewhere;

namespace FiveOClockSomewhereTest
{
    class LocationTest
    {
        [Test]
        public void EqualsTest()
        {
            Location l = new() { Name = "Chicago", UTCOffset = -6 };
            //null obj is false
            Assert.IsFalse(l.Equals(null));
            //nonobj type is false
            Assert.IsFalse(l.Equals(new DateTime()));

            //test for finding equality based on name and utcoffset
            Location l2 = new() { Name = "Chicago", UTCOffset = -6 };
            Assert.IsTrue(l.Equals(l2));

            //test for not finding equality based on name
            l2.Name = "Milwaukee";
            Assert.IsFalse(l.Equals(l2));

            //test for not finding equality based on utcoffset
            l2.Name = l.Name;
            l2.UTCOffset = 0;
            Assert.IsFalse(l.Equals(l2));
        }

        [Test]
        public void ToStringTest() 
        {
            Location l = new() { Name = "Chicago", UTCOffset = -6 };
            Assert.AreEqual("Chicago -6", l.ToString());
        }

        [Test]
        public void GetHashCodeTest()
        {
            Location l = new() { Name = "Chicago", UTCOffset = -6 };
            Location l2 = new() { Name = "Chicago", UTCOffset = -6 };
            Assert.AreEqual(l.GetHashCode(), l2.GetHashCode());

            l2.Name = "Springfield";
            Assert.AreNotEqual(l.GetHashCode(), l2.GetHashCode());

            l2.Name = l.Name;
            l2.UTCOffset = 0;
            Assert.AreNotEqual(l.GetHashCode(), l2.GetHashCode());
        }
    }
}
