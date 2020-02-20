#include "HumanWarrior.h"
HumanWarrior::HumanWarrior(const string& name, int hp, int maxAttack, int armor) :Warrior(name, hp, maxAttack,armor)
{
}

HumanWarrior::~HumanWarrior()
{
	cout << "~HumanWarrior()" << endl;
}


void HumanWarrior::getDamage(int val)
{
	armor -= val;
	if (armor < 0 || hp<=0)
	{
		hp += armor;
		armor = 0;
		if (hp <= 0)
			cout << "Warrior die" << endl;
		else cout << "Hp: " << hp << " / Armor: " << armor << endl;
	}
	else
	cout << "Hp: " << hp << " / Armor: " << armor << endl;


}

void HumanWarrior::attack(Unit* pt)
{
	int tmp = rand() % maxAttack + 1;
	pt->getDamage(tmp);
	cout << name << " is trying to damage." << " Damage is " << tmp << " points." << endl;
}
