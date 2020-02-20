#include "OrgWorker.h"

OrgWorker::OrgWorker(const string& name, int hp, int maxAttack, int passive) : Worker(name, hp, maxAttack, passive)
{
}

void OrgWorker::attack(Unit* obj)
{
	if (rand() % 101 > passive)
	{
		int tmp = rand() % maxAttack + 1;
		cout << name << " is attacking: " << tmp << endl;
		obj->getDamage(tmp);
	}

}

void OrgWorker::getDamage(int val)
{

	hp -= val;
	if (hp <= 0)
		cout << "OrgWorker die" << endl;
	else cout << "Hp: " << hp << endl;

	
}

OrgWorker::~OrgWorker()
{
	cout << "~OrgWorker()" << endl;
}

