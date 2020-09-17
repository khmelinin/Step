#include <iostream>
#include "OldElectricitySystem.h"
#include "NoteBook.h"
#include "NewElectricitySystem.h"
using namespace std;

int main()
{
	NewElectricitySystem obj(220);
	NoteBook laptop;
	laptop.Charge(&obj);
	OldElectricitySystem old_obj(299);
	Adapter adapter(&old_obj);
	laptop.Charge(&adapter);
}