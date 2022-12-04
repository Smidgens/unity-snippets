// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;

	[AddComponentMenu(Constants.ACM.EVENT_TRIGGER + "On Trigger Stay")]
	internal sealed class Collider_OnTriggerStay : OnTrigger
	{
		private void OnTriggerStay(Collider c) => Invoke(c);
	}
}