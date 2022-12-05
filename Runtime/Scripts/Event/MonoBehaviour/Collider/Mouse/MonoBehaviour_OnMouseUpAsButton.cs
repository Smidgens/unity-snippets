// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;

	[AddComponentMenu(Constants.ACM.EVENT_ON_MOUSE + "Up as Button")]
	[UnityDocumentation("MonoBehaviour.OnMouseUpAsButton")]
	internal sealed class MonoBehaviour_OnMouseUpAsButton : OnColliderEvent
	{
		private void OnMouseUpAsButton() => Invoke();
	}
}