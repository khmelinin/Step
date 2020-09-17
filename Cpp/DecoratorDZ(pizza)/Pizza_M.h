#pragma once
#include "Food_.h"
using namespace std;
class PizzaM :public Food
{
public:
	PizzaM() :Food(7) {}
	void info()override
	{
		cout << "PizzaM" << endl;
	}
	double cost()override
	{
		return price;
	}
};