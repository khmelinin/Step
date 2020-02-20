#pragma once
#include <string>
#include <iostream>

#include "Wizard.h"
using namespace std;
class HumanWizard :public Wizard
{
public:
	HumanWizard(const string& name, int hp, int maxAttack, int dodge);
	~HumanWizard() override;
	void attack(Unit* obj) override;
	void getDamage(int val) override;
};
