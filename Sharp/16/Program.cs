using System;

namespace _16
{
    class Program
    {
        public delegate string Message();
        public delegate void ArrMessage(Message[] m);
        public static string Method_1()
        {
            return "Method_1";
        }
        public static string Method_2()
        {
            return "Method_2";
        }
        public static string Method_3()
        {
            return "Method_3";
        }
        public static string Method_4()
        {
            return "Method_4";
        }
        public static string Method_5()
        {
            return "Method_5";
        }
        static void Main(string[] args)
        {
            Message[] arr = new Message[5];
            arr[0] = new Message(Method_1);
            arr[1] = new Message(Method_2);
            arr[2] = new Message(Method_3);
            arr[3] = new Message(Method_4);
            arr[4] = new Message(Method_5);

            ArrMessage arrm = delegate (Message[] arr)
            {
                for (int i = 0; i < arr.Length; i++)
                    Console.WriteLine(arr[i].Invoke());

            };

            arrm.Invoke(arr);
        }



    }
}
