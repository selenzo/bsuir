using System.Collections.Generic;

namespace Saimm
{
    class TestSchema : ISchema
    {
        #region Schema

        public List<State> GenerateAllStates(List<Element> schema)
        {
            //todo replace is change schema

            var result = new List<State>();
            for (int i = schema[0].BlockingValue; i <= schema[0].MaxVal; i++)
            {
                var f = Helpers.Copy(schema[0]);
                f.CurrentValue = i;

                for (int j = schema[1].MinVal; j <= schema[1].MaxVal; j++)
                {
                    var s = Helpers.Copy(schema[1]);
                    s.CurrentValue = j;

                    for (int k = schema[2].MinVal; k <= schema[2].MaxVal; k++)
                    {
                        var t = Helpers.Copy(schema[2]);
                        t.CurrentValue = k;

                        for (int l = schema[3].MinVal; l <= schema[3].MaxVal; l++)
                        {
                            var fo = Helpers.Copy(schema[3]);
                            fo.CurrentValue = l;

                            result.Add(CompleteReferences(new State
                            {
                                Helpers.Copy(f), Helpers.Copy(s), Helpers.Copy(t), Helpers.Copy(fo)
                            }));
                        }
                    }
                }
            }

            return result;

            //todo replace is change schema
        }

        public List<Element> GetSchema()
        {
            //todo replace is change schema

            var s = new Source
            {
                MaxVal = 2,
            };

            var c1 = new Channel
            {
                MaxVal = 1,
            };

            var q = new Queue
            {
                MaxVal = 2,
                Blocking = true,
            };

            var c2 = new Channel
            {
                MaxVal = 1,
            };

            var list = new State
            {
                s, q, c1, c2
            };

            return CompleteReferences(list);

            //todo replace is change schema
        }

        public State CompleteReferences(State schema)
        {
            //todo replace is change schema
            schema[0].NextElements = new List<Element> { schema[1] };

            schema[1].PreviousElements = new List<Element> { schema[0] };
            schema[1].NextElements = new List<Element> { schema[2], schema[3] };

            schema[2].PreviousElements = new List<Element> { schema[1] };
            schema[3].PreviousElements = new List<Element> { schema[1] };
            //todo replace is change schema

            return schema;
        }

        #endregion Schema
    }
}
