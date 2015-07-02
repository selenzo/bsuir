#include <iostream>
#include <string>
#include <time.h> 
#include <iomanip>

using namespace std;

class Person
{
public:
	Person();
	Person(string, int, int, int);
	~Person();
	int GetHealth() { return health; };
	bool alive;
	virtual int Attack();
	virtual int Evasion(int);
protected:
	string name;
	int health;
	int strength;
	int agility;
};

class Warrior : public Person
{
public:
	Warrior();
	~Warrior();
	virtual int Evasion(int);
private:
	int shield = 5;
};

class Monster : public Person
{
public:
	Monster();
	~Monster();
	virtual int Attack();
};
