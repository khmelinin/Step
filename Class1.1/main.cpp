#include <time.h>
#include "HumanFactory.h"
#include "OrgFactory.h"
#include "PvPGroupCreator.h"
#include "PvEGroupCreator.h"
#include "Director.h"
#include <thread>
#include <chrono>

void registerToBattle(vector<shared_ptr<Unit>>&units)
{
	this_thread::sleep_for(chrono::seconds(rand() % 3 + 1));
	cout << "Fresh Blood has come" << endl;
	shared_ptr<Building> factory;
	if (rand() % 2 == 0)
	{
		factory = make_shared<HumanFactory>();
	}
	else
	{
		factory = make_shared<OrgFactory>();
	}
	for (int i = 0; i < 5; i++)
	{
		switch (rand() % 3)
		{
		case 0:
			units.push_back(shared_ptr<Unit>(factory->createWarrior()));
			break;
		case 1:
			units.push_back(shared_ptr<Unit>(factory->createWizard()));
			break;
		case 2:
			units.push_back(shared_ptr<Unit>(factory->createWorker()));
			break;
		}
	}
}

int main()
{

	srand(time(0));
	shared_ptr<Building> factory(new HumanFactory());
	vector<shared_ptr<Unit>> units;
	Director director(units);
	director.setCreator(shared_ptr<PvEGroupCreator>(new PvEGroupCreator(units)));
	shared_ptr<Group> group1 = director.make();
	cout << "+++" << endl;
	shared_ptr<Group>group2 = director.make();
}