// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;

	[AddComponentMenu(Constants.ACM.EVENT_ON_MOUSE + "Over")]
	[UnityDocumentation("MonoBehaviour.OnMouseOver")]
	internal sealed class MonoBehaviour_OnMouseOver : OnColliderEvent
	{
		private void OnMouseOver() => Invoke();
	}
}