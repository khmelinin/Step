#include <iostream>
#include <string>
#include <vector>
#include <memory>
using namespace std;

class Game
{
public:
	void create()
	{
		cout << "Create game" << endl;
	}

	void open(const string& file)
	{
		cout << "Open game from " << file << endl;
	}

	void save(const string& file)
	{
		cout << "Save game in " << file << endl;
	}

	void make_move(const string& move)
	{
		cout << "Make move " << move << endl;
	}
};

string getPlayerInput(const string &prompt)
{
	string tmp;
	cout << prompt<<" -> ";
	getline(cin, tmp);
	return tmp;
}

class Command
{
protected:
	Game* pt;
	Command(Game* p) :pt(p) {}
public:
	virtual void execute() = 0;
	virtual ~Command() = default;
};

class CreateGameCommand :public Command
{
public:
	CreateGameCommand(Game*p):Command(p){}
	void execute()override
	{
		pt->create();
	}
};

class OpenGameCommand :public Command
{
public:
	OpenGameCommand(Game* p) :Command(p) {}
	void execute()override
	{
		string path;
		path = getPlayerInput("Enter the name of file");
		pt->open(path);
	}
};

class SaveGameCommand :public Command
{
public:
	SaveGameCommand(Game* p) :Command(p) {}
	void execute()override
	{
		string path;
		path = getPlayerInput("Enter the name of file");
		pt->save(path);
	}
};

class MakeMoveCommand :public Command
{
public:
	MakeMoveCommand(Game* p) :Command(p) {}
	void execute()override
	{
		pt->save("temp_file");
		string move;
		move = getPlayerInput("Enter the move");
		pt->make_move(move);
	}
};

class UndoCommand :public Command
{
public:
	UndoCommand(Game*p):Command(p){}
	void execute()override
	{
		pt->open("tmp_file");
	}
};

int main()
{
	Game game;
	vector<unique_ptr<Command>>v;
	v.push_back(unique_ptr<Command>(new CreateGameCommand(&game)));
	v.push_back(make_unique<MakeMoveCommand>(&game));
	v.push_back(make_unique<MakeMoveCommand>(&game));
	v.push_back(make_unique<UndoCommand>(&game));
	v.push_back(make_unique<SaveGameCommand>(&game));

	for (auto &item : v)
	{
		item->execute();
	}
}