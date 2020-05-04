using System;
using System.IO;
using System.Xml;

namespace _21_XML1_
{
    class Program
    {

        static void Main(string[] args)
        {
            var reader = new XmlTextReader("2.xml");


            /*
            while(reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element)
                    if (reader.Name.Equals("Title"))
                    {
                        Console.WriteLine("|{0}|",reader.GetAttribute("FontSize"));
                    }
            }
            */


            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element)
                    if (reader.HasAttributes)
                    {
                        while (reader.MoveToNextAttribute())
                        {
                            Console.WriteLine("{0} = {1}", reader.Name, reader.Value);
                        }
                    }
            }
        }
    }
}
