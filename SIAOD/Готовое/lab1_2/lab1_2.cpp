// lab1_2.cpp: определяет точку входа для консольного приложения.
//

#include "stdafx.h"

struct Node
{
	int number;
	struct Node * next;
};

void AddNode(struct Node &begin, struct Node &cur, int val, int max)
{
	if (val < max)
	{
		cur.number = val;
		cur.next = new Node();
		AddNode(begin, *cur.next, ++val, max);
	}
	else
	{
		cur.number = val;
		cur.next = &begin;
	}
}

int Resh(int N, int k)
{
	struct Node * begin = new Node();
	struct Node * tmp;
	tmp = begin;


	AddNode(*tmp, *tmp, 1, N);

	int n = k;

	if (n == 1)
	{
		return N;
	}

	while (tmp->next != tmp)
	{
		int temp = n - 1;
		while (--temp)
		{
			tmp = tmp->next;
		}
		tmp->next = tmp->next->next;
		tmp = tmp->next;

		struct Node * t;
		t = tmp;
		t = t->next;
		while (t != tmp)
		{
			t = t->next;
		}
		
	}
	return tmp->number;
}

int ReshOsn(int N, int k)
{
	struct Node * begin = new Node();
	struct Node * tmp;
	tmp = begin;


	AddNode(*tmp, *tmp, 1, N);

	int n = k;

	if (n == 1)
	{
		return N;
	}

	while (tmp->next != tmp)
	{
		int temp = n - 1;
		while (--temp)
		{
			tmp = tmp->next;
		}
		printf("Delete %d, ", tmp->next->number);
		tmp->next = tmp->next->next;
		tmp = tmp->next;

		struct Node * t;
		t = tmp;
		printf("%d ", t->number);
		t = t->next;
		while (t != tmp)
		{
			printf("%d ", t->number);
			t = t->next;
		}
		printf("\n");

	}
	return tmp->number;
}

int _tmain(int argc, _TCHAR* argv[])
{
	int k;
	printf("Input k = ");
	scanf("%d", &k);
	printf("Last = %d\n", ReshOsn(20, k));
	
	for (int i = 1; i < 65; i++)
	{
		printf("N = %d, Last = %d\n", i, Resh(i, k));
	};
	
	system("pause");
	return 0;
}

