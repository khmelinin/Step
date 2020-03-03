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
	PizzaL* c = new PizzaL();
	c->info();
	WithMeat* cwm = new WithMeat(c);
	WithMeat* cwmm = new WithMeat(cwm);
	cwmm->info();
	WithMushrooms* cwmms = new WithMushrooms(cwmm);
	cwmms->info();
	WithMoreCheese* cwmmsc = new WithMoreCheese(cwmm);
	cwmmsc->info();
	WithPineapple* cwmmsca = new WithPineapple(cwmm);
	cwmmsca->info();
	cout << cwmmsca->cost() << endl;

}