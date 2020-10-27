using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Processors10
{
    class BusStation
    {
        private List<Person> persons = new List<Person>();
        private object objPersons = new object();
        private bool bExit = false;
        private object objExit = new object();
        private BusPath busPath;
        public int Title { get; set; }
        public void Start(BusPath path)
        {
            busPath = path;
            var t = new Task(this.Run);
            t.Start();
        }
        public void Stop()
        {
            lock (objExit)
            {
                bExit = true;
            }
        }
        public void In(Bus bus)
        {
            var passengers = new List<Person>();
            lock (objPersons)
            {
                foreach (var p in persons)
                {
                    bool s = p.In(bus);
                    if (s)
                    {
                        passengers.Add(p);
                    }
                }
            }
            foreach (var p in passengers)
            {
                lock (objPersons)
                {
                    persons.Remove(p);
                }
            }
        }
        private async void Run()
        {
            Random rnd = new Random();
            while (true)
            {
                var w = rnd.Next(1, 10);
                await Task.Delay(w * 10); // passenger delay
                if (Title != busPath.GetLastStationTitle())
                {
                    var bs = rnd.Next(Title + 1, busPath.GetLastStationTitle());
                    var h = new Person(bs);
                    lock (objPersons)
                    {
                        persons.Add(h);
                    }
                }
                //h.Start();
                lock (objExit)
                {
                    if (bExit)
                    {
                        break;
                    }
                }
            }
        }

    }
}
