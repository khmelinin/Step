#pragma once
#include <string>
#include <iostream>

#include "Unit.h"
using namespace std;
class Wizard :public Unit
{
protected:
	int dodge = 0;
	
public:
	Wizard(const string& name, int hp, int maxAttack, int dodge);
	~Wizard() override;

};
