#pragma once
#include "GroupCreator.h"
void registerToBattle(vector<shared_ptr<Unit>>& units);
class Director
{
	shared_ptr<GroupCreator> builder;
	vector<shared_ptr<Unit>>& units;
public:
	Director(vector<shared_ptr<Unit>>& u);
	void setCreator(shared_ptr<GroupCreator> pt);
	shared_ptr<Group> make();
};