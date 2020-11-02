using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Processors12
{
    class Car
    {
        public Engine Engine { get; set; }
        public GearBox Gearbox { get; set; }
        public FuelTank Fueltank { get; set; }
        public CancellationTokenSource StopStart;
        public CancellationTokenSource StopGas;

        public Car(Engine engine, GearBox gearbox, FuelTank fueltank)
        {
            this.Engine = engine;
            this.Gearbox = gearbox;
            this.Fueltank = fueltank;
            StopStart = new CancellationTokenSource();
            StopGas = new CancellationTokenSource();
        }
        public void StartEngine()
        {
            Engine.Revs = 1000;
            Gearbox.CurrentGear = 0;
            while (true)
            {
                if(StopStart.Token.IsCancellationRequested)
                {
                    break;
                }
                if (Fueltank.Volume < 0)
                {
                    break;
                }
                Thread.Sleep(1000);
                Fueltank.Volume -= Engine.Revs * Engine.Capacity / 30000;
            }
        }
        public void Gas()
        {
            while (true)
            {
                if(StopGas.Token.IsCancellationRequested)
                {
                    break;
                }
                if (Fueltank.Volume < 0)
                {
                    break;
                }
                Thread.Sleep(1000);
                if (Engine.Revs > Engine.MaxRevs)
                {
                    break;
                }
                else
                {
                    Engine.Revs += 100;
                    Fueltank.Volume -= Engine.Revs * Engine.Capacity / 30000;
                }
            }
        }
        public void Brake()
        {
            Engine.Revs = 1000;
            Thread.Sleep(1000);
        }
        public void GearUp()
        {
            Gearbox.CurrentGear += 1;
            Engine.Revs -= Engine.Revs / 1.7;
        }
        public void GearDown()
        {
            if (Gearbox.CurrentGear > 0)
            {
                Gearbox.CurrentGear -= 1;
                Engine.Revs += Engine.Revs / 9;
            }
            else
            {
                Console.WriteLine("Out of gears");
            }
        }
    }
}
