#pragma once
#include <iostream>
#include <string>
#include <vector>
#include "User.h"
using namespace std;

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