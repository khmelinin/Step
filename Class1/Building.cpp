#include "Building.h"
#include <time.h>
string Building::Name()
{
	string n;
	srand(time(0));
	char a;
	for (int i = 0; i < rand() % 10 + 0; i++)
	{

		a = rand() % 60 + 30;
		n += a;
	}
	return n;
}
Warrior* Building::CreateWarrior()
{
	return new Warrior(Name());
}

Wizzard* Building::CreateWizzard()
{
	return new Wizzard(Name());
}

Worker* Building::CreateWorker()
{
	return new Worker(Name());
}
