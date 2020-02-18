#include "Building.h"
#include <time.h>
Warrior* Building::CreateWarrior()
{
	string n;
	srand(time(0));
	char a;
	for (int i = 0; i < rand() % 10 + 0; i++)
	{

		a = rand() % 60 + 30;
		n += a;
	}
	return new Warrior(n);
}
