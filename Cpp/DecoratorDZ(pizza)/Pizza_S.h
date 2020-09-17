#pragma once
#include "Food_.h"
using namespace std;
class PizzaS :public Food
{
public:
	PizzaS() :Food(5) {}
	void info()override
	{
		cout << "PizzaS" << endl;
	}
	double cost()override
	{
		return price;
	}
};