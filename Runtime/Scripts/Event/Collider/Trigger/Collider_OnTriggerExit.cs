// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;

	[AddComponentMenu(Constants.ACM.EVENT_TRIGGER + "On Trigger Exit")]
	internal sealed class Collider_OnTriggerExit : OnTrigger
	{
		private void OnTriggerExit(Collider c) => Invoke(c);
	}
}