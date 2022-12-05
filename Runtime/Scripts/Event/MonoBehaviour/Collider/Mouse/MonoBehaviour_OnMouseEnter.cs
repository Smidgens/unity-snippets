// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;

	[AddComponentMenu(Constants.ACM.EVENT_ON_MOUSE + "Enter")]
	[UnityDocumentation("MonoBehaviour.OnMouseEnter")]
	internal sealed class MonoBehaviour_OnMouseEnter : OnColliderEvent
	{
		private void OnMouseEnter() => Invoke();
	}
}