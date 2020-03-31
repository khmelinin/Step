using System;

namespace _6_dictionary_
{
    class Program
    {
        class Dictionary
        {
            private string []eng;
            private string []rus;
            public Dictionary(string[] e, string[] r)
            {
                eng = e;
                rus = r;
            }
            public string this[string word]
            {
                get
                {
                    for (int i = 0; i < eng.Length; i++)
                    {
                        if (word == eng[i])
                            return rus[i];
                        else
                        if (word == rus[i])
                            return eng[i];
                    }
                    return "word is not found";
                    
                }
            }
        }
        static void Main(string[] args)
        {
            string[] e = new string[] { "hello", "world" };
            string[] r = new string[] { "здравствуй", "мир" };
            Dictionary d= new Dictionary(e, r);
            Console.WriteLine(d["hell"]);
        }
    }
}
