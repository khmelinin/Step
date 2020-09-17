#pragma once
#include "Decorator_.h"
using namespace std;

class WithMushrooms :public Decorator
{
public:
	WithMushrooms(Food* c) :Decorator(c, 1) {}
	void info()override
	{
		Decorator::info();
		cout << "with mushrooms" << endl;
	}
	double cost()override
	{
		return price + component->cost();
	}
};