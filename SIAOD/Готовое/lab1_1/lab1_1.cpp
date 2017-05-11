// lab1_1.cpp: определяет точку входа для консольного приложения.
//

#include "stdafx.h"

struct Node {
	int valueA = NULL;
	int valueX = NULL;
	struct Node* next = NULL;
};

void AddNode(int valueA, int valueX, struct Node &cur)
{
	if (cur.next == NULL)
	{
		if (cur.valueA == NULL && cur.valueX == NULL)
		{
			cur.valueA = valueA;
			cur.valueX = valueX;
		}
		else
		{
			cur.next = new Node();
			AddNode(valueA, valueX, *cur.next);
		}
	}
	else
	{
		AddNode(valueA, valueX, *cur.next);
	}
};

float Meaning(struct Node &cur, int x)
{
	float a = cur.valueA * pow((double)x, cur.valueX);
	return (cur.next == NULL ? a : Meaning(*cur.next, x) + a);
}

bool Equality(struct Node &P, struct Node &Q, int x)
{
	return (Meaning(P, x) == Meaning(Q, x));
}

void Add(struct Node &P, struct Node &Q, struct Node &R)
{
	if (P.next != NULL && Q.next != NULL)
	{
		R.valueA = P.valueA + Q.valueA;
		Q.valueX = P.valueX + Q.valueX;
		R.next = new Node();
		Add(*P.next, *Q.next, *R.next);
	} 
	else
	{
		R.valueA = P.valueA + Q.valueA;
		Q.valueX = P.valueX + Q.valueX;
	}
}

void Write(struct Node &cur)
{
	if (cur.next != NULL)
	{
		printf("Value=%d,Stepen=%d ", cur.valueA, cur.valueX);
		Write(*cur.next);
	}
	else
	{
		printf("Value=%d, Stepen=%d\n", cur.valueA, cur.valueX);
	}
}

int _tmain(int argc, _TCHAR* argv[])
{
	struct Node *P = new Node();
	struct Node *Q = new Node();
	struct Node *R = new Node();
	int x;

	AddNode(7, 4, *P);
	AddNode(3, 2, *P);
	AddNode(-1, 1, *P);
	AddNode(2, 0, *P);

	AddNode(-2, 5, *Q);
	AddNode(2, 3, *Q);
	AddNode(1, 1, *Q);
	AddNode(-6, 0, *Q);

	printf("Input x = ");
	scanf("%d", &x);

	printf("Meaning P = %.2f\n", Meaning(*P, x));
	printf("Meaning Q = %.2f\n", Meaning(*Q, x));

	printf("Equality = %s\n", Equality(*P, *Q, x) ? "true" : "false");

	Add(*P, *Q, *R);
	printf("P=");
	Write(*P);
	printf("Q=");
	Write(*Q);
	printf("R=");
	Write(*R);

	system("pause");
	return 0;
}

