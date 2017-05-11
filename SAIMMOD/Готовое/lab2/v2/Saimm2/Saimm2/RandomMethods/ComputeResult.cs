using System.Collections.Generic;

namespace Saimm2.RandomMethods
{
	public class ComputeResult
	{
		public IEnumerable<double> Items { get; set; }

		public double D { get; set; }

		public double M { get; set; }

		public double S { get; set; }

		public int Period { get; set; }

		public int Aperiod { get; set; }
	}
}
