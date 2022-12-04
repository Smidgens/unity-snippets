// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;

	[AddComponentMenu(Constants.ACM.EVENT_COLLIDER_MOUSE + "On Mouse Drag")]
	internal sealed class Collider_OnMouseDrag : OnEvent
	{
		private void OnMouseDrag() => Invoke();
	}
}