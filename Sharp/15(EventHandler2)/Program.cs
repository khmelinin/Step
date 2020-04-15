using System;

namespace _15_EventHandler2
{
    class ContainerInfo : EventArgs
    {
        public string Name;
    }
    class EventClass
    {
        public event EventHandler<ContainerInfo> EventTest_1;
        public event EventHandler<ContainerInfo> ColorA;
        public event EventHandler<ContainerInfo> ColorB;
        public void Letter(string nm)
        {
            ContainerInfo cInfo = new ContainerInfo();
            cInfo.Name = nm;
            EventTest_1?.Invoke(this, cInfo);
        }
        public void Color_A(string nm)
        {
            ContainerInfo cInfo = new ContainerInfo();
            cInfo.Name = nm;
            ColorA?.Invoke(this, cInfo);
        }
        public void Color_B(string nm)
        {
            ContainerInfo cInfo = new ContainerInfo();
            cInfo.Name = nm;
            ColorB?.Invoke(this, cInfo);
        }
    }

    class Program
    {
        static void HandlerA(object sen, ContainerInfo ee)
        {
            if (ee.Name == "a")
            {
                Console.WriteLine("i am 'a' ");
                Console.WriteLine("enter color = ");
                string color = Console.ReadLine();
                EventClass evClass = (EventClass)sen;
                evClass.Color_A(color);
            }
            else
                Console.WriteLine("a: no no no");
        }
        static void HandlerB(object sen, ContainerInfo ee)
        {
            if (ee.Name == "b")
            {
                Console.WriteLine("i am 'b' ");
                Console.WriteLine("enter color = ");
                string color = Console.ReadLine();
                EventClass evClass = (EventClass)sen;
                evClass.Color_B(color);
            }
            else
                Console.WriteLine("b: no no no");
        }

        static void HandlerA_Yellow(object sen, ContainerInfo ee)
        {
            if (ee.Name == "yellow")
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("a");
                Console.ResetColor();
            }
            else
                Console.WriteLine("a_yellow: no no no");
        }
        static void HandlerA_Red(object sen, ContainerInfo ee)
        {
            if (ee.Name == "red")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("a");
                Console.ResetColor();
            }
            else
                Console.WriteLine("a_red: no no no");

        }

        static void HandlerB_Green(object sen, ContainerInfo ee)
        {
            if (ee.Name == "green")
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("b");
                Console.ResetColor();
            }
            else
                Console.WriteLine("b_green: no no no");
        }

        static void HandlerB_Blue(object sen, ContainerInfo ee)
        {
            if (ee.Name == "blue")
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("b");
                Console.ResetColor();
            }
            else
                Console.WriteLine("b_blue: no no no");
        }
        static void Main(string[] args)
        {
            EventClass mc = new EventClass();
            mc.EventTest_1 += HandlerA;
            mc.EventTest_1 += HandlerB;
            mc.ColorA += HandlerA_Yellow;
            mc.ColorA += HandlerA_Red;
            mc.ColorB += HandlerB_Blue;
            mc.ColorB += HandlerB_Green;

            while (true)
            {
                Console.WriteLine("Enter letter: ");
                string s = Console.ReadLine();
                mc.Letter(s);
            }
        }
    }
}
