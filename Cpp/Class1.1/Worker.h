#pragma once
#include <string>
#include "Unit.h"
#include <iostream>
using namespace std;
class Worker:public Unit
{
protected:
	int passive=0;
public:
	Worker(const string& name, int hp, int maxAtack, int passive);

	~Worker() override;
};

