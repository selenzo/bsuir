using System;
using System.Collections.Generic;
using System.Linq;

namespace Saimm2.RandomMethods
{
    public class ExponentialDistribution : LemerDistribution
    {
        private readonly double _paramLambda;

		public ExponentialDistribution(int x0, int a, int c, uint m, int n, double paramLambda)
			: base(x0, a, c, m, n)
        {
            _paramLambda = paramLambda;
        }

        public override IList<double> Generate()
        {
            return base.Generate().Select(d => -(Math.Log(d)/_paramLambda)).ToList();
        }
    }
}
