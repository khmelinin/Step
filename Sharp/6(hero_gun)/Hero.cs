using System;
using System.Collections.Generic;
using System.Text;

namespace _6_hero_gun_
{
    class Hero
    {
        private AbstractWeapon w;
        public Hero(AbstractWeapon ww)
        {
            w = ww;
        }
        public void Shoot()
        {
            w.Fire();
        }
    }
}
