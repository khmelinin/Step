#pragma once
#include <iostream>
#include <string>
#include "Chat.h"

using namespace std;
class User
{
	string name;
public:
	User() = default;
	User(const string& s)
	{
		name = s;
	}
	void Read(const string& s)
	{
		cout << s << endl;
	}

	void Write(const string& s, Chat& a)
	{
		a.Print(s);
	}
};