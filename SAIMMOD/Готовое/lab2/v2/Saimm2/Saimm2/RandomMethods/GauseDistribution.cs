using System;
using System.Collections.Generic;
using System.Linq;

namespace Saimm2.RandomMethods
{
    public class GauseDistribution : LemerDistribution
    {
        private readonly double _paramM;
        private readonly double _paramSigma;
        private readonly double _paramN;

		public GauseDistribution(int x0, int a, int c, uint m, int n, double paramM, double paramSigma)
            : base(x0, a, c, m, n)
        {
            _paramM = paramM;
            _paramSigma = paramSigma;
            _paramN = 6;
        }

        public override IList<double> Generate()
        {
            var digits = base.Generate();
            var random = new Random();
            return digits.Select(d =>
            {
                double r = 0;
                Enumerable.Range(1, (int)_paramN).ToList().ForEach(i => r += digits[random.Next(digits.Count)]);
                return _paramM + _paramSigma * Math.Sqrt(12 / _paramN) * (r - _paramN / 2);
            }).ToList();
        }
    }
}
