#pragma once
#include <iostream>
class Food
{
protected:
	double price = 0;
public:
	Food(double p)
	{
		price = p;
	}
	virtual void info() = 0;
	virtual ~Food() = default;
	virtual double cost() = 0;
};