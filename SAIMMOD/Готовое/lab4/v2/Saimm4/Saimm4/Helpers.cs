using System;

namespace Saimm4
{
    public static class Helpers
    {
	    private const Double CountD = 1E-10;

	    public static double GetDouble(this string str)
        {
            double tmp;
            double.TryParse(str, out tmp);
            return tmp;
        }

		public static bool AboutEqual(double x, double y)
		{
			double epsilon = Math.Max(Math.Abs(x), Math.Abs(y)) * CountD;
			return Math.Abs(x - y) <= epsilon;
		}
    }
}
