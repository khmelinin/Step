#pragma once
#include <iostream>
#include <string>
using namespace std;

class Unit
{
	int hp;
	int attack;
	string name;
public:
	virtual void Attack(Unit u);
	virtual void getDamage(int damage);
	int getHp()const;
	void setHp(int h);
	string getName()const;
	void setName(string n);

};

