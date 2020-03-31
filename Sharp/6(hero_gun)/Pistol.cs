using System;
using System.Collections.Generic;
using System.Text;

namespace _6_hero_gun_
{
    class Pistol:AbstractWeapon
    {
        public override void Fire()
        {
            Console.WriteLine("Shoot from Pistol");
        }
    }
}
