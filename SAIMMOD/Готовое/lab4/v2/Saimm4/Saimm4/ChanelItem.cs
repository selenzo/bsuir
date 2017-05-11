using System.Collections.Generic;
using System.Linq;

namespace Saimm4
{
	public class ChanelItem
	{
		private readonly List<int> _startWorkList;
		private readonly List<int> _endWorkList;

		public ChanelItem()
		{
			_startWorkList = new List<int>();
			_endWorkList = new List<int>();
		}

		public List<int> StartWorkList { get { return _startWorkList; } }
		public List<int> EndWorkList { get { return _endWorkList; } }

		public bool IsWorking(int currentTime)
		{
			return EndWorkList.Count != 0 && currentTime < EndWorkList.Last();
		}
	}
}
