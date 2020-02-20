#include "Worker.h"



Worker::Worker(const string& name, int hp, int maxAttack, int passive):Unit(name,hp,maxAttack)
{
	this->passive = passive;
}



Worker::~Worker()
{
	cout<<"~Worker()" << endl;
}
