// lab1_3.cpp: определяет точку входа для консольного приложения.
//

#include "stdafx.h"

struct Node
{
	string F;
	string I;
	string O;
	int phone = NULL;
	struct Node * next = NULL;
};

void AddNode(struct Node &cur, string f, string i, string o, int p)
{
	if (cur.next != NULL)
	{
		AddNode(*cur.next, f ,i ,o, p);
	}
	else
	{	

		if (cur.phone != NULL)
		{
			cout << "dfsdf";
			cur.next = new Node();
			cur.next->F = f;
			cur.next->I = i;
			cur.next->O = o;
			cur.next->phone = p;
		}
		else
		{
			cur.F = f;
			cur.I = i;
			cur.O = o;
			cur.phone = p;
		}
	}
}

void Preview(struct Node &cur)
{
	if (cur.phone != NULL)
	{
		cout << cur.phone << " " << cur.F << " " << cur.I << " " << cur.O << endl;
		if (cur.next != NULL)
		{
			Preview(*cur.next);
		}
	}
};

void Sort(struct Node &begin)
{
	struct Node *tmp = new Node();
	tmp = &begin;
	string F, I, O;
	int p;
	int count = 1;

	while (tmp->next != NULL)
	{
		count++;
		tmp = tmp->next;
	}

	cout << count << endl;

	for (int i = 0; i < count; i++)
	{
		tmp = &begin;
		for (int j = 0; j < count; j++)
		{
			if (tmp->next != NULL)
			{
				if (tmp->next->phone < tmp->phone)
				{
					p = tmp->phone;
					F = tmp->F;
					I = tmp->I;
					O = tmp->O;

					tmp->F = tmp->next->F;
					tmp->I = tmp->next->I;
					tmp->O = tmp->next->O;
					tmp->phone = tmp->next->phone;

					tmp->next->F = F;
					tmp->next->I = I;
					tmp->next->O = O;
					tmp->next->phone = p;
				}
			}
			tmp = tmp->next;
		}
	}
}

void SearchLastname(struct Node &begin, string src)
{
	while (begin.next != NULL)
	{
		if (begin.F == src)
		{
			cout << begin.phone << endl;
		}
		begin = *begin.next;
	}
	if (begin.F == src)
	{
		cout << begin.phone << endl;
	}
}

void SearchPhone(struct Node &begin, int p)
{
	while (begin.next != NULL)
	{
		if (begin.phone == p)
		{
			cout << begin.F<< endl;
		}
		begin = *begin.next;
	}
	if (begin.phone == p)
	{
		cout << begin.F << endl;
	}
}


int _tmain(int argc, _TCHAR* argv[])
{
	struct Node * begin = new Node();
	string f, i, o;
	string src;
	int p, phone;
	bool ok = true;

	AddNode(*begin, "Sidorov", "Sidr", "Sidorovich", 5462156);
	AddNode(*begin, "Ivanov", "Ivan", "Ivanovich", 1234567);
	AddNode(*begin, "Petrov", "Petr", "Petrovich", 2020327);
	
	Sort(*begin);

	while (ok)
	{
		system("cls");
		cout << "1) Add record" << endl;
		cout << "2) Preview" << endl;
		cout << "3) Search lastname" << endl;
		cout << "4) Search phone" << endl;
		cout << "5) Quit" << endl;
		int a;
		a = _getche();
		cout << endl;
		switch (a)
		{
			case '1' :
				cout << "Input firstname (ivan, alexei, etc...)" << endl;
				cin >> i;
				cout << "Input lastname (ivanov, petrov, etc...)" << endl;
				cin >> f;
				cout << "Input thirdname (ivanovich, petrovich, etc...)" << endl;
				cin >> o;
				cout << "Input phone number" << endl;
				cin >> p;
				AddNode(*begin, f, i ,o ,p);
				Sort(*begin);
				break;
			case '2':
				Preview(*begin);
				system("pause");
				break;
			case '3':
				cout << "Input search lastname" << endl;
				cin >> src;
				SearchLastname(*begin, src);
				system("pause");
				break;
			case '4':
				cout << "Input search phone" << endl;
				cin >> phone;
				SearchPhone(*begin, phone);
				system("pause");
				break;
			case '5':
				ok = false;
				break;
			default:
				break;
		}
	}
	return 0;
}

