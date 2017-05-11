using System;
using System.Collections.Generic;
using System.Linq;

namespace Saimm
{
    public static class Helpers
    {
        public static T Copy<T>(T elem) where T : new()
        {
            var type = elem.GetType();
            var result = (T)Activator.CreateInstance(type);
            var props = type.GetProperties();
            foreach (var prop in props)
            {
                if (!prop.CanWrite) continue;
                if (!prop.PropertyType.IsClass)
                    prop.SetValue(result, prop.GetValue(elem));
            }
            return result;
        }

        public static string StateToString(List<Element> state)
        {
            return string.Join("", state.Select(e => e.CurrentValue.ToString()));
        }

        public static bool IsCorrect(List<Element> state)
        {
            var sources = state.OfType<Source>();

            if (sources.Where(e => e.CurrentValue == e.BlockingValue).Any(e => e.NextElements.Any(en => en.MaxVal != en.CurrentValue)))
                return false;

            var queues = state.OfType<Queue>();

            if (queues.Where(e => e.CurrentValue != e.MinVal).Any(e => e.NextElements.Any(en => en.MaxVal != en.CurrentValue)))
                return false;

            return true;
        }

        public static double Sum(string stateKey, List<State> states, double p1, double p2)
        {
            return states.SelectMany(
                st => st.NextStepStates.Where(sst => StateToString(sst) == stateKey))
                .Sum(st => st.Compute(p1, p2));
        }

        public static string StringSum(string stateKey, List<State> states, double p1, double p2)
        {
            return string.Join("+",states.SelectMany(st => st.NextStepStates.Where(sst => StateToString(sst) == stateKey)).Select(st => st.StringFunc));
        }
    }
}
