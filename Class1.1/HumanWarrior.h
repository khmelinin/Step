#pragma once
#include <string>
#include <iostream>
#include "Warrior.h"
using namespace std;
class HumanWarrior :public Warrior
{
public:
	HumanWarrior(const string& name, int hp, int maxAttack, int armor);
	~HumanWarrior() override;
	void getDamage(int val) override;
	void attack(Unit* pt) override;
};


