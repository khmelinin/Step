#pragma once
#include <string>
#include <iostream>
#include "Unit.h"
using namespace std;
class Warrior :public Unit
{
protected:
	int armor=50;
public:
	Warrior( const string& name,int hp,int maxAttack,int armor);
	~Warrior() override;
	int getArmor()const;
	void setArmor(int armor);
};


