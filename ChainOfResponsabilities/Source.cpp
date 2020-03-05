#include <iostream>
#include <time.h>
#include <memory>
using namespace std;

class Base
{
	shared_ptr <Base> right = nullptr;
public:
	void setNext(shared_ptr <Base> pt)
	{
		right = pt;
	}
	void add(shared_ptr <Base> pt)
	{
		if (right)
			right->add(pt);
		else
			right = pt;
	}

	virtual void handle(int task)
	{
		if (right)
			right->handle(task);
		else
			cout << endl;
	}
	virtual ~Base() = default;
	
};

class Handler1 :public Base
{
public:
	void handle(int task)override
	{
		if (rand() % 3 == 0)
		{
			cout << "H1 can not handle " << task << " -> ";
			Base::handle(task);
		}
		else
		{
			cout << "H1 handled " << task << endl;
		}
	}
};

class Handler2 :public Base
{
public:
	void handle(int task)override
	{
		if (rand() % 5 == 0)
		{
			cout << "H2 can not handle " << task << " -> ";
			Base::handle(task);
		}
		else
		{
			cout << "H2 handled " << task << endl;
		}
	}
};

class Handler3 :public Base
{
public:
	void handle(int task)override
	{
		if (rand() % 7 == 0)
		{
			cout << "H3 can not handle " << task << " -> ";
			Base::handle(task);
		}
		else
		{
			cout << "H3 handled " << task << endl;
		}
	}
};

int main()
{
	srand(time(0));
	Handler1 root;
	for (int i = 0; i < 10; i++)
	{
		switch (rand() % 3)
		{
		case 0:
			root.add(make_shared<Handler1>());
			break;
		case 1:
			root.add(make_shared<Handler2>());
			break;
		case 2:
			root.add(make_shared<Handler3>());
			break;
		}
	}

	for (int i = 0; i <10; i++)
	{
		root.handle(i);
	}

}