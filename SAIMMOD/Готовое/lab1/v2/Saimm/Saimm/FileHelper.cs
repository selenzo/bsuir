using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Saimm
{
	public static class FileHelper
	{
		public static void WriteTable<T>(List<State> states, double p1, double p2) where T : ISchema
		{
			using (var sw = new StreamWriter(typeof(T).Name + "_result.txt"))
			{
				sw.WriteLine("Result Table");
				sw.Write("\\\t\t");

				states.ForEach(s => sw.Write(Helpers.StateToString(s) + "\t"));

				sw.WriteLine();

				states.ForEach(s =>
				{
					sw.Write(Helpers.StateToString(s) + "\t");

					var groups = s.NextStepStates.GroupBy(Helpers.StateToString).ToList();

					foreach (var state in states)
					{
						sw.Write((groups.Any(g => g.Key == Helpers.StateToString(state)) ?
							groups.First(g => g.Key == Helpers.StateToString(state)).Sum(gs => gs.Compute(p1, p2)) :
							0) + "   \t"
						);
					}

					sw.WriteLine();
				});
			}
		}

		public static void WriteTableHtml<T>(List<State> states, double p1, double p2) where T : ISchema
		{
			string tableFunc = "";
			using (var sw_func = new StreamWriter(typeof(T).Name + "_result_func.html"))
			{
				tableFunc += "<table style=\"width:3000px\">";

				tableFunc += "<tr><th></th>";

				states.ForEach(s => tableFunc += "<th>" + Helpers.StateToString(s) + "</th>");
				tableFunc += "</tr>";

				states.ForEach(s =>
				{
					tableFunc += "<tr><td>" + Helpers.StateToString(s) + "</td>";

					var groups = s.NextStepStates.GroupBy(Helpers.StateToString).ToList();

					foreach (var state in states)
					{
						tableFunc += "<td>" +
									  (groups.Any(g => g.Key == Helpers.StateToString(state))
										  ? string.Join(" + ",
											  groups.First(g => g.Key == Helpers.StateToString(state))
												  .Select(gs => gs.StringFunc))
										  : "0") + "</td>";

					}

					tableFunc += "</tr>";
				});

				tableFunc += "</table>";

				sw_func.Write(tableFunc);
			}
		}

		public static void WriteMatlabFunc<T>(List<State> states, double p1, double p2) where T : ISchema
		{
			string tableFunc = "";
			using (var swFunc = new StreamWriter(typeof(T).Name + "_matlab_func.txt"))
			{
				swFunc.WriteLine("clear; clc;");
				swFunc.WriteLine("syms {0};", string.Join(" ", states.Select(s => "P" + Helpers.StateToString(s))));

				var templateStr = "A = solve('{0}');";

				var tmpElemList = new List<string>();

				states.ForEach(s =>
				{
					var statesInColumn = states.Where(st => st.NextStepStates.Any(nst => Helpers.StateToString(nst) == Helpers.StateToString(s)));
					var strElem = string.Format("P{0} = {1}", Helpers.StateToString(s), statesInColumn.Any() ?
						string.Join(" + ", statesInColumn.Select(stateInColumn =>
						{
							var tmpNext = stateInColumn.NextStepStates.Where(st => Helpers.StateToString(st) == Helpers.StateToString(s)).ToList();
							var sum = tmpNext.Sum(st => st.Compute(p1, p2));
							return string.Format("P{0}*{1}", Helpers.StateToString(stateInColumn), sum.ToString().Replace(",", "."));
						})) : "0");

					tmpElemList.Add(strElem);
				});

				tmpElemList.Add(string.Format("{0} = 1", string.Join(" + ", states.Select(s => "P" + Helpers.StateToString(s)))));

				swFunc.WriteLine(templateStr, string.Join(", ", tmpElemList));

				states.ForEach(s => swFunc.WriteLine("P{0}=A.P{0}", Helpers.StateToString(s)));

				swFunc.WriteLine("Sum = "+ string.Join(" + ", states.Select(s => string.Format("A.P{0}", Helpers.StateToString(s)))));

				swFunc.Write(tableFunc);
			}
		}
	}
}
