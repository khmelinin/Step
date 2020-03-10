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
		cout <<"to User-> "<<name<<": "<< s << endl;
	}

	const string& Write(const string& s)
	{
		return s;
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
	void Print(const string &s)
	{
		for (int i = 0; i < this->s.size(); i++)
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
	aa.Print(a.Write("Hello"));
}