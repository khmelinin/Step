using System;
using System.IO;
using System.Xml;

namespace _22_xml_
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlDocument doc = new XmlDocument();
            XmlNode docNode = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            doc.AppendChild(docNode);

            XmlNode productsNode = doc.CreateElement("products");
            doc.AppendChild(productsNode);
            XmlNode productNode = doc.CreateElement("product");
            XmlAttribute product_attribute = doc.CreateAttribute("id");
            product_attribute.Value = "1001";
            productNode.Attributes.Append(product_attribute);
            productsNode.AppendChild(productNode);

            XmlNode nameNode = doc.CreateElement("productName");
            nameNode.AppendChild(doc.CreateElement("Coffee"));
            productsNode.AppendChild(nameNode);
            XmlNode priceNode = doc.CreateElement("productPrice");
            priceNode.AppendChild(doc.CreateElement("0.99"));
            productNode.AppendChild(priceNode);



            productNode = doc.CreateElement("product");
            product_attribute = doc.CreateAttribute("id");
            product_attribute.Value = "1002";
            productNode.Attributes.Append(product_attribute);
            productsNode.AppendChild(productNode);

            nameNode = doc.CreateElement("productName");
            nameNode.AppendChild(doc.CreateElement("Coffee"));
            productsNode.AppendChild(nameNode);
            priceNode = doc.CreateElement("productPrice");
            priceNode.AppendChild(doc.CreateElement("9.99"));
            productNode.AppendChild(priceNode);
            doc.Save(Console.Out);


        }
    }
}
