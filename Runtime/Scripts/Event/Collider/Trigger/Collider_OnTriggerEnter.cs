// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;

	[AddComponentMenu(Constants.ACM.EVENT_TRIGGER + "On Trigger Enter")]
	internal sealed class Collider_OnTriggerEnter : OnTrigger
	{
		private void OnTriggerEnter(Collider c) => Invoke(c);
	}
}
