// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;

	[AddComponentMenu(Constants.ACM.EVENT_ON_MOUSE + "Up")]
	[UnityDocumentation("MonoBehaviour.OnMouseUp")]
	internal sealed class MonoBehaviour_OnMouseUp : OnColliderEvent
	{
		private void OnMouseUp() => Invoke();
	}
}