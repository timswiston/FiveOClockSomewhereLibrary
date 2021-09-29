using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiveOClockSomewhere
{

    public class Location
    {
        public string Name { get; set; }
        public decimal UTCOffset{ get; set; }

        public override bool Equals(object obj)
        {

            if (obj == null || !(obj is Location))
            {
                return false;
            }

            return (Name == ((Location)obj).Name)
                && (UTCOffset == ((Location)obj).UTCOffset);
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode() ^ UTCOffset.GetHashCode();
        }

        public override string ToString()
        {
            return Name + " " + UTCOffset.ToString();
        }

    }
}
