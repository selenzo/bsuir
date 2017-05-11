namespace Saimm4
{
	public class QueueItem
	{
		public QueueItem(int maxItems)
		{
			_maxItems = maxItems;
		}

		private int _maxItems;
		private int _count;

		public bool Add()
		{
			if (_count < 6)
			{
				_count++;
				return true;
			}

			return false;
		}

		public int Count { get { return _count; } }

		public void Remove()
		{
			if (_count > 0)
			{
				_count--;
			}
		}
	}
}
