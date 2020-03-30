using System;

namespace _5_hero_
{
    class Program
    {
        static void Main(string[] args)
        {
            Hero hero1 = null;
            hero1 = new Hero(new Factory_Hero1());
            hero1.Run();
            hero1.Hit();
            Hero hero2 = null;
            hero2 = new Hero(new Factory_Hero2());
            hero2.Run();
            hero2.Hit();
            Console.ReadKey();
        }
    }
}
