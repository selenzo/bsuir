using System.Collections.Generic;
using System.Linq;

namespace Saimm2
{
	public static class Random
	{
		public static IList<double> Generate(int x0, int a, int c, int m, int n)
		{
			var list = new List<double> { x0 };
			var generatedList = new List<double>();
			Enumerable.Range(1, n).ToList().ForEach(i =>
			{
				var newDigit = (a * list[i - 1] + c) % m;
				list.Add(newDigit);
				generatedList.Add(newDigit / m);
			});

			return generatedList;
		}

		/// <summary>
		/// Имитация равномерного распределения
		/// </summary>
		/// <param name="digits"></param>
		/// <param name="a"></param>
		/// <param name="b"></param>
		/// <returns></returns>
		public static IList<double> GenerateFirstMethod(IList<double> digits, int a, int b)
		{
			return digits.Select(d => a + (b - a) * d).ToList();
		}

		/// <summary>
		/// Имитация распределения Симпсона (треугльное распределение)
		/// </summary>
		/// <param name="digits"></param>
		/// <param name="a"></param>
		/// <param name="b"></param>
		/// <returns></returns>
		public static IList<double> GenerateSecondMethod(IList<double> digits, int a, int b)
		{
			return digits.Select(d => a + (b - a) * d).ToList();
		}
	}
}
