using System;

namespace DZ_delegates_tank__
{
    public class Tank
    {
        string name;
        int ammo;
        int armor;
        int agility;

        public Tank(string name)
        {
            this.name = name;
            ammo = new Random().Next(0,100);
            armor = new Random().Next(0, 100);
            agility = new Random().Next(0, 100);
        }
        public string Parameters()
        {
            return ammo.ToString() + " " + armor.ToString() + " " + agility.ToString();
        }
        public static bool operator*(Tank a,Tank b)
        {
            try
            {
                if (a.ammo + a.armor + a.agility == b.ammo + b.armor + b.agility)
                    throw new Exception("Draw! Identical sums of tanks parameters!");
                if (a.ammo + a.armor + a.agility > b.ammo + b.armor + b.agility)
                    return true;
                return false;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
    }
}
