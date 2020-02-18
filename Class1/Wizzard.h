#pragma once
#include "Unit.h"
using namespace std;

class Wizzard:public Unit
{
	int dodge;
public:
	void Attack(int a);
	virtual void getDamage(int d);
};

