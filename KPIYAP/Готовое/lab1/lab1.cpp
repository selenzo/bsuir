// lab1.cpp: определяет точку входа для консольного приложения.
//

#include "stdafx.h"


int _tmain(int argc, _TCHAR* argv[])
{
	float a = 0, b = 0;
	float sum = 0;
	cin >> a >> b;
	for (int i = 1; i < 31; i++)
	{
		a = (i % 2 == 0 ? i / 2 : i);
		b = (i % 2 == 0 ? i * i * i : i * i);
		sum += (a - b) * (a - b);
	}

	cout << sum << endl;
	system("pause");
	return 0;
}

