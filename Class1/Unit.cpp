#include "Unit.h"

int Unit::getHp() const
{
	return hp;
}

void Unit::setHp(int h)
{
	hp = h;
}

string Unit::getName() const
{
	return name;
}

void Unit::setName(string n)
{
	name = n;
}
