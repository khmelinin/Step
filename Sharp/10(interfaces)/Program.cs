using System;

namespace _10_interfaces_
{
    abstract class AbstractHandler
    {
        public abstract void Open();
        public abstract void Create();
        public abstract void Save();
    }
    class DOCHandler:AbstractHandler
    {
        public override void Open()
        {
            Console.WriteLine("open DOC");
        }
        public override void Create()
        {
            Console.WriteLine("create DOC");
        }
        public override void Save()
        {
            Console.WriteLine("save DOC");
        }

        
    }

    class TXTHandler : AbstractHandler
    {
        public override void Open()
        {
            Console.WriteLine("open TXT");
        }
        public override void Create()
        {
            Console.WriteLine("create TXT");
        }
        public override void Save()
        {
            Console.WriteLine("save TXT");
        }


    }

    class XMLHandler : AbstractHandler
    {
        public override void Open()
        {
            Console.WriteLine("open XML");
        }
        public override void Create()
        {
            Console.WriteLine("create XML");
        }
        public override void Save()
        {
            Console.WriteLine("save XML");
        }


    }

    class Redactor
    {
        AbstractHandler handler;
        public void ChooseDocument(string s)
        {
            if (s.EndsWith(".doc"))
                handler = new DOCHandler();
            else
            if (s.EndsWith(".txt"))
                handler = new TXTHandler();
            else
            if (s.EndsWith(".xml"))
                handler = new XMLHandler();
            else
                Console.WriteLine("Error");
        }
        public void Create()
        {
            handler.Create();
        }
        public void Open()
        {
            handler.Open();
        }
        public void Save()
        {
            handler.Save();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //Redactor rar = new Redactor();
            //rar.ChooseDocument("kursach.doc");
            //rar.Open();

            //Class1 inst = new Class1();
            //Interface1 interf = inst as Interface1;

            /*
            Dog dogOr = new Dog();
            ISecurity dogSec = new Dog();
            IGoEat cat = new Cat();
            IGoEat dog = dogSec as IGoEat;
            dog.Go();
            dog.Eat();
            dogSec.Guard();
            cat.Go();
            cat.Eat();
            */

            Player pl = new Player();
            IPlay p = new Player();
            IRecord r = new Player();

            p.Play();
            r.Record();

        }
    }

}
