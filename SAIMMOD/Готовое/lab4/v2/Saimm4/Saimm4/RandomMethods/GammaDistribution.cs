using System;
using System.Collections.Generic;
using System.Linq;

namespace Saimm4.RandomMethods
{
    public class GammaDistribution: LemerDistribution
    {
        private readonly double _paramLambda;
        private readonly double _paramEta;

		public GammaDistribution(int x0, int a, int c, uint m, int n, double paramLambda, double paramEta)
			: base(x0, a, c, m, n)
        {
            _paramLambda = paramLambda;
            _paramEta = paramEta;
        }

        public override IList<double> Generate()
        {
            var digits = base.Generate();
            var random = new Random();
            return digits.Select(d =>
            {
                double r = 1;
                Enumerable.Range(1, (int)_paramEta).ToList().ForEach(i => r *= digits[random.Next(digits.Count)]);
                return -Math.Log(r)/_paramLambda;
            }).ToList();
        }
    }
}
