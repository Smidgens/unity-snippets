// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;

	[AddComponentMenu(Constants.ACM.EVENT_GIZMOS + "On Draw Gizmos")]
	internal sealed class Script_OnDrawGizmos: OnEvent
	{
#if UNITY_EDITOR
		private void OnDrawGizmos() => Invoke();
#endif
	}
}