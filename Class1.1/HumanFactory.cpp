#include "HumanFactory.h"

HumanFactory::~HumanFactory()
{
	cout << "~HumanFactory()" << endl;
}

Wizard* HumanFactory::createWizard()
{
	return new HumanWizard("Wizard " + to_string(id++), 75, 150, 25);
}

Warrior* HumanFactory::createWarrior()
{
	return new HumanWarrior("Warrior" + to_string(id++), 150, 75, 100);
}

Worker* HumanFactory::createWorker()
{
	return new HumanWorker("Worker " + to_string(id++), 300, 50, 33);
}
