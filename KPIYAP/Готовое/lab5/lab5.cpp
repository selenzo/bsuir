// lab5.cpp: определяет точку входа для консольного приложения.
//

#include "stdafx.h"


int _tmain(int argc, _TCHAR* argv[])
{
	ifstream input("input.txt");
	ofstream output("output.txt");

	int mas[20];
	int count = -1;

	while (input >> mas[++count]);

	for (int i = 0; i < count; i++)
	{
		if (i == 0)
		{
			output << mas[i] << " ";
		} 
		else
		{
			bool tmp = true;
			for (int j = 0; j < i; j++)
			{
				if (mas[j] == mas[i])
				{
					tmp = false;
				}
			}
			if (tmp)
			{
				output << mas[i] << " ";
			}
		}
	}

	output.close();
	input.close();
	return 0;
}

