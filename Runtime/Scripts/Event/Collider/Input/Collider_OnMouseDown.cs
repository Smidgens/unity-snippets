// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;

	[AddComponentMenu(Constants.ACM.EVENT_COLLIDER_MOUSE + "On Mouse Down")]
	internal sealed class Collider_OnMouseDown : OnEvent
	{
		private void OnMouseDown() => Invoke();
	}
}