#pragma once
#include "Unit.h"
using namespace std;

class Warrior:public Unit
{
	int armor=40;
public:
	Warrior(string n);
	void Attack(Unit *u);
	void getDamage(int d) override;
};

