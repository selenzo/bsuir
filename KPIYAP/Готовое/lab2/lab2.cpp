// lab2.cpp: определяет точку входа для консольного приложения.
//

#include "stdafx.h"


int _tmain(int argc, _TCHAR* argv[])
{
	int mas[6][6];
	int sumMain = 0;
	int sumSubMain = 0;

	for (int i = 0; i < 6; i++)
	{
		for (int j = 0; j < 6; j++)
		{
			mas[i][j] = rand() % 10;
		}
	}

	for (int i = 0; i < 6; i++)
	{
		for (int j = 0; j < 6; j++)
		{
			if (i == j)
			{
				sumMain += mas[i][j];
			}
			if (i == 5 - j)
			{
				sumSubMain += mas[i][j];
			}
		}
	}

	for (int i = 0; i < 6; i++)
	{
		for (int j = 0; j < 6; j++)
		{
			cout << mas[i][j] << " ";
		}
		cout << endl;
	}
	
	cout << "sumMain = " << sumMain << endl;
	cout << "sumSubMain = " << sumSubMain << endl;
	cout << "average main = " << sumMain / 6 << endl;
	cout << "average subMin = " << sumSubMain / 6 << endl;

	system("pause");
	return 0;
}

