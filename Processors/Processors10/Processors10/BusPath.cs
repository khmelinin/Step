using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Processors10
{
    class BusPath
    {
        List<BusStation> busStations = new List<BusStation>();

        public BusPath(int count)
        {
            for (int i = 0; i < count; i++)
            {
                busStations.Add(new BusStation() { Title = i + 1 });
            }
        }

        public IEnumerable<BusStation> Stations => busStations;

        internal int GetLastStationTitle()
        {
            var s = busStations.LastOrDefault();
            return s == null ? 0 : s.Title;
        }
        internal void Start()
        {
            foreach (var item in busStations)
            {
                item.Start(this);
            }
        }
        internal void Stop()
        {
            foreach (var item in busStations)
            {
                item.Stop();
            }
        }
    }
}
