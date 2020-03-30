using System;

namespace _5_abstract_factory_
{
    
    class Program
    {
        static void Main(string[] args)
        {
            Client client_coca = null;
            client_coca = new Client(new Factory_Coca());
            client_coca.Run();
            Client client_pepsi = null;
            client_pepsi = new Client(new Factory_Pepsi());
            client_pepsi.Run();
            Console.ReadKey();

        }
    }
}
