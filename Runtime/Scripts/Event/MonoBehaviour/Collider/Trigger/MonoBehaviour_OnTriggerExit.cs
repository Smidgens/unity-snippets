// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;

	[AddComponentMenu(Constants.ACM.EVENT_ON_TRIGGER + "Exit")]
	[UnityDocumentation("MonoBehaviour.OnTriggerExit")]
	internal sealed class MonoBehaviour_OnTriggerExit : OnTrigger
	{
		private void OnTriggerExit(Collider c) => Invoke(c);
	}
}