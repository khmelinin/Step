#include <iostream>
#include "Pizza_S.h"
#include "Pizza_M.h"
#include "Pizza_L.h"
#include "With_Meat.h"
#include "With_More_Cheese.h"
#include "With_Mushrooms.h"
#include "With_Pineapple.h"
using namespace std;


int main()
{
	PizzaL* p = new PizzaL();
	p->info();
	WithMeat* cm = new WithMeat(p);
	WithMeat* cmm = new WithMeat(cm);
	cmm->info();
	WithMushrooms* cwmms = new WithMushrooms(cmm);
	cwmms->info();
	WithMoreCheese* cwmmsc = new WithMoreCheese(cwmms);
	cwmmsc->info();
	WithPineapple* cwmmsca = new WithPineapple(cwmmsc);
	cwmmsca->info();
	cout << cwmmsca->cost() << endl;

}