using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DamageCalc
{
    [Serializable]
    class Weapon
    {
        string name;
        double hp = -1;
        double multiplayer = 1;
        double dmg = -1;
        double rpm = -1;

        double ttk = -1;
        double dps = -1;

        public Weapon(string name, double hp, double multiplayer, double dmg, double rpm, double ttk, double dps)
        {
            this.name = name;
            this.hp = hp;
            this.Multiplayer = multiplayer;
            this.dmg = dmg;
            this.rpm = rpm;
            this.ttk = ttk;
            this.dps = dps;
        }

        public double Hp { get => hp; set => hp = value; }
        public double Dmg { get => dmg; set => dmg = value; }
        public double Rpm { get => rpm; set => rpm = value; }
        public double Ttk { get => ttk; set => ttk = value; }
        public double Dps { get => dps; set => dps = value; }
        public string Name { get => name; set => name = value; }
        public double Multiplayer { get => multiplayer; set => multiplayer = value; }

        public string ToStringShort()
        {
            return  name + " |dmg=" + dmg.ToString() + " rpm=" + rpm.ToString()+"|";
        }

        public override string ToString()
        {
            return name + ":\r\n\r\ndmg=" + dmg.ToString() + "\r\nrpm=" + rpm.ToString() + "\r\n_____________\r\nwith hp=" + hp.ToString() + "\r\nmuliplayer=" + multiplayer.ToString() + "\r\nttk=" + ttk.ToString() + "\r\ndps=" + dps.ToString();
        }
    }
}
