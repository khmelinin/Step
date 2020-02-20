#include "PvPGroupCreator.h"

void PvPGroupCreator::createGroup()
{
	group = make_shared<Group>();
	group->setTitle("PvPGroup_" + to_string(id++));
	group->setType("PvP");
	war_count = 3;
	wiz_count = 3;
}

bool PvPGroupCreator::addWarrior()
{
	if (war_count == 0)
		return 0;
	do {
		auto it = find_if(units.begin(), units.end(), [](const shared_ptr<Unit>& u)->bool {
			Warrior* pt = dynamic_cast<Warrior*>(u.get());
			return pt;
			});
		if (it != units.end())
		{
			group->addUnit(*it);
			units.erase(it);
			war_count--;
		}

		else
		{
			break;
		}
	} while (war_count != 0);
		return war_count != 0;
}

PvPGroupCreator::PvPGroupCreator(vector<shared_ptr<Unit>>& u):GroupCreator(u)
{
}
