// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;

	[AddComponentMenu(Constants.ACM.VALUE_TIME + "Time")]
	[UnityDocumentation("Time-time")]
	internal class Time_Time : OnOutput<float>
	{
		protected override float Get() => Time.time;
	}
}