using System.Collections.Generic;
using System.Linq;

namespace Saimm4
{
	public class SourceItem
	{
		public SourceItem()
		{
			GenerateTimeList = new List<int>();
		}

		public bool HasGeneratedItem(int currentTime)
		{
			return GenerateTimeList.Count != 0 && currentTime < GenerateTimeList.Last();
		}

		public bool IsGenerated(int currentTime)
		{
			return GenerateTimeList.Contains(currentTime);
		}

		public List<int> GenerateTimeList { get; set; }
	}
}
