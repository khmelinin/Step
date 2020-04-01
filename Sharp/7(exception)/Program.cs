using System;
using System.Collections;

namespace _7_exception_
{
    class MyClass
    {
        public void MyMethod()
        {
            Exception exception = new Exception("My Exception!");
            exception.HelpLink = "http://MyCompany.com/ErrorService";
            exception.Data.Add("Exception cause by: ","Test exception");
            exception.Data.Add("Exception time: ", DateTime.Now);
            throw exception;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            
            try
            {
                MyClass instance = new MyClass();
                instance.MyMethod();
            }
            catch(Exception e)
            {
                Console.WriteLine("Member name: {0}", e.TargetSite);
                Console.WriteLine("Member Class: {0}", e.TargetSite.DeclaringType);
                Console.WriteLine("Member type: {0}",e.TargetSite.MemberType);
                Console.WriteLine("Message: {0}", e.Message);
                Console.WriteLine("Source: {0}",e.HelpLink);
                Console.WriteLine("Stack: {0}",e.StackTrace);
                Console.WriteLine("______________________________");
                foreach(DictionaryEntry de in e.Data)
                {
                    Console.WriteLine("{0}:{1}",de.Key,de.Value);
                }
            }
            Console.ReadKey();

        }
    }
}
