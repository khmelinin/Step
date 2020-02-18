#pragma once
#include "Unit.h"
#include <time.h>
using namespace std;

class Worker:public Unit
{
	int passivs = 4;
public:
	Worker(string n);
	void Attack(Unit *u);
	void getDamage(int d) override;
};

