#pragma once
#include "Wizard.h"
#include "Worker.h"
#include "Warrior.h"
class Building {
protected:
	int id = 0;
public:
	virtual Wizard* createWizard() = 0;
	virtual Warrior* createWarrior() = 0;
	virtual Worker* createWorker() = 0;
	virtual ~Building();
};