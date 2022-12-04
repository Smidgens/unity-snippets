// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;

	[AddComponentMenu(Constants.ACM.EVENT_COLLIDER_MOUSE + "On Mouse Exit")]
	internal sealed class Collider_OnMouseExit : OnEvent
	{
		private void OnMouseExit() => Invoke();
	}
}