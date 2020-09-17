#pragma once
#include <string>
#include <iostream>

#include "Wizard.h"
using namespace std;
class OrgWizard :public Wizard
{
public:
	OrgWizard(const string& name, int hp, int maxAttack, int dodge);
	~OrgWizard() override;
	void attack(Unit* obj) override;
	void getDamage(int val) override;
};
