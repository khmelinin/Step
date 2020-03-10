#include <iostream>
#include <string>
#include <vector>
using namespace std;



class User
{
	string name;
public:
	User() = default;
	User(const string& n)
	{
		name = n;
	}
	virtual void Update() = 0;
	~User() = default;

};

class UserMobile:public User
{
public:
	UserMobile() = default;
	UserMobile(const string& n) :User(n) {};
	void Update()override
	{
		cout << "Mobile" << endl;
	}
};

class UserDesktop:public User
{
public:
	UserDesktop() = default;
	UserDesktop(const string& n) :User(n) {};
	void Update()override
	{
		cout << "Desktop" << endl;
	}
};

class UserWeb:public User
{
public:
	UserWeb() = default;
	UserWeb(const string& n) :User(n) {};
	void Update()override
	{
		cout << "Mobile" << endl;
	}
};

class Chat
{
	int size = 0;
	User* s = nullptr;
public:
	Chat() = default;
	Chat(UserMobile *pt)
	{
		size++;
		s = new UserMobile[size];
		s = pt;
	}

	Chat(UserDesktop *pt)
	{
		size++;
		s = new UserDesktop[size];
		s = pt;
	}

	Chat(UserWeb *pt)
	{
		size++;
		s = new UserWeb[size];
		s= pt;
	}

	void addUser(UserMobile *pt)
	{
		size++;
		s = pt;
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
	UserMobile user;
	Chat publisher;
	publisher.addUser(&user);
	publisher.Notify();
}