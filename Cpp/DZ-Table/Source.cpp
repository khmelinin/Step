#include <iostream>
#include <string>

using namespace std;

class Subject
{
public:
    virtual void BuildSubject() = 0;

    

    virtual ~Subject() = default;
};

class SubjectLection : public Subject
{
public:
    void BuildSubject() override
    {
        cout << "Creating brick wall" << endl;
    }

   
};

class SubjectPractise : public Subject
{
public:
    void BuildSubject() override
    {
        cout << "Creating concrete wall" << endl;
    }

    
};


class Table
{
    Subject* WallCreator = nullptr;
public:

    virtual void BuildFoundation() = 0;

    virtual void BuildRoom() = 0;

    virtual void BuildRoof() = 0;

    virtual ~Table() = default;

    Subject* getWallCreator() const
    {
        return WallCreator;
    }

    void setWallCreator(Subject* WallCreator)
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
       
        getWallCreator()->BuildSubject();
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
        getWallCreator()->BuildSubject();
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
