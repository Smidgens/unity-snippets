// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;

	[AddComponentMenu(Constants.ACM.EVENT_RENDERER + "On Became Invisible")]
	internal sealed class Renderer_OnBecameInvisible : OnEvent
	{
		private void OnBecameInvisible() => Invoke();
	}
}