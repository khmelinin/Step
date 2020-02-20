#pragma once
#include "GroupCreator.h"
class PvPGroupCreator:public GroupCreator
{
public:
	void createGroup()override;
	bool addWarrior()override;
	bool addWizard()override;
	bool addWorker()override;
	PvPGroupCreator(vector<shared_ptr<Unit>>& u);
};

