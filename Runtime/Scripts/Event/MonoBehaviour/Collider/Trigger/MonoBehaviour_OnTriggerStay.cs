// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;

	[AddComponentMenu(Constants.ACM.EVENT_ON_TRIGGER + "Stay")]
	[UnityDocumentation("MonoBehaviour.OnTriggerStay")]
	internal sealed class MonoBehaviour_OnTriggerStay : OnTrigger
	{
		private void OnTriggerStay(Collider c) => Invoke(c);
	}
}