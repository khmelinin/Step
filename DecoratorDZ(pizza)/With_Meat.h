#pragma once
#include "Decorator_.h"
using namespace std;

class WithMeat :public Decorator
{
public:
	WithMeat(Food* c) :Decorator(c, 3) {}
	void info()override
	{
		Decorator::info();
		cout << "with meat" << endl;
	}
	double cost()override
	{
		return price + component->cost();
	}
};