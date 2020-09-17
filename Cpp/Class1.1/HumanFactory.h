#pragma once
#include "Building.h"
#include "HumanWarrior.h"
#include "HumanWorker.h"
#include "HumanWizard.h"
class HumanFactory :public Building {
public:
	~HumanFactory()override;
	Wizard* createWizard()override;
	Warrior* createWarrior()override;
	Worker* createWorker()override;
};