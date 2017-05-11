
#include "MathFuncsDll.h"

extern "C" _declspec(dllexport) double Add2(double a, double b)
{
	return a + b;
}

namespace MathFuncs
{
	double MyMathFuncs::Add(double a, double b)
	{
		return a + b;
	}
}
