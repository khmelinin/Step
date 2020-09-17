#pragma once
#include "AbstractElectricitySystem.h"
class NewElectricitySystem: public AbstractElectricitySystem
{
	int v;
public:
	NewElectricitySystem(int vv);
	int wideSocket()override;
};

