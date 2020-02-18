#pragma once
#include <iostream>
#include <string>
using namespace std;

class Superhero
{
	static Superhero* pt;
	string name;
	int age=0;
	string type;
	Superhero(string n, int a, string t);
public:
	static Superhero* getInstance();
	string getName()const;
	int getAge()const;
	string getType()const;
	void setName(string n);
	void setAge(int a);
	void setType(string t);

};

