using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Processors10
{
    class Program
    {
        static void Main(string[] args)
        {
            var bp = new BusPath(10);
            var b = new Bus();
            var t = new Task(async () =>
            {
                b.Start(bp);
            });
            t.Start();
            t.Wait();
        }
    }
}
