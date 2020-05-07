using System;
using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Text;

namespace exam
{
    public class _7
    {
        string name;
        int age;
        public _7()
        {
            
        }
        public _7(string name, int age)
        {
            this.name = name;
            this.age = age;
        }
        [XmlAttribute("name")]
        public string Name { get => name; set => name = value; }
        [XmlAttribute("age")]
        public int Age { get => age; set => age = value; }
        public void Print()
        {
            Console.WriteLine(name+" "+age.ToString());
        }
    }
}
