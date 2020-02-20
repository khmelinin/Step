#include <time.h>
#include "HumanFactory.h"
#include "OrgFactory.h"
#include "PvPGroupCreator.h"

int main()
{
	srand(time(0));
	
	shared_ptr<Building> factory(new HumanFactory());
	vector<shared_ptr<Unit>> units;

	for (int i = 0; i < 5; i++)
	{
		switch (rand() % 3)
		{
		case 0:
			units.push_back(make_shared<Unit>(factory->createWarrior()));
			break;
		case 1:
			/*units.push_back(make_shared<Unit>(factory->createWizard()));*/
			break;
		case 2:
			/*units.push_back(make_shared<Unit>(factory->createWorker()));*/
			break;
		}
	}
	PvPGroupCreator pvp_builder(units);
	pvp_builder.createGroup();
	cout << pvp_builder.addWarrior() << endl;
}
