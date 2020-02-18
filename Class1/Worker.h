#pragma once
#include "Unit.h"
using namespace std;

class Worker:public Unit
{
	int passivs;
public:
	Worker(string n);
	void Attack(Unit *u);
	void getDamage(int d) override;
};

