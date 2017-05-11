using System.Collections.Generic;

namespace Saimm2.RandomMethods
{
    public interface IDistribution
    {
        IList<double> Generate();
	    ComputeResult Compute();
		//double A { get; }
		//double B { get; }
    }
}
