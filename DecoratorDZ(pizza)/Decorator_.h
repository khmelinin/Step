#pragma once
#include "Food_.h"
class Decorator :public Food
{
protected:
	Food* component = nullptr;
public:

	Decorator(Food* pt, double p) :Food(p)
	{
		component = pt;
	}

	void info()override
	{
		if (component)
			component->info();
	}
	~Decorator()
	{
		delete[]component;
	}
};