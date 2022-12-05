// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;

	[AddComponentMenu(Constants.ACM.EVENT_ON_TRANSFORM + "Children Changed")]
	[UnityDocumentation("MonoBehaviour.OnTransformChildrenChanged")]
	internal sealed class MonoBehaviour_OnTransformChildrenChanged : OnEvent
	{
		private void OnTransformChildrenChanged() => Invoke();
	}
}