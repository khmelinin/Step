using System;
using System.Xml;
using System.Xml.XPath;
using System.IO;

namespace _21_xpath_
{
    class Program
    {
        static void Main(string[] args)
        {
            var document = new XPathDocument("2.xml");
            XPathNavigator navigator = document.CreateNavigator();
            Console.WriteLine("navigator.CanEdit = {0}",navigator.CanEdit);

            XPathNodeIterator iterator1 = navigator.Select("ListOfBooks/Book/Title");
            while(iterator1.MoveNext())
            {
                Console.WriteLine(iterator1.Current);
            }
            Console.WriteLine(new string('-',19));
            XPathExpression expr = navigator.Compile("ListOfBooks/Book[2]/Price");
            XPathNodeIterator iterator2 = navigator.Select(expr);
            while(iterator2.MoveNext())
            {
                Console.WriteLine(iterator2.Current);
            }

            var xmldoc = new XmlDocument();
            xmldoc.Load("2.xml");

            navigator = xmldoc.CreateNavigator();
            navigator.MoveToChild("ListOfBooks", "");
            navigator.MoveToChild("Book", "");

            navigator.InsertBefore("<InsertBefore>insert_before</InsertBefore>");
            navigator.InsertAfter("<InsertAfter>insert_after</InsertAfter>");
            navigator.AppendChild("<AppendChild>append_child</AppendChild>");

            navigator.MoveToNext("Book", "");
            navigator.InsertBefore("<InsertBefore>111</InsertBefore>");
            navigator.InsertAfter("<InsertAfter>222</InsertAfter>");
            navigator.AppendChild("<AppendChild>333</AppendChild>");
            xmldoc.Save("2.xml");


        }
    }
}
