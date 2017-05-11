using System;
using System.Collections.Generic;

namespace Saimm
{
    #region Classes

    public class State : List<Element>
    {
        static State()
        {
            CompleteReferences = state => state;
        }

        public State(params Element[] elements)
        {
            this.AddRange(elements);
        }

        public State()
        {
        }

        public State(IEnumerable<Element> elements)
        {
            this.AddRange(elements);
        }

        public List<State> NextStepStates { get; set; }

        public static Func<State, State> CompleteReferences { get; set; }

        //todo change for more channels if need
        public Func<double, double, double> Compute { get; set; }
        public string StringFunc { get; set; }
    }

    public class Queue : Element
    {
    }

    public class Channel : Element
    {
        public bool Success { get; set; }
    }

    public class Source : Element
    {
        public override int MinVal
        {
            get { return 1; }
        }
    }

    public class Element
    {
        public List<Element> NextElements { get; set; }
        public List<Element> PreviousElements { get; set; }
        public int CurrentValue { get; set; }
        public bool Blocking { get; set; }
        public bool Droping { get; set; }
        public int MaxVal { get; set; }
        public virtual int MinVal { get { return 0; } }
        public int BlockingValue { get { return 0; } }
    }

    #endregion Classes
}
