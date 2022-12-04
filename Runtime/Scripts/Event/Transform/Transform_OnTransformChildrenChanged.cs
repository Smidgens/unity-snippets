// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;

	[AddComponentMenu(Constants.ACM.EVENT_TRANSFORM + "On Transform Children Changed")]
	internal sealed class Transform_OnTransformChildrenChanged : OnEvent
	{
		private void OnTransformChildrenChanged() => Invoke();
	}
}