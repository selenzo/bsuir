using System;
using System.Linq;
using Saimm4.RandomMethods;

namespace Saimm4
{
	class Program
	{
		private static Random r;

		static Program()
		{
			r = new Random();
		}

		static void Main(string[] args)
		{
			const int maxItemsInQueue = 6;

			int ia = 30, ib = 10;

			var s = new Schema(maxItemsInQueue, 2);

			const int totalWorkingTime = 10000;

			var fr = new ExponentialDistribution(7, 5, 3, uint.MaxValue, totalWorkingTime, ia);
			var frl = fr.Generate();

			var dr = new ExponentialDistribution(7, 5, 3, uint.MaxValue, totalWorkingTime, ib);
			var drl = dr.Generate();

			int sumOch = 0;
			int wokingWorker = 0;

			for (int i = 0; i < totalWorkingTime; i++)
			{
				if (!s.HasGeneratedItem(i))
				{
					s.GenerateItem(i + (int)(frl.Skip(r.Next(totalWorkingTime)).First() * ia));
				}

				if (s.IsGenerated(i))
				{
					s.AddToQueue();
				}

				for (int j = 0; j < s.CountInQueue; j++)
				{
					if (!s.AllChanelsInWorkingState(i))
					{
						var endTime = i + (int)(drl.Skip(r.Next(totalWorkingTime)).First() * ib);

						if (endTime < totalWorkingTime)
						{
							s.AddToWork(i, endTime);
							s.RemoveFromQueue();
						}
					}
				}

				wokingWorker += s.CountWorkingWorkers(i);

				sumOch += s.CountInQueue;
			}

			Console.WriteLine("Абсолютная пропускная способность = " + 1/(double)ia * (1 - s.CountDroped / (double)totalWorkingTime));
			Console.WriteLine("Среднее число занятых рабочих = " + wokingWorker / (double)totalWorkingTime);
			Console.WriteLine("Среднее число неисправных станков = " + sumOch / (double)totalWorkingTime);
			Console.ReadKey();
		}
	}
}
