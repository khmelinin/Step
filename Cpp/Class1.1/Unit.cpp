#include "Unit.h"

Unit::Unit(const string& name, int hp,int maxAttack)
{
	this->name = name;
	this->hp = hp;
	this->maxAttack = maxAttack;
}

Unit::~Unit()
{
	cout << "~Unit()" << endl;
}

const string& Unit::getName() const
{
	return name;
}

int Unit::getMaxAttack() const
{
	return maxAttack;
}



int Unit::getHp() const
{
	return hp;
}

void Unit::setName(const string name)
{
	this->name = name;
}

void Unit::setHp(int hp)
{
	this->hp = hp;
}

void Unit::setMaxAttack(int maxAttack)
{
	this->maxAttack = maxAttack;
}
