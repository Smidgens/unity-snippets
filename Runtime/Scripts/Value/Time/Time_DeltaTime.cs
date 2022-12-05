// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;

	[AddComponentMenu(Constants.ACM.VALUE_TIME + "Delta Time")]
	[UnityDocumentation("Time-deltaTime")]
	internal class Time_DeltaTime : OnOutput<float>
	{
		protected override float Get() => Time.deltaTime;
	}
}