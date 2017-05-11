using System.Collections.Generic;
using System.Linq;

namespace Saimm
{
	public class LemerDistribution
	{
		private readonly int _x0;
		private readonly int _a;
		private readonly int _c;
		private readonly uint _m;
		private readonly int _n;

		public LemerDistribution(int x0, int a, int c, uint m, int n)
		{
			_x0 = x0;
			_a = a;
			_c = c;
			_m = m;
			_n = n;
		}

		public virtual IList<double> Generate()
		{
			var list = new List<double> { _x0 };
			var generatedList = new List<double>();
			Enumerable.Range(1, _n).ToList().ForEach(i =>
			{
				var newDigit = (_a * list[i - 1] + _c) % _m;
				list.Add(newDigit);
				generatedList.Add(newDigit / _m);
			});

			return generatedList;
		}
	}
}
