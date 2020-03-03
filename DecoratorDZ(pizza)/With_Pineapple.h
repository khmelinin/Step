#pragma once
#include "Decorator_.h"
using namespace std;
class WithPineapple :public Decorator
{
public:
	WithPineapple(Food* c) :Decorator(c, 1) {}
	void info()override
	{
		Decorator::info();
		cout << "with pineapple" << endl;
	}
	double cost()override
	{
		return price + component->cost();
	}
};