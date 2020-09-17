#include "Wizard.h"

Wizard::Wizard(const string& name, int hp, int maxAttack, int dodge):Unit(name,hp,maxAttack)
{
	this->dodge = dodge;

}

Wizard::~Wizard()
{
	cout << "~Wizard()" << endl;
}


