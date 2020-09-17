#include "Superhero.h"
using namespace std;

int main()
{
	Superhero* hero1 = Superhero::getInstance();
	Superhero* hero2 = Superhero::getInstance();

	hero1->setName("Hero");
	cout << hero2->getName() << endl;

}