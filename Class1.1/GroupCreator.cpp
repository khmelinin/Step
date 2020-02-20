#include "GroupCreator.h"


GroupCreator::GroupCreator(vector<shared_ptr<Unit>>& u):units(u)
{
}

shared_ptr<Group> GroupCreator::getGroup() const
{
	return group;
}

GroupCreator::~GroupCreator() = default;
