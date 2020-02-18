#pragma once
#include "Unit.h"
using namespace std;

class Worker:public Unit
{
	int passivs;
public:
	void Attack(int a);
	virtual void getDamage(int d);
};

