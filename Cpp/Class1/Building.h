#pragma once
#include "Unit.h"
#include "Warrior.h"
#include "Wizzard.h"
#include "Worker.h"

class Building
{
public:
	string Name();
	Warrior* CreateWarrior();
	Wizzard* CreateWizzard();
	Worker* CreateWorker();
};

