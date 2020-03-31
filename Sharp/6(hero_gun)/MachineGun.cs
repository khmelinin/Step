using System;
using System.Collections.Generic;
using System.Text;

namespace _6_hero_gun_
{
    class MachineGun : AbstractWeapon
    {
        public override void Fire()
        {
            Console.WriteLine("Shoot from MachineGun");
        }
    }
}
