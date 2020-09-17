#pragma once
#include "Building.h"
#include "OrgWarrior.h"
#include "OrgWorker.h"
#include "OrgWizard.h"
class OrgFactory :public Building {
public:
	~OrgFactory()override;
	Wizard* createWizard()override;
	Warrior* createWarrior()override;
	Worker* createWorker()override;
};