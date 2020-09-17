#include "Director.h"

Director::Director(vector<shared_ptr<Unit>>&u):units(u)
{
}

void Director::setCreator(shared_ptr<GroupCreator> pt)
{
	builder = move(pt);
}

shared_ptr<Group> Director::make()
{
	builder->createGroup();
	while (builder->addWarrior() || builder->addWizard() || builder->addWorker())
	{
		registerToBattle(units);
	}
	return builder->getGroup();
}
