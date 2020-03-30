using System;
using System.Collections.Generic;
using System.Text;

namespace _5_hero_
{
    class Hero
    {
        AbstractHit hit;
        AbstractMove move;
        public Hero(AbstractFactory af)
        {
            hit = af.CreateHit();
            move = af.CreateMove();
        }
        public void Run()
        {
            move.Move();
        }
        public void Hit()
        {
            hit.Hit();
        }
    }
}
