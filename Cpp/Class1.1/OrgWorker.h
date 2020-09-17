#pragma once
#include <string>
#include "Worker.h"
#include <iostream>
using namespace std;
class OrgWorker :public Worker
{

public:
	OrgWorker(const string& name, int hp, int maxAtack, int passive);
	void attack(Unit* obj)override;
	void getDamage(int val)override;
	~OrgWorker() override;
};

