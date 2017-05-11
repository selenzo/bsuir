// lab3.cpp: определяет точку входа для консольного приложения.
//

#include "stdafx.h"


int _tmain(int argc, _TCHAR* argv[])
{
	string str = "SHiFROVkaOtSHPIonA";
	//cin >> str;

	char ch[100];
	int chCount = 0;
	for (int i = 0; i < str.length(); i++)
	{
		char tmp = toupper(str[i]);
		if (tmp >= 'J' && tmp <= 'S')
		{
			ch[chCount++] = tmp;
		}
	}

	for (int i = 0; i < chCount - 1; i++)
	{
		for (int j = i; j < chCount; j++)
		{
			if (ch[i] > ch[j])
			{
				char tmp = ch[i];
				ch[i] = ch[j];
				ch[j] = tmp;
			}
		}
	}

	for (int i = 0; i < chCount; i++)
	{
		cout << ch[i];
	}
	cout << endl;

	system("pause");
	return 0;
}

