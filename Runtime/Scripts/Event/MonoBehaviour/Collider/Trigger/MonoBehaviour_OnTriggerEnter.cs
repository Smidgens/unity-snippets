// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;

	[AddComponentMenu(Constants.ACM.EVENT_ON_TRIGGER + "Enter")]
	[UnityDocumentation("MonoBehaviour.OnTriggerEnter")]
	internal sealed class MonoBehaviour_OnTriggerEnter : OnTrigger
	{
		private void OnTriggerEnter(Collider c) => Invoke(c);
	}
}
