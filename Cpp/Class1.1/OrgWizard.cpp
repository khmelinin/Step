#include "OrgWizard.h"


OrgWizard::OrgWizard(const string& name, int hp, int maxAttack, int dodge) :Wizard(name, hp, maxAttack, dodge)
{

}

OrgWizard::~OrgWizard()
{
	cout << "~OrgWizard()" << endl;
}

void OrgWizard::attack(Unit* obj)
{
	int tmp = rand() % maxAttack + 1;
	obj->getDamage(tmp);
	cout << name << " is trying to damage." << " Damage is " << tmp << " points." << endl;
}

void OrgWizard::getDamage(int val)
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
