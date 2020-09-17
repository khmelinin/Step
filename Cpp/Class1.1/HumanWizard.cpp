#include "HumanWizard.h"

HumanWizard::HumanWizard(const string& name, int hp, int maxAttack, int dodge) :Wizard(name, hp, maxAttack,dodge)
{

}

HumanWizard::~HumanWizard()
{
	cout << "~HumanWizard()" << endl;
}

void HumanWizard::attack(Unit* obj)
{
	int tmp = rand() % maxAttack + 1;
	cout << name << " is trying to damage." << " Damage is " << tmp << " points." << endl;
	obj->getDamage(tmp);
	
}

void HumanWizard::getDamage(int val)
{
	if (rand() % 101 > dodge)
	{
		hp -= val;
		if (hp <= 0)
			cout << "Wizard die" << endl;
		else cout << "Hp: " << hp << endl;
	}
	else cout << "//Dodge//" << endl;



}
