// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;

	[AddComponentMenu(Constants.ACM.EVENT_TRANSFORM + "On Transform Parent Changed")]
	internal sealed class Transform_OnTransformParentChanged : OnEvent
	{
		private void OnTransformParentChanged() => Invoke();
	}
}