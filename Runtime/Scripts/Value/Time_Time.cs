// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;

	[AddComponentMenu(Constants.ACM.VALUE_TIME + "Time")]
	internal class Time_Time : OnOutput<float>
	{
		protected override float Read() => Time.time;
	}
}