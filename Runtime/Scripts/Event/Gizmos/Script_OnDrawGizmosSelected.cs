// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;

	[AddComponentMenu(Constants.ACM.EVENT_GIZMOS + "On Draw Gizmos Selected")]
	internal sealed class Script_OnDrawGizmosSelected : OnEvent
	{
#if UNITY_EDITOR
		private void OnDrawGizmosSelected() => Invoke();
#endif
	}
}