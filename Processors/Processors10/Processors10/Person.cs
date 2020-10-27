using System;
using System.Threading;
using System.Threading.Tasks;

namespace Processors10
{
    internal class Person
    {
        private int lastStation;
        private Bus bus;
        public Person(int bs)
        {
            lastStation = bs;
            CheckStationComplite = new AutoResetEvent(false);
        }

        internal AutoResetEvent CheckStationComplite { get; set; }

        internal void Start()
        {
            bool running = true;
            while (running)
            {
                bus.StationIn.WaitOne();
                running = lastStation != bus.CurrentStation;
                if (running == false)
                {
                    bus.RemovePassenger(this);
                }
                CheckStationComplite.Set();
                if (running)
                {
                    bus.StationOut.WaitOne();
                }
            }
        }

        internal bool In(Bus b)
        {
            var res = false;
            if (b.Places.WaitOne(0))
            {
                bus = b;
                bus.AddPassenger(this);
                new Task(Start).Start();
                res = true;
            }
            return res;
        }
    }
}