using System;

namespace _14_event_
{
    public delegate string EventDelegate(int x);
    public class CustomEventArg:EventArgs
    {
        string message;
        public CustomEventArg(string s)
        {
            message = s;
        }
        public string Message { get => message; set => message = value; }
    }
    class MyClass
    {
        public event EventHandler<CustomEventArg> myEvent;
        public void InvokeEvent()
        {
            myEvent.Invoke(this,new CustomEventArg("Custom Event"));
        }

    }

    class Program
    {
        static void Handler_1(object sender, CustomEventArg e)
        {
            Console.WriteLine(e.Message);
            
        }
        static string Handler_2(int x)
        {
            Console.WriteLine("Handler_2");
            return Convert.ToString(x);
        }

        static void Main(string[] args)
        {
            MyClass instance = new MyClass();
            instance.myEvent += Handler_1;
            instance.InvokeEvent();
        }
    }
}
