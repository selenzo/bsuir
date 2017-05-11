using System.Collections.Generic;
using System.Linq;

namespace Saimm4.RandomMethods
{
    public class UniformDistribution : LemerDistribution
    {
        private readonly double _paramA;
        private readonly double _paramB;

        public UniformDistribution(int x0, int a, int c, uint m, int n, double paramA, double paramB) : base(x0, a, c, m, n)
        {
            _paramA = paramA;
            _paramB = paramB;
        }

        public override IList<double> Generate()
        {
	        var list = base.Generate();
            return list.Select(d => _paramA + (_paramB - _paramA) * d).ToList();
		}
    }
}
