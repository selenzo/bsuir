//using System;
//using System.IO;
//using System.Linq;

//namespace Saimm
//{
//	public class Program
//	{
//		static void Main(string[] args)
//		{
//			double p1 = 0.3, p2 = 0.2;

//			ISchema schemaCls = new Var23();

//			var schema = schemaCls.GetSchema();
//			State.CompleteReferences = schemaCls.CompleteReferences;


//			var states = schemaCls.GenerateAllStates(schema);

//			Console.WriteLine("All variants:");
//			states.ForEach(s => Console.WriteLine(Helpers.StateToString(s)));

//			Console.WriteLine("*****************************************");
//			Console.WriteLine("Corrects with next steps:");
//			for (int i = states.Count - 1; i >= 0; i--)
//			{
//				if (!Helpers.IsCorrect(states[i]))
//					states.RemoveAt(i);
//			}

//			BLL.ComputeAllSteps(states);

//			var table_func = "";

//			using (var sw = new StreamWriter("result.txt"))
//			{
//				using (var sw_func = new StreamWriter("result_func.html"))
//				{
//					sw.WriteLine("Result Table");
//					sw.Write("\\\t\t");
//					table_func += "<table style=\"width:3000px\">";

//					states.ForEach(s => sw.Write(Helpers.StateToString(s) + "\t"));

//					table_func += "<tr><th></th>";

//					states.ForEach(s => table_func += "<th>" + Helpers.StateToString(s) + "</th>");
//					table_func += "</tr>";

//					sw.WriteLine();

//					states.ForEach(s =>
//					{
//						sw.Write(Helpers.StateToString(s) + "\t");
//						table_func += "<tr><td>" + Helpers.StateToString(s) + "</td>";
//						Console.WriteLine(Helpers.StateToString(s));

//						var groups = s.NextStepStates.GroupBy(Helpers.StateToString).ToList();

//						//double sum = 0;

//						foreach (var el in groups)
//						{
//							Console.WriteLine("\t" + el.Key + " sum: " + el.Sum(ss => ss.Compute(p1, p2)));

//							//sum += el.Sum(ss => ss.Compute(0.75, 0.6))*Helpers.Sum(el.Key, states, 0.75, 0.6);
//						}


//						foreach (var state in states)
//						{
//							sw.Write((groups.Any(g => g.Key == Helpers.StateToString(state)) ?
//								groups.First(g => g.Key == Helpers.StateToString(state)).Sum(gs => gs.Compute(p1, p2)) :
//								0) + "   \t"
//							);

//							table_func += "<td>" +
//										  (groups.Any(g => g.Key == Helpers.StateToString(state))
//											  ? string.Join(" + ",
//												  groups.First(g => g.Key == Helpers.StateToString(state))
//													  .Select(gs => gs.StringFunc))
//											  : "0") + "</td>";

//						}

//						sw.WriteLine();

//						table_func += "</tr>";
//						//Console.WriteLine("************* Total Sum: " + sum + " ****************");

//						//Console.WriteLine("************* Sum: " + Helpers.Sum(Helpers.StateToString(s), states, 0.75, 0.6) + " ****************");
//					});

//					table_func += "</table>";

//					sw_func.Write(table_func);
//				}
//			}

//			Console.ReadKey();
//		}
//	}
//}
