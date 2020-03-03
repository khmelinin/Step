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
	vector<SubscriberMobile> m;
	vector<SubscriberDesktop> d;
	vector<SubscriberWeb> w;
public:
	Publisher() = default;
	void addSubscriber(SubscriberMobile pt)
	{
		m.push_back(pt);
	}
	void Notify()
	{
		for (int i = 0; i < m.size; i++)
		{
			m[i].Update();
		}
		for (int i = 0; i < d.size; i++)
		{
			d[i].Update();
		}
		for (int i = 0; i < w.size; i++)
		{
			w[i].Update();
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