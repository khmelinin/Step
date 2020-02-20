#pragma once
#include <string>
#include "Worker.h"
#include <iostream>
using namespace std;
class HumanWorker :public Worker
{

public:
	HumanWorker(const string& name, int hp, int maxAtack, int passive);
	void attack(Unit* obj)override;
	void getDamage(int val)override;
	~HumanWorker() override;
};

