// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;

	[AddComponentMenu(Constants.ACM.EVENT_ON_GIZMOS)]
	[UnityDocumentation("MonoBehaviour.OnDrawGizmos")]
	internal sealed class MonoBehaviour_OnDrawGizmos : OnEvent
	{
#if UNITY_EDITOR
		private void OnDrawGizmos() => Invoke();
#endif
	}
}