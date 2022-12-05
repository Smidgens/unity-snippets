// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;

	[AddComponentMenu(Constants.ACM.EVENT_CLEANUP + "On Destroy")]
	[UnityDocumentation("MonoBehaviour.OnDestroy")]
	internal sealed class MonoBehaviour_OnDestroy : OnEvent
	{
		private void OnDestroy() => Invoke();
	}
}