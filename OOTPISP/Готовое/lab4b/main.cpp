#include "main.h"


int main(int argc, char *argv[])
{
	srand(time(NULL));
	Warrior w;
	Monster m;
	int tmp1, tmp2;
	while (m.alive && w.alive)
	{
		tmp1 = w.Attack();
		tmp2 = m.Attack();

		cout << "Warrior attack " << setw(2) << tmp1 << " " << "Monster attack " << setw(2) << tmp2 << endl;
		tmp1 = m.Evasion(tmp1);
		tmp2 = w.Evasion(tmp2);

		cout << "Monster block  " << setw(2) << tmp2 << " " << "Warrior block  " << setw(2) << tmp1 << endl;

		cout << "Monster health " << setw(2) << m.GetHealth() << " " << "Warrior health " << setw(2) << w.GetHealth() << endl;
		cout << endl;
	}

	system("pause");
	return 0;
}

Person::Person()
{
	name = "Person";
	health = 100;
	strength = 20;
	agility = 25;
	alive = true;
}

Person::Person(string n, int h, int s, int a)
{
	name = n;
	health = h;
	strength = s;
	agility = a;
	alive = true;
}

Person::~Person()
{

}

int Person::Attack()
{
	int a = rand() % strength;
	return strength - a;
}

int Person::Evasion(int attack)
{
	int b = (agility - rand() % agility);
	int a = attack - b;
	health -= (a > 0 ? a : 0);
	if (health < 0) alive = false;
	return b;
}

Warrior::Warrior()
{

}

Warrior::~Warrior()
{

}

int Warrior::Evasion(int attack)
{
	int b = (agility - rand() % agility);
	int a = attack - b - shield;
	health -= (a > 0 ? a : 0);
	if (health < 0) alive = false;
	return b;
}

Monster::Monster()
{

}

Monster::~Monster()
{

}

int Monster::Attack()
{
	int a = (rand() % strength);
	return (strength -  a + 5);
}
