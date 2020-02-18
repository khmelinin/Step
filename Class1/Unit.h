#pragma once
#include <iostream>
#include <string>
using namespace std;

class Unit
{
	int hp=0;
	int attack=0;
	string name="n0l'";
public:
	Unit() = default;
	Unit(int h, int a, string n);
	virtual void Attack(Unit* u);
	virtual void getDamage(int damage);
	int getHp()const;
	void setHp(int h);
	string getName()const;
	void setName(string n);
	int getAttack();
	virtual ~Unit();

};

