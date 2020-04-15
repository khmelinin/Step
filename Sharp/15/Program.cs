using System;

namespace _15
{
    class ContainerInfo:EventArgs
    {
        public int number;
        public string Name;
    }
    class MyClass
    {
        public event EventHandler<ContainerInfo> EventTest_1;
        public void StartEvent(int n, string nm)
        {
            ContainerInfo cInfo = new ContainerInfo();
            cInfo.number = n;
            cInfo.Name = nm;
            EventTest_1?.Invoke(this, cInfo);
        }
    }
    class Program
    {
        static void Handler1(object sen, ContainerInfo ee)
        {
            Console.WriteLine("Handler1" + sen.GetType());
            Console.WriteLine(ee.number);
            Console.WriteLine(ee.Name);
        }
        static void Handler2(object sen, ContainerInfo ee)
        {
            Console.WriteLine("Handler2"+sen.GetType());
            Console.WriteLine(ee.number);
            Console.WriteLine(ee.Name);
        }
        static void Main(string[] args)
        {
            MyClass mc = new MyClass();
            mc.EventTest_1 += Handler1;
            mc.StartEvent(3,"chuvk");
            mc.EventTest_1 += Handler2;
            mc.StartEvent(4, "4chuvk4");
        }
    }
}
