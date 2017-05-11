#include <stdexcept>
using namespace std;

#ifdef MATHFUNCSDLL_EXPORTS
#define MATHFUNCSDLL_API __declspec(dllexport)
#else
#define MATHFUNCSDLL_API __declspec(dllimport)
#endif

namespace MathFuncs
{
	// This class is exported from the MathFuncsDll.dll
	class MyMathFuncs
	{
	public:
		// Returns a + b
		static MATHFUNCSDLL_API double Add(double a, double b);
	};
}

extern "C" _declspec(dllexport) double Add2(double a, double b);
