// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;

	[AddComponentMenu(Constants.ACM.EVENT_COLLIDER_MOUSE + "On Mouse Over")]
	internal sealed class Collider_OnMouseOver : OnEvent
	{
		private void OnMouseOver() => Invoke();
	}
}