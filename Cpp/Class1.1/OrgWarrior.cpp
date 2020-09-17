#include "OrgWarrior.h"

OrgWarrior::OrgWarrior(const string& name, int hp, int maxAttack, int armor):Warrior(name,hp,maxAttack,armor)
{
}

OrgWarrior::~OrgWarrior()
{
	cout << "~OrgWarrior()" << endl;
}

void OrgWarrior::getDamage(int val)
{
	armor -= val;
	if (armor < 0)
	{
		hp += armor;
		armor = 0;
		if (hp <= 0)
			cout << "Warrior die" << endl;
		
	}
	 cout << "Hp: " << hp << " / Armor: " << armor << endl;
}

void OrgWarrior::attack(Unit* pt)
{
	int tmp = rand() % maxAttack + 1;
	pt->getDamage(tmp);
	cout << name << " is trying to damage." << " Damage is " << tmp << " points." << endl;
}


