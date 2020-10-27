using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Processors10
{
    public class Bus
    {
        private List<Person> passengers = new List<Person>();
        private object objPass = new object();
        private BusPath busPath;
        public Semaphore Places { get; private set; }
        public ManualResetEvent StationIn { get; internal set; }
        public ManualResetEvent StationOut { get; internal set; }
        public int CurrentStation { get; internal set; }
        internal void Start(BusPath path)
        {
            busPath = path;
            Places = new Semaphore(30, 30);
            StationIn = new ManualResetEvent(false);
            StationOut = new ManualResetEvent(false);
            var t = new Task(Run);
            t.Start();
            t.Wait();
        }
        internal void RemovePassenger(Person person)
        {
            lock (objPass)
            {
                passengers.Remove(person);
            }
        }

        internal void AddPassenger(Person person)
        {
            lock (objPass)
            {
                passengers.Add(person);
            }
        }
        private void Run()
        {
            busPath.Start();
            var t = Task.Delay(190); // wait for passengers
            t.Wait();

            foreach (var s in busPath.Stations)
            {
                var wt = (from p in passengers select p.CheckStationComplite).ToArray();
                CurrentStation = s.Title;
                StationIn.Set();
                Console.WriteLine($"Station in {s.Title}");
                Console.WriteLine($"Amount of passengers {passengers.Count}");
                StationOut.Reset();
                if (wt.Length != 0)
                {
                    WaitHandle.WaitAll(wt);
                }
                StationIn.Reset();
                s.In(this);
                Console.WriteLine($"Station in {s.Title}");
                Console.WriteLine($"Amount of passengers {passengers.Count}");
                StationOut.Set();
                t = Task.Delay(100);
                t.Wait();
            }
            busPath.Stop();
        }
    }
}