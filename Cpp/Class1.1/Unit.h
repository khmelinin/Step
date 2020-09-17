#pragma once
#include <string>
#include <iostream>
using namespace std;
class Unit {
protected:
	int hp = 0;
	int maxAttack = 0;
	string name;
public:
	Unit() = default;
	Unit(const string& name, int hp, int maxAtack);
	virtual ~Unit();
	virtual void attack(Unit* obj)=0;
	virtual void getDamage(int val) = 0;
	const string& getName()const;
	int getMaxAttack()const;
	int getHp()const;
	void setName(const string name);
	void setHp(int hp);
	void setMaxAttack(int maxAttack);

};
