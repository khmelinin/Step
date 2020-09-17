#include "Warrior.h"

Warrior::Warrior(const string& name,int hp,int maxAttack,int armor):Unit(name,hp,maxAttack)
{
	this->armor = armor;
}

Warrior::~Warrior()
{
	cout << "~Warrior()" << endl;
}

int Warrior::getArmor() const
{
	return armor;
}

void Warrior::setArmor(int armor)
{
	this->armor = armor;
}
