#include "main.h"

int main(int argc, char *argv[])
{
	int size = 5;
	Person *persons = new Person[size];

	persons[0].age = 20;
	persons[0].fio = "Ivanov";
	persons[0].gender = "male";

	persons[1].age = 10;
	persons[1].fio = "Ivanova";
	persons[1].gender = "female";

	persons[2].age = 30;
	persons[2].fio = "Petrov";
	persons[2].gender = "male";

	persons[3].age = 40;
	persons[3].fio = "Sidorova";
	persons[3].gender = "female";

	persons[4].age = 25;
	persons[4].fio = "Genadiev";
	persons[4].gender = "male";


	cout << "man count: " << ManCout(persons, size) << endl;
	cout << "average age: " << AverageAge(persons, size) << endl;

	system("pause");
	return 0;
}

double AverageAge(Person* persons, int size)
{
	double temp = 0;
	for (int i = 0; i < size; i++)
	{
		temp += persons[i].age;
	}
	return temp / 5;
}

int ManCout(Person* persons, int size)
{
	int temp = 0;
	for (int i = 0; i < size; i++)
	{
		if (persons[i].gender == "male") temp++;
	}
	return temp;
}

Person::Person()
{

}
Person::~Person()
{

}
