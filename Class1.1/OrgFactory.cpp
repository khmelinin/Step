#include "OrgFactory.h"

OrgFactory::~OrgFactory()
{
	cout << "~OrgFactory()" << endl;
}

Wizard* OrgFactory::createWizard()
{
	return new OrgWizard("Wizard " + to_string(id++), 75, 150, 25);
}

Warrior* OrgFactory::createWarrior()
{
	return new OrgWarrior("Warrior" + to_string(id++), 150, 75, 100);
}

Worker* OrgFactory::createWorker()
{
	return new OrgWorker("Worker " + to_string(id++), 300, 50, 33);
}
