#include "Adapter.h"

Adapter::Adapter(OldElectricitySystem* pt)
{
	adaptee = pt;
}

int Adapter::wideSocket()
{
	return adaptee->ThinSocket();
}
