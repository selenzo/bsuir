// lab7.cpp: определяет точку входа для консольного приложения.
//

#include "stdafx.h"


int _tmain(int argc, _TCHAR* argv[])
{
	float x;
	HDC hDC = GetDC(GetConsoleWindow());
	HPEN Pen = CreatePen(PS_SOLID, 2, RGB(255, 255, 255));
	SelectObject(hDC, Pen);
	MoveToEx(hDC, 0, 100, NULL);
	LineTo(hDC, 200, 100);
	MoveToEx(hDC, 100, 0, NULL);
	LineTo(hDC, 100, 200);
	for (x = -1.58f; x <= 1.58f; x += 0.01f) // O(100,85) - center
	{
		MoveToEx(hDC, 10 * x + 100, -10 * x * x * x * x * x + 100, NULL);//10 - scale
		LineTo(hDC, 10 * x + 100, -10 * x * x * x * x * x + 100);
	}

	MoveToEx(hDC, 250, 100, NULL);
	LineTo(hDC, 450, 100);
	MoveToEx(hDC, 350, 13, NULL);
	LineTo(hDC, 350, 200);

	for (x = -7.0f; x <= 7.0f; x += 0.01f) // O(350, 100) - center
	{
		MoveToEx(hDC, 10 * x + 350, -10 * (cos(x -1) + abs(x)) + 100, NULL);//10 - scale
		LineTo(hDC, 10 * x + 350, -10 * (cos(x - 1) + abs(x)) + 100);
	}

	system("pause");
	return 0;
}

