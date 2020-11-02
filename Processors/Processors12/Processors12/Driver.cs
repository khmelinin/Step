using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Processors12
{
    class Driver
    {
        public Car car { get; set; }
        public Task StartEngine;
        public Task Gas;
        public Task Brake;
        public Task GearUp;
        public Task GearDown;

        public Driver(Car c)
        {
            car = c;
        }

        public void Drive()
        {
            Console.Write($"RPM: {car.Engine.Revs} ");
            string cr = Console.ReadLine();
            if (cr == "q")
            {
                StartEngine = new Task(car.StartEngine, car.StopStart.Token);
                StartEngine.Start();
            }
            else if (cr == "w")
            {

                if (StartEngine.Status == TaskStatus.Running)
                {
                    car.StopStart.Cancel();
                }
                Gas = new Task(car.Gas, car.StopGas.Token);
                Gas.Start();
            }
            else if (cr == "e")
            {
                if (StartEngine.Status == TaskStatus.Running)
                {
                    car.StopStart.Cancel();
                }
                if (Gas != null && Gas.Status == TaskStatus.Running)
                {
                    car.StopGas.Cancel();
                }
                car.Engine.Revs = 0;
            }
            else if (cr == "s")
            {
                if (StartEngine.Status != TaskStatus.Running)
                {
                    if (Gas != null && Gas.Status == TaskStatus.Running)
                    {
                        car.StopGas.Cancel();
                        car.StopGas = new CancellationTokenSource();
                    }
                    Brake = new Task(car.Brake);
                    Brake.Start();
                    Brake.Wait();
                }
            }
            else if (cr == "a")
            {
                GearDown = new Task(car.GearDown);
                GearDown.Start();
                GearDown.Wait();
            }
            else if (cr == "d")
            {
                GearUp = new Task(car.GearUp);
                GearUp.Start();
                GearUp.Wait();
            }
        }
    }
}
