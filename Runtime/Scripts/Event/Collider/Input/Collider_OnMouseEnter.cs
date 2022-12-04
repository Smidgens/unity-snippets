// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;

	[AddComponentMenu(Constants.ACM.EVENT_COLLIDER_MOUSE + "On Mouse Enter")]
	internal sealed class Collider_OnMouseEnter : OnEvent
	{
		private void OnMouseEnter() => Invoke();
	}
}