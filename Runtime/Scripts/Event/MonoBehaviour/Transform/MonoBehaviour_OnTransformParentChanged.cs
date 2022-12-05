// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;

	[AddComponentMenu(Constants.ACM.EVENT_ON_TRANSFORM + "Parent Changed")]
	[UnityDocumentation("MonoBehaviour.OnTransformParentChanged")]
	internal sealed class MonoBehaviour_OnTransformParentChanged : OnEvent
	{
		private void OnTransformParentChanged() => Invoke();
	}
}