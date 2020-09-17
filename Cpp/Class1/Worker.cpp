#include "Worker.h"

Worker::Worker(string n) :Unit(260, 30, n)
{
}

void Worker::Attack(Unit* u)
{
	srand(time(0));
	if ((rand() % 10 + 0) % 2 == 0)
	{
		passivs--;
	}
	else
	{
		u->getDamage(getAttack());
	}
}

void Worker::getDamage(int d)
{
	setHp(getHp()-d)
}
