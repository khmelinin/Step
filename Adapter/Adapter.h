#pragma once
#include "OldElectricitySystem.h"
#include "AbstractElectricitySystem.h"
class Adapter: public AbstractElectricitySystem
{
	OldElectricitySystem *adaptee;
public:
	Adapter(OldElectricitySystem*pt);
	int wideSocket()override;
};

