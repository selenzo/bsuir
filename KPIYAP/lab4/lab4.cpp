// lab4.cpp: определяет точку входа для консольного приложения.
//

#include "stdafx.h"

struct student
{
	string fam;;
	int group;
	bool obj;
};



int _tmain(int argc, _TCHAR* argv[])
{
	const int count = 3;
	student std[count];
	std[0].fam = "Petrov";
	std[0].group = 123;
	std[0].obj = true;

	std[1].fam = "Sidorov";
	std[1].group = 123;
	std[1].obj = false;

	std[2].fam = "Ivanov";
	std[2].group = 123;
	std[2].obj = true;

	for (int i = 0; i < count - 1; i++)
	{
		for (int j = i; j < count; j++)
		{
			if (std[i].fam > std[j].fam)
			{
				student tmp;
				tmp = std[i];
				std[i] = std[j];
				std[j] = tmp;
			}
		}
	}

	int tmCount = 0;
	for (int i = 0; i < count; i++)
	{
		if (std[i].obj)
		{
			for (int j = 0; j < std[i].fam.length(); j++)
			{
				cout << std[i].fam[j];
			}
			cout << " " << std[i].group << endl;

		}
	}

	system("pause");
	return 0;
}

