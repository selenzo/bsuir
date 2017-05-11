using System;
using System.Collections.Generic;
using System.Linq;

namespace Saimm4.RandomMethods
{
    public class LemerDistribution : IDistribution
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

	    public virtual ComputeResult Compute()
	    {
		    var digits = Generate();

		    var m = GetM(digits);
		    var d = GetD(digits, m);
		    var s = GetS(d);
		    var aperiod = GetAperiod(digits);
		    var period = GetPeriod(digits);

			return new ComputeResult
			{
				M = m,
				D = d,
				S = s,
				Aperiod = aperiod,
				Period = period
			};
	    }

		//public virtual double A { get { return 0; } }
		//public virtual double B { get { return 1; } }

	    protected virtual double GetM(IList<double> digits)
	    {
			return 1.0 / digits.Count * (digits.Sum());
	    }

		protected virtual double GetD(IList<double> digits, double m)
		{
			return 1.0 / digits .Count * (digits.Sum(el => Math.Pow(el - m, 2)));
		}

		protected virtual double GetS(double d)
		{
			return Math.Sqrt(d);
		}

		protected virtual int GetAperiod(IList<double> digits)
	    {
			var aperiod = 0;
			var dictionary = new Dictionary<double, int>();

			for (int i = 0; i < digits.Count; i++)
			{
				if (!dictionary.Any(d => Helpers.AboutEqual(d.Key, digits[i])) && !dictionary.ContainsKey(digits[i]))
					dictionary.Add(digits[i], i);
				else
				{
					if (aperiod < dictionary.Count)
						aperiod = dictionary.Count;
					i = (dictionary.ContainsKey(digits[i]) ? dictionary[digits[i]] : dictionary.First(d => Helpers.AboutEqual(d.Key, digits[i])).Value) + 1;
					dictionary.Clear();
				}
			}

			if (aperiod < dictionary.Count)
				aperiod = dictionary.Count;

			return aperiod;
	    }

		protected virtual int GetPeriod(IList<double> digits)
	    {
			var period = 0;

			var indexes = new List<int>();

			for (int i = 1; i < digits.Count; i++)
			{
				if (Helpers.AboutEqual(digits[i], digits[0]))
					indexes.Add(i);
			}

			for (int i = 0; i < indexes.Count; i++)
			{
				var validPeriod = true;
				for (int j = indexes[i]; j < ((indexes[i] * 2 > digits.Count) ? digits.Count : indexes[i] * 2); j++)
				{
					if (!Helpers.AboutEqual(digits[j - indexes[i]], digits[j]))
						validPeriod = false;
				}

				if (validPeriod)
				{
					period = indexes[i];
					break;
				}
			}

			return period;
	    }
    }
}
