#include "Wizzard.h"

Wizzard::Wizzard(string n) :Unit(200, 46, n)
{
}

void Wizzard::Attack(Unit* u)
{
	u->getDamage(getAttack());
}

void Wizzard::getDamage(int d)
{
	if ((rand() % 10 + 0) % 2 == 0)
	{
		dodge--;
	}
	else
	{
		setHp(getHp() - d);
	}
}
