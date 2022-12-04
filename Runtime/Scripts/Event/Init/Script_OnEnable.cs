// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;

	[AddComponentMenu(Constants.ACM.EVENT_INIT + "On Enable")]
	internal sealed class Script_OnEnable : OnEvent
	{
		private void OnEnable() => Invoke();
	}
}