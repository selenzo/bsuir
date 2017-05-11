using System;
using System.Collections.Generic;
using System.Linq;

namespace Saimm
{
    public static class BLL
    {
        #region Steps

        public static void ChannelStep(Channel channel)
        {
            if (channel.Success)
            {
                if (channel.MinVal != channel.CurrentValue)
                {
                    if (channel.NextElements != null && channel.NextElements.All(e => e.CurrentValue == e.MaxVal))
                    {
                        if (channel.Droping)
                            channel.CurrentValue--;
                        //todo check for blocking?
                    }
                    else
                    {
                        if (channel.NextElements != null)
                            channel.NextElements.First(e => e.CurrentValue != e.MaxVal).CurrentValue++;

                        channel.CurrentValue--;
                    }
                }

                channel.Success = false;
            }
        }

        public static void QueueStep(Queue queue)
        {
            foreach (var nextElement in queue.NextElements)
            {
                var countM = nextElement.MaxVal - nextElement.CurrentValue;
                var countP = queue.CurrentValue < countM ? queue.CurrentValue : countM;
                nextElement.CurrentValue += countP;
                queue.CurrentValue -= countP;
            }

            //todo check for blocking?
            //todo check for droping?
        }

        public static void SourceStep(Source source)
        {
            if (source.CurrentValue == source.MinVal || source.BlockingValue == source.CurrentValue)
            {
                foreach (var nextElement in source.NextElements)
                {
                    if (nextElement.CurrentValue < nextElement.MaxVal)
                    {
                        nextElement.CurrentValue++;
                        source.CurrentValue = source.MaxVal;
                        return;
                    }
                }

                if (source.Droping)
                {
                    source.CurrentValue = source.MaxVal;
                    return;
                }

                source.CurrentValue = source.BlockingValue;
            }
            else
                source.CurrentValue--;
        }

        public static Func<double, double, double> GetComputeFunc(State state, params bool[] channelChanges)
        {
            if (channelChanges[0] && !channelChanges[1])
                return (p1, p2) => (1 - p1) * p2;

            if (!channelChanges[0] && channelChanges[1])
                return (p1, p2) => p1 * (1 - p2);

            if (channelChanges[0] && channelChanges[1])
                return (p1, p2) => (1 - p1) * (1 - p2);

            return (p1, p2) => p1 * p2;
        }

        public static string GetStringFunc(State state, params bool[] channelChanges)
        {
            if (channelChanges[0] && !channelChanges[1])
                return "(1 - p1) * p2";

            if (!channelChanges[0] && channelChanges[1])
                return "p1 * (1 - p2)";

            if (channelChanges[0] && channelChanges[1])
                return "(1 - p1) * (1 - p2)";

            return "p1 * p2";
        }
        public static State GenerateNextState(State state, params bool[] channelChanges)
        {
            var newState = new State(state.Select(Helpers.Copy).ToList());
            newState = State.CompleteReferences(newState);

            var channels = newState.OfType<Channel>().ToList();

            for (var i = 0; i < channels.Count; i++)
            {
                channels[i].Success = channelChanges[i];
            }

            for (int i = newState.Count - 1; i >= 0; i--)
            {

                if (newState[i] is Channel)
                {
                    var chan = newState[i] as Channel;
                    ChannelStep(chan);
                }

                if (newState[i] is Queue)
                {
                    var queue = newState[i] as Queue;

                    QueueStep(queue);
                }

                if (newState[i] is Source)
                {
                    var source = newState[i] as Source;

                    SourceStep(source);
                }

                if (newState[i].NextElements != null)
                    newState[i].NextElements.ForEach(e =>
                    {
                        if (e is Queue)
                            QueueStep(e as Queue);
                    });
            }

            newState.Compute = GetComputeFunc(newState, channelChanges);
            newState.StringFunc = GetStringFunc(newState, channelChanges);

            return newState;
        }

        public static void ComputeAllSteps(List<State> states)
        {
            foreach (var state in states)
            {
                var listStepStates = new List<State>
                {
                    GenerateNextState(state, true, false),
                    GenerateNextState(state, false, true),
                    GenerateNextState(state, true, true),
                    GenerateNextState(state, false, false)
                };

                state.NextStepStates = listStepStates;
            }
        }

        #endregion Steps
    }
}
