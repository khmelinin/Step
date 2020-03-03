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



class Pizza :public Food
{
public:
	Pizza() :Food(5) {}
	void info()override
	{
		cout << "Pizza" << endl;
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



class WithMeat :public Decorator
{
public:
	WithMeat(Food* c) :Decorator(c, 3) {}
	void info()override
	{
		Decorator::info();
		cout << "with meat" << endl;
	}
	double cost()override
	{
		return price + component->cost();
	}
};



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

int main()
{
	Pizza* c = new Pizza();
	c->info();
	WithMeat* cwm = new WithMeat(c);
	WithMeat* cwmm = new WithMeat(cwm);
	cwmm->info();
	WithMushrooms* cwmms = new WithMushrooms(cwmm);
	cwmms->info();
	WithMoreCheese* cwmmsc = new WithMoreCheese(cwmm);
	cwmmsc->info();
	WithPineapple* cwmmsca = new WithPineapple(cwmm);
	cwmmsca->info();
	cout << cwmmsca->cost() << endl;

}