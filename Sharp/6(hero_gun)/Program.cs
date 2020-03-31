using System;

namespace _6_hero_gun_
{
    class Program
    {
        static void Main(string[] args)
        {
            AbstractWeapon smg = new MachineGun();
            AbstractWeapon p = new Pistol();
            Hero a = new Hero(p);
            a.Shoot();
            Hero b = new Hero(smg);
            b.Shoot();
        }
    }
}
