#include "Superhero.h"
using namespace std;

Superhero* Superhero::pt = nullptr;

Superhero::Superhero(string n, int a, string t)
{
	name = n;
	age = a;
	type = t;
}

Superhero* Superhero::getInstance()
{
	if (pt == nullptr)
	{
		pt = new Superhero("Vasya Pupkin", 22, "Hero");
	}
	return pt;
}

string Superhero::getName() const
{
	return name;
}

int Superhero::getAge() const
{
	return age;
}

string Superhero::getType() const
{
	return type;
}

void Superhero::setName(string n)
{
	name = n;
}

void Superhero::setAge(int a)
{
	age = a;
}

void Superhero::setType(string t)
{
	type = t;
}
