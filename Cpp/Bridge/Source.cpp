#include <iostream>
#include <string>

using namespace std;

class Subject
{
public:
    virtual void BuildWall() = 0;

    virtual void BuildWallWithDoor() = 0;

    virtual void BuildWallWithWindow() = 0;

    virtual ~Subject() = default;
};

class SubjectLection : public Subject
{
public:
    void BuildSubjectect() override
    {
        cout << "Creating brick wall" << endl;
    }

    void BuildWallWithDoor() override
    {
        cout << "Creating brick wall with door" << endl;
    }

    void BuildWallWithWindow() override
    {
        cout << "Creating brick wall with window" << endl;
    }
};

class SubjectPractise : public Subject
{
public:
    void BuildSubject() override
    {
        cout << "Creating concrete wall" << endl;
    }

    void BuildWallWithDoor() override
    {
        cout << "Creating concrete wall with door" << endl;
    }

    void BuildWallWithWindow() override
    {
        cout << "Creating concrete wall with window" << endl;
    }
};


class Table
{
    Subject* WallCreator=nullptr;
public:

    virtual void BuildFoundation() = 0;

    virtual void BuildRoom() = 0;

    virtual void BuildRoof() = 0;

    virtual ~Table() = default;

    Subject* getWallCreator() const
    {
        return WallCreator;
    }

    void setWallCreator(IWallCreator* WallCreator)
    {
        this->WallCreator = WallCreator;
    }
};

class BuldingCompany : public Table
{
public:
    void BuildFoundation() override
    {
        cout << "Foundation is built." << endl;

    }

    void BuildRoom() override
    {
        getWallCreator()->BuildWallWithDoor();
        getWallCreator()->BuildWall();
        getWallCreator()->BuildWallWithWindow();
        getWallCreator()->BuildWall();
        cout << "Room finished." << endl;
    }

    void BuildRoof() override
    {
        cout << "Roof is done." << endl;
    }
};

class NearSeaBuldingCompany : public Table
{
public:
    void BuildFoundation() override
    {
        cout << "Foundation near sea is built." << endl;

    }

    void BuildRoom() override
    {
        getWallCreator()->BuildWallWithDoor();
        getWallCreator()->BuildWall();
        getWallCreator()->BuildWallWithWindow();
        getWallCreator()->BuildWall();
        cout << "Room near sea finished." << endl;
    }

    void BuildRoof() override
    {
        cout << "Roof near sea is done." << endl;
    }
};

int main()
{
    SubjectLection* bwc = new SubjectLection();
    SubjectPractise* cwc = new SubjectPractise();
    Table* bc = new BuldingCompany();
    bc->setWallCreator(bwc);
    bc->BuildFoundation();
    bc->BuildRoom();
    bc->BuildRoof();
    delete bc;
    bc = new NearSeaBuldingCompany();
    bc->setWallCreator(cwc);
    bc->BuildFoundation();
    bc->BuildRoom();
    bc->BuildRoof();
    delete bc;
    delete bwc;
    delete cwc;


}
