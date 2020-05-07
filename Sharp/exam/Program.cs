using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Security.Cryptography;
using System.Collections.Generic;

namespace exam
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1
            Console.WriteLine("\n # 1");
            Converter converter = new Converter(100, 200, 300);
            Console.WriteLine("usd-uah = {0}",converter.UsdUah());
            Console.WriteLine("eur-uah = {0}",converter.EurUah());
            Console.WriteLine("rub-uah = {0}",converter.RubUah());

            //2
            Console.WriteLine("\n # 2");
            Invoice invoice = new Invoice(1234, "Vasya", "Igor", "cpu", 3);
            Console.WriteLine("Price = {0}",invoice.CalcCost(true));
            Console.WriteLine("Price = {0}",invoice.CalcCost(false));
            invoice.Article = "cooler";
            Console.WriteLine("Price = {0}", invoice.CalcCost(true));

            //3
            Console.WriteLine("\n # 3");
            MyMatrix mymatrix = new MyMatrix(3, 4);
            mymatrix.print();
            Console.WriteLine();
            mymatrix.Resize(5, 5);
            mymatrix.print();
            Console.WriteLine();
            mymatrix.Resize(2, 2);
            mymatrix.print();

            //4
            Console.WriteLine("\n # 4");
            Article[]article = { new Article("Milk", "Fozzy", 13), new Article("Bread", "Fozzy", 8), new Article("Mushrooms", "ATB", 6), new Article("Apples", "WallMart", 10) };
            Store store = new Store(article);
            Console.WriteLine(store[1]);
            Console.WriteLine(store["Fozzy"]);

            //5
            Console.WriteLine("\n # 5");
            Months months = new Months();
            months.MonthsIndex(7);
            months.MonthsIndex(30);
            months.MonthsDays(28);
            months.MonthsDays(31);
            months.MonthsDays(33);

            //6
            Console.WriteLine("\n # 6");
            Dictionarry dictionarry = new Dictionarry();
            dictionarry.AddEng("car", "машина");
            dictionarry.AddEng("human", "людина");
            dictionarry.AddRus("человек", "людина");
            dictionarry.AddRus("воздух", "повiтря");

            dictionarry.GetUkrEng("повiтря");
            dictionarry.GetUkrEng("людина");
            dictionarry.GetUkrRus("повiтря");
            dictionarry.GetUkrRus("машина");

            //7
            Console.WriteLine("\n # 7");
            
            _7 instance = new _7();
            instance.Name = "Vasya";
            instance.Age = 7;
            XmlSerializer serial = new XmlSerializer(typeof(_7));
            FileStream stream = new FileStream("Vasya.xml", FileMode.Create, FileAccess.Write, FileShare.Read);
            serial.Serialize(stream, instance);
            stream.Close();

            stream = new FileStream("Vasya.xml", FileMode.Open, FileAccess.Read, FileShare.Read);
            _7 instance1 = serial.Deserialize(stream) as _7;
            instance1.Print();
        }
    }
}
