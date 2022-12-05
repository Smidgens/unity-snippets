// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;

	[AddComponentMenu(Constants.ACM.EVENT_ON_MOUSE + "Drag")]
	[UnityDocumentation("MonoBehaviour.OnMouseDrag")]
	internal sealed class MonoBehaviour_OnMouseDrag : OnColliderEvent
	{
		private void OnMouseDrag() => Invoke();
	}
}