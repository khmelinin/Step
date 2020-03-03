#include <iostream>
#include <string>
using namespace std;

class CompressStrategy
{
public:
	virtual ~CompressStrategy() = default;
	virtual void Compress(const string &s) = 0;
};

class Rar:public CompressStrategy
{
public: 
	void Compress(const string& s)override
	{
		string str = s;
		int pos = str.rfind(".");
		if (pos != -1)
			str = str.substr(0, pos + 1) + "rar";
		else
			str = str + ".rar";
		cout << "Rarred" << endl;
	}
};

class Zip :public CompressStrategy
{
public:
	void Compress(const string &s)override
	{
		string str = s;
		int pos = str.rfind(".");
		if (pos != -1)
			str = str.substr(0, pos + 1) + "zip";
		else
			str = str + ".zip";
		cout << "Zipped" << endl;
	}
};

class Gzip :public CompressStrategy
{
public:
	void Compress(const string& s)override
	{
		string str = s;
		int pos = str.rfind(".");
		if (pos != -1)
			str = str.substr(0, pos + 1) + "gzip";
		else
			str = str + ".gzip";
		cout << "Gzipped" << endl;
	}
};

class Archiver
{
	CompressStrategy* p = nullptr;
public:
	Archiver(CompressStrategy*comp):p(comp){}
	~Archiver() { delete p; }
	void compress(const string& name)
	{
		p->Compress(name);
	}
	void setStrategy(CompressStrategy* pt)
	{
		delete p;
		p = pt;
	}
};


int main()
{
	Archiver* p = new Archiver(new Zip);
	p->compress("ios.txt");
	p->setStrategy(new Rar);
	p->compress("ios.txt");
	delete p;
}