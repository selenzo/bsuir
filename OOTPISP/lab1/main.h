#include <iostream>

using namespace std;



struct Stack
{
	int data = NULL;
	Stack *prev = NULL;
};

int Push(Stack * top, int data);
int Pop(Stack &top);
void View(Stack *st);