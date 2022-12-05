// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;

	[AddComponentMenu(Constants.ACM.EVENT_ON_GIZMOS + " Selected")]
	[UnityDocumentation("MonoBehaviour.OnDrawGizmosSelected")]
	internal sealed class MonoBehaviour_OnDrawGizmosSelected : OnEvent
	{
#if UNITY_EDITOR
		private void OnDrawGizmosSelected() => Invoke();
#endif
	}
}