#pragma once
#include "Decorator_.h"
using namespace std;
class WithMoreCheese :public Decorator
{
public:
	WithMoreCheese(Food* c) :Decorator(c, 2) {}
	void info()override
	{
		Decorator::info();
		cout << "with more cheese" << endl;
	}
	double cost()override
	{
		return price + component->cost();
	}
};