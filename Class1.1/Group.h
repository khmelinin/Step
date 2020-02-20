#pragma once
#include <vector>
#include <memory>
#include <string>
#include "Unit.h"
//#include "../AbstractFactory/Unit.h"

using namespace std;

class Group
{
	string title;
	string type;
	vector <shared_ptr<Unit>> group;
public:
	Group(const string& _title, const string& _type);
	const string &getTitle()const;
	const string &getType()const;
	void setTitle(const string& _title);
	void setType(const string& _type);
};

