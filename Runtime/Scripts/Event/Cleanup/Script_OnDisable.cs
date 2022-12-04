// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;

	[AddComponentMenu(Constants.ACM.EVENT_CLEANUP + "On Disable")]
	internal sealed class Script_OnDisable : OnEvent
	{
		private void OnDisable() => Invoke();
	}
}