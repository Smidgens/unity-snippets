// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;

	[AddComponentMenu(Constants.ACM.EVENT_CLEANUP + "On Disable")]
	[UnityDocumentation("MonoBehaviour.OnDisable")]
	internal sealed class MonoBehaviour_OnDisable : OnEvent
	{
		private void OnDisable() => Invoke();
	}
}