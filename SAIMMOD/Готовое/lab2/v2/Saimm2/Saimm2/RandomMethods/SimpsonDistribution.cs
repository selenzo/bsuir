using System;
using System.Collections.Generic;
using System.Linq;

namespace Saimm2.RandomMethods
{
    public class SimpsonDistribution : LemerDistribution
    {
        private readonly double _paramA;
        private readonly double _paramB;

		public SimpsonDistribution(int x0, int a, int c, uint m, int n, double paramA, double paramB)
            : base(x0, a, c, m, n)
        {
            _paramA = paramA;
            _paramB = paramB;
        }

        public override IList<double> Generate()
        {

            var newList = base.Generate().Select(d => _paramA / 2 + (_paramB / 2 - _paramA / 2) * d).ToList();
            var r = new Random();
            return Enumerable.Range(1, newList.Count).Select(i => newList[r.Next(newList.Count)] + newList[r.Next(newList.Count)]).ToList();
        }
    }
}
