using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAMM_1
{
    abstract class SequenceProducer
    {
        abstract public List<double> ProvideSequence();
    }
}
