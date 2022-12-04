// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;

	[AddComponentMenu(Constants.ACM.EVENT_COLLIDER_MOUSE + "On Mouse Up as Button")]
	internal sealed class Collider_OnMouseUpAsButton : OnEvent
	{
		private void OnMouseUpAsButton() => Invoke();
	}
}