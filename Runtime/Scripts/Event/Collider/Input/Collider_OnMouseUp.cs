// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;

	[AddComponentMenu(Constants.ACM.EVENT_COLLIDER_MOUSE + "On Mouse Up")]
	internal sealed class Collider_OnMouseUp : OnEvent
	{
		private void OnMouseUp() => Invoke();
	}
}