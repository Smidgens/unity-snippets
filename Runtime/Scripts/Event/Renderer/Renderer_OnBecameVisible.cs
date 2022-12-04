// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;

	[AddComponentMenu(Constants.ACM.EVENT_RENDERER + "On Became Visible")]
	internal sealed class Renderer_OnBecameVisible : OnEvent
	{
		private void OnBecameVisible() => Invoke();
	}
}