#include "main.h"
//при компилировании грузим статически
//с помощью loadlibrary динамически

int main(int argc, char *argv[])
{
	HINSTANCE hDllInstance = LoadLibraryEx(L"lab13lib.dll", 0, DONT_RESOLVE_DLL_REFERENCES);
	typedef double(*functionDll)(double, double);
	functionDll fpFunction = (functionDll)GetProcAddress(hDllInstance, "Add2");
	
	double a = 7.4;
	int b = 99;
	
	cout << "a + b = " << MathFuncs::MyMathFuncs::Add(a, b) << endl;

	cout << "a + b = " << fpFunction(a, b) << endl;

	FreeLibrary(hDllInstance);

	system("pause");
	return 0;
}