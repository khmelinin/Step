#include <iostream>
#include <time.h>
//#include "Worker.h"
//#include "Warrior.h"
//#include "Wizard.h"

#include "HumanFactory.h"
#include "OrgFactory.h"

int main()
{
	srand(time(0));
	
	HumanFactory a;
	Wizard* wiz1 = a.createWizard();
	Warrior* wiz2 = a.createWarrior();
	Wizard* wiz3 = a.createWizard();
	wiz1->attack(wiz2);
	wiz1->attack(wiz2);
	wiz1->attack(wiz2);
	delete wiz1;
	delete wiz2;
	delete wiz3;

}
