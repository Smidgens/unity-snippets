// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;

	[AddComponentMenu(Constants.ACM.EVENT_CLEANUP + "On Destroy")]
	internal sealed class Script_OnDestroy : OnEvent
	{
		private void OnDestroy() => Invoke();
	}
}