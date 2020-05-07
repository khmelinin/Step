using System;
using System.Collections.Generic;
using System.Text;

namespace exam
{
    class Article
    {
        string name;
        string shop;
        double price;

        public Article(string name, string shop, double price)
        {
            this.name = name;
            this.shop = shop;
            this.price = price;
        }

        public string Shop { get => shop; set => shop = value; }

        public string Properties()
        {
            return "name =  " + name + "\n" + "shop = " + shop + "price = " + price.ToString();
        }
    }

    class Store
    {
        Article[] articles;

        public Store(Article[] articles)
        {
            this.articles = articles;
        }

        public string this[int index]
        {
            get { return articles[index].Properties(); }
        }

        public string this[string shop]
        {
            get {
                string s="";
                for (int i = 0; i < articles.Length; i++)
                {
                    if (articles[i].Shop == shop)
                        s += (articles[i].Properties() + "\n");
                }
                return s;
            }
        }
    }
}
