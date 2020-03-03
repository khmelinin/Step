#include <iostream>
using namespace std;

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



class PizzaS :public Food
{
public:
	PizzaS():Food(5){}
	void info()override
	{
		cout << "Coffee" << endl;
	}
	double cost()override
	{
		return price;
	}
};



class Decorator :public Food
{
protected:
	Food* component = nullptr;
public:
	
	Decorator(Beverage* pt,double p):Food(p)
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



class WithMeat :public Decorator
{
public:
	WithMeat(Food* c) :Decorator(c,2) {}
	void info()override
	{
		Decorator::info();
		cout << "with milk" << endl;
	}
	double cost()override
	{
		return price+component->cost();
	}
};



class WithMushrooms :public Decorator
{
public:
	WithMushrooms(Food* c):Decorator(c,1){}
	void info()override
	{
		Decorator::info();
		cout << "with sugar" << endl;
	}
	double cost()override
	{
		return price+component->cost();
	}
};

int main()
{
	PizzaS* c = new PizzaS();
	c->info();
	WithMeat* cwm = new WithMeat(c);
	WithMeat* cwmm = new WithMeat(cwm);
	cwmm->info();
	WithMushrooms* cwmms = new WithMushrooms(cwmm);
	cwmms->info();
	cout << cwmms->cost() << endl;

}