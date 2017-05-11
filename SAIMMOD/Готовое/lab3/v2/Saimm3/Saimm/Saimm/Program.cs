using System;
using System.IO;
using System.Linq;

namespace Saimm
{
	public class Program
	{
		static void Main(string[] args)
		{
			double p1 = 0.3, p2 = 0.2;

			int x0 = 7, a = 5, c = 3, N = 1000;
			uint m = /*4294967295*/ 64;

			var ld = new LemerDistribution(x0, a, c, m, N);

			ISchema schemaCls = new Schema();

			var schema = schemaCls.GetSchema();
			State.CompleteReferences = schemaCls.CompleteReferences;


			var states = schemaCls.GenerateAllStates(schema);

			Console.WriteLine("All variants:");
			states.ForEach(s => Console.WriteLine(Helpers.StateToString(s)));

			Console.WriteLine("*****************************************");
			Console.WriteLine("Corrects with next steps:");
			for (int i = states.Count - 1; i >= 0; i--)
			{
				if (!Helpers.IsCorrect(states[i]))
					states.RemoveAt(i);
			}

			BLL.ComputeAllSteps(states);

			states.ForEach(s =>
			{
				Console.WriteLine(Helpers.StateToString(s));

				var groups = s.NextStepStates.GroupBy(Helpers.StateToString).ToList();

				foreach (var el in groups)
				{
					Console.WriteLine("\t" + el.Key + " sum: " + el.Sum(ss => ss.Compute(p1, p2)));
				}
			});

			FileHelper.WriteTable<Schema>(states, p1, p2);
			FileHelper.WriteTableHtml<Schema>(states, p1, p2);
			FileHelper.WriteMatlabFunc<Schema>(states, p1, p2);

			var list = ld.Generate().ToList();

			FileHelper.WritePractHtml<Schema>(states, list, p1, p2);

			Console.ReadKey();
		}
	}
}
