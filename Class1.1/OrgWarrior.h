#pragma once
#include <string>
#include <iostream>
#include "Warrior.h"
using namespace std;
class OrgWarrior :public Warrior
{
public:
	OrgWarrior(const string& name, int hp, int maxAttack, int armor);
	~OrgWarrior() override;
	void getDamage(int val) override;
	void attack(Unit* pt) override;
};


