#include "Unit.h"

Unit::Unit(int h, int a, string n)
{
	hp = h;
	attack = a;
	name = n;
}

void Unit::Attack(Unit* u)
{
	u->getDamage(attack);
}

void Unit::getDamage(int damage)
{
	hp -= damage;
}

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

int Unit::getAttack()
{
	return attack;
}
