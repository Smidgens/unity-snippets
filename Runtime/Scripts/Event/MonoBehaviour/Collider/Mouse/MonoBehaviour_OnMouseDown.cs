// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;

	[AddComponentMenu(Constants.ACM.EVENT_ON_MOUSE + "Down")]
	[UnityDocumentation("MonoBehaviour.OnMouseDown")]
	internal sealed class MonoBehaviour_OnMouseDown : OnColliderEvent
	{
		private void OnMouseDown() => Invoke();
	}
}