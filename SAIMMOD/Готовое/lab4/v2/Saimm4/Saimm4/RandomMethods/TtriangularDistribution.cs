using System;
using System.Collections.Generic;
using System.Linq;

namespace Saimm4.RandomMethods
{
    public class TtriangularDistribution: LemerDistribution
    {
        private readonly double _paramA;
        private readonly double _paramB;

		public TtriangularDistribution(int x0, int a, int c, uint m, int n, double paramA, double paramB)
			: base(x0, a, c, m, n)
        {
            _paramA = paramA;
            _paramB = paramB;
        }

        public override IList<double> Generate()
        {
            var digits = base.Generate();
            var random = new Random();
            return digits.Select(d => _paramA + (_paramB - _paramA) * Math.Max(digits[random.Next(digits.Count)], digits[random.Next(digits.Count)])).ToList();
		}
    }
}
