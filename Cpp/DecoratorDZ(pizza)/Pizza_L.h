#pragma once
#include "Food_.h"
using namespace std;
class PizzaL :public Food
{
public:
	PizzaL() :Food(9) {}
	void info()override
	{
		cout << "PizzaL" << endl;
	}
	double cost()override
	{
		return price;
	}
};