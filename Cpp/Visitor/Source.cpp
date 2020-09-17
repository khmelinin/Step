#include<iostream>
#include<cmath>
#include <iomanip>
using namespace std;
class Article1;
class Article2;
class Article3;

class Visitor
{
public:
    virtual void visit(Article1* pt) = 0;
    virtual void visit(Article2* pt) = 0;
    virtual void visit(Article3* pt) = 0;
    virtual ~Visitor() = default;
};


class Article
{
public:
    virtual void accept(Visitor* pt) = 0;
    virtual ~Article() = default;
};

class Article1
{
    int amount;
    double price;
public:

    Article1(int a, double p)
    {
        amount = a;
        price = p;
    }
    void accept(Visitor* pt)
    {
        pt->visit(this);
    }

    int getAmount() const
    {
        return amount;
    }

    void setAmount(int amount)
    {
        Article1::amount = amount;
    }

    double getPrice() const
    {
        return price;
    }

    void setPrice(double price)
    {
        Article1::price = price;
    }

};
class Article2
{
    int amount;
    double price;
public:

    Article2(int a, double p)
    {
        amount = a;
        price = p;
    }
    void accept(Visitor* pt)
    {
        pt->visit(this);
    }
    int getAmount() const
    {
        return amount;
    }

    void setAmount(int amount)
    {
        Article2::amount = amount;
    }

    double getPrice() const
    {
        return price;
    }

    void setPrice(double price)
    {
        Article2::price = price;
    }

};
class Article3
{
    int amount;
    double price;
public:

    Article3(int a, double p)
    {
        amount = a;
        price = p;
    }
    void accept(Visitor* pt)
    {
        pt->visit(this);
    }
    int getAmount() const
    {
        return amount;
    }

    void setAmount(int amount)
    {
        Article3::amount = amount;
    }

    double getPrice() const
    {
        return price;
    }

    void setPrice(double price)
    {
        Article3::price = price;
    }

};

class Cost :public Visitor
{
    double cost;
public:

    double getCost() const
    {
        return cost;
    }
    void visit(Article1* pt)override
    {
        cost = pt->getAmount() * pt->getPrice();
    }
    void visit(Article2* pt)override
    {
        cost = pt->getAmount() * pt->getPrice();
    }
    void visit(Article3* pt)override
    {
        cost = pt->getAmount() * pt->getPrice();
    }
};

int main()
{
    Article1 a1(2, 45);
    Article2 a2(3, 4.5);
    Article3 a3(12, 5);
    Cost c;
    a1.accept(&c);
    cout << c.getCost() << endl;
    a2.accept(&c);
    cout << c.getCost() << endl;
    a3.accept(&c);
    cout << c.getCost() << endl;
}