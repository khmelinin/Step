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
        string name = "";
        double hp = -1;
        double multiplayer = 1;
        double dmg = -1;
        double rpm = -1;
        double dst = -1;

        double ttk = -1;
        double rtk = -1;
        double dps = -1;

        public Weapon(string name, double hp, double multiplayer, double dmg, double rpm, double ttk, double rtk, double dps)
        {
            this.name = name;
            this.hp = hp;
            this.Multiplayer = multiplayer;
            this.dmg = dmg;
            this.rpm = rpm;
            this.ttk = ttk;
            this.rtk = rtk;
            this.dps = dps;
        }

        public Weapon()
        {

        }

        public Weapon(string name, double hp, double multiplayer, double dmg, double rpm, double dst,double ttk, double rtk, double dps)
        {
            this.name = name;
            this.hp = hp;
            this.Multiplayer = multiplayer;
            this.dmg = dmg;
            this.rpm = rpm;
            this.dst = dst;
            this.ttk = ttk;
            this.rtk = rtk;
            this.dps = dps;
        }

        public double Hp { get => hp; set => hp = value; }
        public double Dmg { get => dmg; set => dmg = value; }
        public double Rpm { get => rpm; set => rpm = value; }
        public double Ttk { get => ttk; set => ttk = value; }
        public double Dps { get => dps; set => dps = value; }
        public string Name { get => name; set => name = value; }
        public double Multiplayer { get => multiplayer; set => multiplayer = value; }
        public double Rtk { get => rtk; set => rtk = value; }
        public double Dst { get => dst; set => dst = value; }

        public string ToStringShort()
        {
            string spaces = " ";
            for (int i = 0; i < name.Length; i++)
            {
                spaces += ' ';
            }
            if (dst == -1)
                return name + " |dmg=" + dmg.ToString() + " rpm=" + rpm.ToString() + " dst=----"  + "|" + "\r\n" + spaces + "|ttk=" + ttk.ToString() + " rtk=" + rtk.ToString() + " dps=" + dps.ToString() + "|";
            else
            return name + " |dmg=" + dmg.ToString() + " rpm=" + rpm.ToString() + " dst=" + dst.ToString() + "|" + "\r\n" + spaces + "|ttk=" + ttk.ToString() + " rtk=" + rtk.ToString() + " dps=" + dps.ToString() + "|";
        }

        public override string ToString()
        {
            string lines = "____";
            for (int i = 0; i < name.Length; i++)
            {
                lines += '_';
            }
            if (dst == -1)
                return lines + "\r\n" + "| " + name + " |\r\n" + lines + "\r\n\r\ndmg=" + dmg.ToString() + "\r\nrpm=" + rpm.ToString()+ "\r\ndst=----"+ "\r\n_________________\r\nwith hp=" + hp.ToString() + "\r\nmuliplayer=" + multiplayer.ToString() + "\r\nttk=" + ttk.ToString() + "\r\nrtk=" + rtk.ToString() + "\r\ndps=" + dps.ToString();
            else
                return lines + "\r\n" + "| " + name + " |\r\n" + lines + "\r\n\r\ndmg=" + dmg.ToString() + "\r\nrpm=" + rpm.ToString() + "\r\ndst=" + dst.ToString() + "\r\n_________________\r\nwith hp=" + hp.ToString() + "\r\nmuliplayer=" + multiplayer.ToString() + "\r\nttk=" + ttk.ToString() + "\r\nrtk=" + rtk.ToString() + "\r\ndps=" + dps.ToString();
        }
    }
}
