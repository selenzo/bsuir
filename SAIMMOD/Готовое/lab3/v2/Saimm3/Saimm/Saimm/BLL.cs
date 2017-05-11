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

		public static Func<double, double, double> GetComputeFunc(State state, bool[] channelChanges, bool[] validChanels)
		{
			Func<double, bool, bool, double> f = (value, changed, valid) => (valid ? (changed ? (1 - value) : value) : 0);
			return (p1, p2) =>
			{
				var r1 = f(p1, channelChanges[0], validChanels[0]);
				var r2 = f(p2, channelChanges[1], validChanels[1]);
				if (r1 == 0) return r2;
				if (r2 == 0) return r1;
				return r1*r2;
			};
		}

		public static string GetStringFunc(State state, bool[] channelChanges, bool[] validChanels)
		{
			if (channelChanges[0] && !channelChanges[1])
			{
				if (validChanels[0] && validChanels[1])
					return "(1 - p1) * p2";

				if (validChanels[0] && !validChanels[1])
					return "(1 - p1)";

				if (!validChanels[0] && validChanels[1])
					return "p2";

				return "0";
			}

			if (!channelChanges[0] && channelChanges[1])
			{
				if (validChanels[0] && validChanels[1])
					return "p1 * (1 - p2)";

				if (validChanels[0] && !validChanels[1])
					return "p1";

				if (!validChanels[0] && validChanels[1])
					return "(1 - p2)";

				return "0";
			}

			if (channelChanges[0] && channelChanges[1])
			{
				if (validChanels[0] && validChanels[1])
					return "(1 - p1) * (1 - p2)";

				if (validChanels[0] && !validChanels[1])
					return "(1 - p1)";

				if (!validChanels[0] && validChanels[1])
					return "(1 - p2)";

				return "0";
			}

			if (channelChanges[0] && channelChanges[1])
			{
				if (validChanels[0] && validChanels[1])
					return "p1 * p2";

				if (validChanels[0] && !validChanels[1])
					return "p1";

				if (!validChanels[0] && validChanels[1])
					return "p2";

				return "0";
			}


			return "0";
		}
		public static State GenerateNextState(State state, bool[] channelChanges)
		{
			var newState = new State(state.Select(Helpers.Copy).ToList());
			newState = State.CompleteReferences(newState);

			var channels = newState.OfType<Channel>().ToList();

			var validChanels = channels.Select(c => c.CurrentValue == 1).ToArray();

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

			newState.Compute = GetComputeFunc(newState, channelChanges, validChanels);
			newState.StringFunc = GetStringFunc(newState, channelChanges, validChanels);

			return newState;
		}

		public static void ComputeAllSteps(List<State> states)
		{
			foreach (var state in states)
			{
				var listStepStates = new List<State>();

				var chanels = state.OfType<Channel>().ToList();

				if (chanels.First().CurrentValue != 1 && chanels.Last().CurrentValue != 1)
				{
					var st = GenerateNextState(state, new[] {false, false});
					st.Compute = (d, d1) => 1;
					st.StringFunc = "1";
					listStepStates.Add(st);
				}
				else if (chanels.First().CurrentValue == 1 && chanels.Last().CurrentValue != 1
						|| chanels.First().CurrentValue != 1 && chanels.Last().CurrentValue == 1)
				{
					listStepStates.Add(GenerateNextState(state, new[] { true, false }));
					listStepStates.Add(GenerateNextState(state, new[] { false, true }));
				}
				else
				{
					listStepStates.Add(GenerateNextState(state, new[] { true, false }));
					listStepStates.Add(GenerateNextState(state, new[] { false, true }));
					listStepStates.Add(GenerateNextState(state, new[] { true, true }));
					listStepStates.Add(GenerateNextState(state, new[] { false, false }));
				}

				state.NextStepStates = listStepStates;
			}
		}

		#endregion Steps
	}
}
