// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;

	[AddComponentMenu(Constants.ACM.EVENT_ON_MOUSE + "Exit")]
	[UnityDocumentation("MonoBehaviour.OnMouseExit")]
	internal sealed class MonoBehaviour_OnMouseExit : OnColliderEvent
	{
		private void OnMouseExit() => Invoke();
	}
}