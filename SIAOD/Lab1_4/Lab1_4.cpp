// Lab1_4.cpp: определяет точку входа для консольного приложения.
//

#include "stdafx.h"

struct Node
{
	int phone = NULL;
	struct Node * parent = NULL;
	struct Node * next = NULL;
};

struct Node2
{
	int phone;
	struct Node2 * next;
};

void AddNode2(struct Node2 &cur, int number)
{
	if (cur.phone == NULL)
	{
		cur.phone = number;
	}
	else
	{
		int tmp = number;
		if (cur.phone > number)
		{
			tmp = cur.phone;
			cur.phone = number;
		}
		if (cur.next == NULL)
		{
			cur.next = new Node2();
		}
		AddNode2(*cur.next, tmp);
	}
}

void AddNode(struct Node &cur, int number)
{
	if (cur.phone == NULL)
	{
		cur.phone = number;
	}
	else
	{
		if (cur.next == NULL)
		{
			cur.next = new Node();
			cur.next->parent = &cur;
		}
		AddNode(*cur.next, number);
	}
}

void ViewF(struct Node &begin)
{
	cout << begin.phone << " \n";
	if (begin.next != NULL)
	{
		ViewF(*begin.next);
	}
}

void ViewB(struct Node &end)
{
	cout << end.phone << " \n";
	if (end.parent != NULL)
	{
		ViewB(*end.parent);
	}
}

struct Node * SearchLast(struct Node &begin)
{
	return (begin.next != NULL ? SearchLast(*begin.next) : &begin);
}

void AddQueue(struct Node &begin, struct Node2 &begin2)
{
	while (begin.next != NULL)
	{
		if (begin.phone > 999)
		{
			AddNode2(begin2, begin.phone);
		}
		begin = *begin.next;
	}
}

void ViewNode2(struct Node2 &begin)
{
	cout << begin.phone << " \n";
	if (begin.next!= NULL)
	{
		ViewNode2(*begin.next);
	}
	
}

int _tmain(int argc, _TCHAR* argv[])
{
	struct Node *begin = new Node();
	struct Node2 *begin2 = new Node2();

	AddNode(*begin, 102);
	AddNode(*begin, 6547821);
	AddNode(*begin, 101);
	AddNode(*begin, 1234568);
	AddNode(*begin, 103);
	AddNode(*begin, 2020327);
	AddNode(*begin, 104);

	struct Node * last = new Node();
	last = SearchLast(*begin);

	cout << "L -> R" << endl;
	ViewF(*begin);
	cout << endl << "R -> L" << endl;
	ViewB(*last);

	cout << endl << "Phone numbers" << endl;
	AddQueue(*begin, *begin2);
	ViewNode2(*begin2);

	system("pause");
	return 0;
}

