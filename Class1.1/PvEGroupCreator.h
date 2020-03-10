
#pragma once
#include "GroupCreator.h"
class PvEGroupCreator :public GroupCreator
{
public:
	PvEGroupCreator(vector<shared_ptr<Unit>>& u);
	void createGroup()override;
	bool addWarrior()override;
	bool addWizard()override;
	bool addWorker()override;

};
