#include "main.h"

int main(int argc, char *argv[])
{
	Stack *top = new Stack;
	//зазаносим данные в стек
	int a = 123;
	Push(top, a);
	a = 456;
	Push(top, a);
	a = 789;
	Push(top, a);

	//смотрим текущее состояние
	cout << "stack: " << endl;
	View(top);

	//Достаем данные
	cout << endl << Pop(*top);
	cout << endl << Pop(*top) << endl;

	//смотрим текущее состояние
	cout << endl << "stack: " << endl;
	View(top);

	system("pause");
	return 0;
}

int Pop(Stack &top)
{
	if (top.data != NULL)
	{
		int tempData = top.data;
		Stack tempPrev = *top.prev;
		top = tempPrev;
		return tempData;
	}
	else
	{
		cout << "stack is empty" << endl;
		return NULL;
	}
}

int Push(Stack * top, int data)
{
	if (top != NULL)
	{
		if (top->data == NULL)
		{
			top->data = data;
			return 0;
		}
		else
		{
			Stack *tempStack = new Stack;

			tempStack->prev = top->prev;
			tempStack->data = top->data;
			top->prev = tempStack;
			top->data = data;
		}
	}
	else
	{
		return 1;
	}
}

void View(Stack *st)
{
	if (st != NULL)
	{
		if (st->data != NULL)
		{
			cout << st->data << endl;
			if (st->prev != NULL)
			{
				View(st->prev);
			}
		}
	}
}