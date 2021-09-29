using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiveOClockSomewhere
{
    public interface ILocationFactory
    {
        public IList<Location> GetLocations();

        public void Add(Location l);

        public void Remove(Location l);

    }
}
