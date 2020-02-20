#include "HumanWorker.h"


HumanWorker::HumanWorker(const string& name, int hp, int maxAttack, int passive) : Worker(name, hp, maxAttack,passive)
{
}

void HumanWorker::attack(Unit* obj)
{
	if (rand() % 101 > passive)
	{
		int tmp = rand() % maxAttack + 1;
		cout << name << " is attacking: " << tmp << endl;
		obj->getDamage(tmp);
	}

}

void HumanWorker::getDamage(int val)
{

	hp -= val;
	if (hp <= 0)
		cout << "OrgWorker die" << endl;
	else cout << "Hp: " << hp << endl;

}

HumanWorker::~HumanWorker()
{
	cout << "~HumanWorker()" << endl;
}

