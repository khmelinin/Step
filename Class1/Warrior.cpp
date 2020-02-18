#include "Warrior.h"


Warrior::Warrior(string n):Unit(200, 40, n)
{
}

void Warrior::Attack(Unit* u)
{
	u->getDamage(getAttack());
}

void Warrior::getDamage(int d)
{
	if (armor > d)
		armor -= d;
	else
		setHp(getHp()-d - armor);
		armor = 0;
}
