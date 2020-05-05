using System;
using System.IO;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace _22_xml_serialization_
{
    public class MyClass
    {
        string id = "button";
        int size = 10;
        List<string> items = new List<string>();

        [XmlAttribute("SerialID")]
        public string Id { get => id; set => id = value; }
        [XmlAttribute("Length")]
        public int Size { get => size; set => size = value; }
        public List<string> Items { get => items; set => items = value; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            MyClass instance = new MyClass();
            for (int i = 0; i < 10; i++)
            {
                instance.Items.Add("Element " + i);
            }
            XmlSerializer serial = new XmlSerializer(typeof(MyClass));
            FileStream stream = new FileStream("Ser.xml",FileMode.Create,FileAccess.Write,FileShare.Read);
            serial.Serialize(stream, instance);
            stream.Close();

            stream = new FileStream("Ser.xml", FileMode.Open, FileAccess.Read, FileShare.Read);
            MyClass instance1 = serial.Deserialize(stream) as MyClass;


        }
    }
}
