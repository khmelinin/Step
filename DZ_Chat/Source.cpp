//#include <iostream>
//#include <string>
//#include <vector>
//using namespace std;
//
//
//
//class User
//{
//	string name;
//public:
//	User() = default;
//	User(const string& n)
//	{
//		name = n;
//	}
//	virtual void Update() = 0;
//	~User() = default;
//	
//
//};
//
//class UserMobile :public User
//{
//public:
//	UserMobile() = default;
//	UserMobile(const string& n) :User(n) {};
//	void Update()override
//	{
//		cout << "Mobile" << endl;
//	}
//};
//
//class UserDesktop :public User
//{
//public:
//	UserDesktop() = default;
//	UserDesktop(const string& n) :User(n) {};
//	void Update()override
//	{
//		cout << "Desktop" << endl;
//	}
//};
//
//class UserWeb :public User
//{
//public:
//	UserWeb() = default;
//	UserWeb(const string& n) :User(n) {};
//	void Update()override
//	{
//		cout << "Mobile" << endl;
//	}
//};
//
//class Chat
//{
//	int size = 0;
//	User* s = nullptr;
//public:
//	Chat() = default;
//	Chat(UserMobile* pt)
//	{
//		size++;
//		s = new UserMobile[size];
//		s = pt;
//	}
//
//	Chat(UserDesktop* pt)
//	{
//		size++;
//		s = new UserDesktop[size];
//		s = pt;
//	}
//
//	Chat(UserWeb* pt)
//	{
//		size++;
//		s = new UserWeb[size];
//		s = pt;
//	}
//
//	void addUser(UserMobile* pt)
//	{
//		size++;
//		s = pt;
//	}
//
//	void Notify()
//	{
//		for (int i = 0; i < size; i++)
//		{
//			s[i].Update();
//		}
//		for (int i = 0; i < size; i++)
//		{
//			s[i].Update();
//		}
//		for (int i = 0; i < size; i++)
//		{
//			s[i].Update();
//		}
//	}
//};
//
//int main()
//{
//	UserMobile user;
//	Chat chat;
//	chat.addUser(&user);
//	chat.Notify();
//}

#include <iostream>
#include <string>
#include <vector>
using namespace std;

class Chat;
class User;

class User
{
	string name;
public:
	User() = default;
	User(const string& s)
	{
		name = s;
	}
	void Read(const string &s)
	{
		cout << s << endl;
	}

	void Write(const string& s, Chat &a)
	{
		a.Print(s);
	}
};

class Chat
{
	vector <User> s;
public:
	Chat() = default;
	Chat(User a)
	{
		s.push_back(a);
	}
	~Chat()
	{
		s.clear();
	}
	void addUser(User a)
	{
		s.push_back(a);
	}
	void Print(const string s)
	{
		for (int i = 0; i < s.size(); i++)
		{
			this->s[i].Read(s);
		}
	}
};

int main()
{
	User a("A");
	User b("B");
	Chat aa(a);
	aa.addUser(b);
}