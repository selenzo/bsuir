using System.Collections.Generic;
using System.Linq;

namespace Saimm4
{
	public class Schema
	{
		public Schema(int maxItemsInQueue, int chanelsCount)
		{
			_chanels = Enumerable.Range(1, chanelsCount).Select(x => new ChanelItem()).ToList();

			_queue = new QueueItem(maxItemsInQueue);
			_source = new SourceItem();
		}

		private QueueItem _queue { get; set; }
		private SourceItem _source { get; set; }
		private List<ChanelItem> _chanels { get; set; }
		private int _countDroped { get; set; }

		public void AddToWork(int startTime, int endTime)
		{
			var firstChanel = _chanels.FirstOrDefault(x => !x.IsWorking(startTime));
			if (firstChanel != null)
			{
				firstChanel.StartWorkList.Add(startTime);
				firstChanel.EndWorkList.Add(endTime);
			}
			else
			{
				AddToQueue();
			}
		}

		public void AddToQueue()
		{
			if (!_queue.Add())
				_countDroped++;
		}

		public bool AllChanelsInWorkingState(int time)
		{
			return _chanels.All(x => x.IsWorking(time));
		}

		public int CountWorkingWorkers(int time)
		{
			return _chanels.Count(x => x.IsWorking(time));
		}

		public bool HasGeneratedItem(int time)
		{
			return _source.HasGeneratedItem(time);
		}

		public bool IsGenerated(int time)
		{
			return _source.IsGenerated(time);
		}

		public int CountWorked { get { return _chanels.Sum(x => x.EndWorkList.Count); } }
		public int CountDroped { get { return _countDroped; } }
		public int CountInQueue { get { return _queue.Count; } }

		public void GenerateItem(int time)
		{
			_source.GenerateTimeList.Add(time);
		}

		public void RemoveFromQueue()
		{
			_queue.Remove();
		}
	}
}
