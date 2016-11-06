// lab6.cpp: определяет точку входа для консольного приложения.
//

#include "stdafx.h"

struct loop
{
	struct loop *prev = NULL;
	struct loop *next = NULL;
	int ball;
};

int _tmain(int argc, _TCHAR* argv[])
{
	loop *begin = new loop;
	begin->ball = 1;
	loop *cur = NULL;

	cur = begin;
	
	int n = 7;
	int ball = 0;
	
	//инициализируем и загоняем 1010101
	for (int i = 1; i < n; i++)
	{
		loop *tmp = new loop;
		cur->next = tmp;
		tmp->ball = ball;
		tmp->prev = cur;
		ball ^= 1;
		cur = tmp;
	}


	cout << "random: " << endl;

	cur = begin;
	while (cur != NULL)
	{
		cout << cur->ball;
		cur = cur->next;
	}
	cout << endl;

	//находим центр и на всякий случай элемент с белым шаром
	cur = begin;
	loop *tmpWhite = cur;
	int tmp = n / 2 + 1;
	while (--tmp != 0)
	{
		if (cur->ball == 1)
		{
			tmpWhite = cur;
		}
		cur = cur->next;
	}


	loop *mid = cur;
	loop *left = mid->prev;
	loop *right = mid->next;
	
	//если центр не белый меняем на найденный элемент
	if (mid->ball != 1)
	{
		tmpWhite->ball ^= mid->ball ^= tmpWhite->ball ^= mid->ball;
	}
	
	//идем в две стороны и меняем по возможности
	while (left != NULL && right != NULL)
	{
		if (left->ball == 0 && right->ball == 1)
		{
			left->ball ^= right->ball ^= left->ball ^= right->ball;
		}
		if (left->ball == 1)
		{
			left = left->prev;
		}
		if (right->ball == 0)
		{
			right = right->next;
		}
	}

	//вывод
	cur = begin;
	while (cur != NULL)
	{
		cout << cur->ball;
		cur = cur->next;
	}

	cout << endl;
	system("pause");
	return 0;
}

