#include <iostream>
#include <string>
#include <vector>
using namespace std;



class Subscriber
{
	string name;
public:
	Subscriber() = default;
	Subscriber(const string& n)
	{
		name = n;
	}
	virtual void Update() = 0;
	~Subscriber() = default;

};

class SubscriberMobile:public Subscriber
{
public:
	SubscriberMobile() = default;
	SubscriberMobile(const string& n) :Subscriber(n) {};
	void Update()override
	{
		cout << "Mobile" << endl;
	}
};

class SubscriberDesktop:public Subscriber
{
public:
	SubscriberDesktop() = default;
	SubscriberDesktop(const string& n) :Subscriber(n) {};
	void Update()override
	{
		cout << "Desktop" << endl;
	}
};

class SubscriberWeb:public Subscriber
{
public:
	SubscriberWeb() = default;
	SubscriberWeb(const string& n) :Subscriber(n) {};
	void Update()override
	{
		cout << "Mobile" << endl;
	}
};

class Publisher
{
	int size = 0;
	Subscriber* s = nullptr;
public:
	Publisher() = default;
	Publisher(SubscriberMobile pt)
	{
		size++;
		s = new SubscriberMobile[size];
		s[0] = pt;
	}

	Publisher(SubscriberDesktop pt)
	{
		size++;
		s = new SubscriberDesktop[size];
		s[0] = pt;
	}

	Publisher(SubscriberWeb pt)
	{
		size++;
		s = new SubscriberWeb[size];
		s[0] = pt;
	}

	void addSubscriber(SubscriberMobile pt)
	{
		size++;
		s[size] = pt;
	}
	
	void Notify()
	{
		for (int i = 0; i < size; i++)
		{
			s[i].Update();
		}
		for (int i = 0; i < size; i++)
		{
			s[i].Update();
		}
		for (int i = 0; i < size; i++)
		{
			s[i].Update();
		}
	}
};

int main()
{
	SubscriberMobile user;
	Publisher publisher;
	publisher.addSubscriber(user);
	publisher.Notify();
}