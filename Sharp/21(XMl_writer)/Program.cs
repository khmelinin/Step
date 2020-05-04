using System;
using System.Xml;
using System.IO;

namespace _21_XMl_writer_
{
    class Program
    {
        static void Main(string[] args)
        {
            // /*
            var xmlWriter = new XmlTextWriter("2.xml", null)
            {
                Formatting = Formatting.Indented,
                IndentChar='\t',
                Indentation = 1,
                QuoteChar = '\''
            };
            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("ListOfBooks");
            xmlWriter.WriteStartElement("ListOfBooks","___https://localhost/test");
            xmlWriter.WriteStartElement("prefix","ListOfBooks","https://localhost/test");
            xmlWriter.Close();
            // */

            /*
            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("ListOfBooks");
            xmlWriter.WriteComment("comment");
            xmlWriter.WriteStartElement("Books");
            xmlWriter.WriteStartAttribute("FontSize");
            xmlWriter.WriteString("8");
            xmlWriter.WriteEndAttribute();
            xmlWriter.WriteString("Title-1");
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndElement();
            */

            xmlWriter.Close();
        }
    }
}
