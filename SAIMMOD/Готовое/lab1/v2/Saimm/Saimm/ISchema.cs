using System.Collections.Generic;

namespace Saimm
{
    public interface ISchema
    {
        List<State> GenerateAllStates(List<Element> schema);

        List<Element> GetSchema();

        State CompleteReferences(State schema);
    }
}
