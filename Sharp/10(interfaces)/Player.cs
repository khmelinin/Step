using System;
using System.Collections.Generic;
using System.Text;

namespace _10_interfaces_
{
    interface IPlay
    {
        void Play();
        void Pause();
        void Stop();
    }
    interface IRecord
    {
        void Record();
        void Pause();
        void Stop();

    }
    class Player:IPlay, IRecord
    {
        void IPlay.Play()
        {
            Console.WriteLine("PPlay");
        }
        void IPlay.Pause()
        {
            Console.WriteLine("PPause");
        }
        void IPlay.Stop()
        {
            Console.WriteLine("PStop");
        }

        void IRecord.Record()
        {
            Console.WriteLine("RRecord");
        }
        void IRecord.Pause()
        {
            Console.WriteLine("RPause");
        }
        void IRecord.Stop()
        {
            Console.WriteLine("RStop");
        }
    }
}
