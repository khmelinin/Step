#include <iostream>
using namespace std;

class Beverage
{
protected:
	double price = 0;
public:
	Beverage(double p)
	{
		price = p;
	}
	virtual void info() = 0;
	virtual ~Beverage() = default;
	virtual double cost() = 0;
};



class Coffee :public Beverage
{
public:
	Coffee():Beverage(5){}
	void info()override
	{
		cout << "Coffee" << endl;
	}
	double cost()override
	{
		return price;
	}
};



class Decorator :public Beverage
{
protected:
	Beverage* component = nullptr;
public:
	
	Decorator(Beverage* pt,double p):Beverage(p)
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



class WithMilk :public Decorator
{
public:
	WithMilk(Beverage* c) :Decorator(c,2) {}
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



class WithSugar :public Decorator
{
public:
	WithSugar(Beverage* c):Decorator(c,1){}
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
	Coffee* c = new Coffee();
	c->info();
	WithMilk* cwm = new WithMilk(c);
	WithMilk* cwmm = new WithMilk(cwm);
	cwmm->info();
	WithSugar* cwmms = new WithSugar(cwmm);
	cwmms->info();
	cout << cwmms->cost() << endl;

}