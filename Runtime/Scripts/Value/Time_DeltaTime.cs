// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;

	[AddComponentMenu(Constants.ACM.VALUE_TIME + "Delta Time")]
	internal class Time_DeltaTime : OnOutput<float>
	{
		protected override float Read() => Time.deltaTime;
	}
}