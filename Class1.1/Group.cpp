#include "Group.h"

Group::Group(const string& _title, const string& _type)
{
	title = _title;
	type = _type;
}

const string& Group::getTitle() const
{
	return title;
}

const string& Group::getType() const
{
	return type;
}

void Group::setTitle(const string& _title)
{
	title = _title;
}

void Group::setType(const string& _type)
{
	type = _type;
}
