using System;
using System.Xml;
using System.IO;

namespace _21_XML_
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            var document = new XmlDocument();
            document.Load("1.xml");
            Console.WriteLine(document.InnerText);
            Console.WriteLine(new string('-',20));
            Console.WriteLine(document.InnerXml);
            */

            /*
            FileStream stream = new FileStream("2.xml", FileMode.Open);
            XmlTextReader xmlReader = new XmlTextReader(stream);
            while (xmlReader.Read())
            {
                Console.WriteLine("{0,-10}{1,-10}{2,-10}", xmlReader.NodeType, xmlReader.Name, xmlReader.Value);
            }
            xmlReader.Close();
            */

            var document = new XmlDocument();
            document.Load("2.xml");
            XmlNode root = document.DocumentElement;
            Console.WriteLine("document.DocumentElement = {0}",root.LocalName);
            foreach(XmlNode books in root.ChildNodes)
            {
                Console.WriteLine("Found Book: ");
                foreach(XmlNode book in books.ChildNodes)
                {
                    Console.WriteLine(book.Name+": "+book.InnerText);
                }
                Console.WriteLine(new string('-',40));
            }
        }
    }
}
