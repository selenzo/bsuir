#include <iostream>
#include <string.h>

using namespace std;

class Person
{
public:
	Person();
	~Person();
	string fio;
	int age;
	string gender;
private:

};

int ManCout(Person* persons, int size);
double AverageAge(Person* persons, int size);
