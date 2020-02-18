#pragma once
#include "Unit.h"
using namespace std;

class Warrior:public Unit
{
	int armor;
public:
	void Attack(int a);
	virtual void getDamage(int d);
};

