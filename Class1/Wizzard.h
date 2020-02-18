#pragma once
#include "Unit.h"
using namespace std;

class Wizzard:public Unit
{
	int dodge=9;
public:
	Wizzard(string n);
	void Attack(Unit *u);
	void getDamage(int d) override;
};

