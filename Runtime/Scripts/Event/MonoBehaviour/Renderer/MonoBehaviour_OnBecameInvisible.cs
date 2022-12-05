// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;

	[AddComponentMenu(Constants.ACM.EVENT_ON_RENDERER + "On Became Invisible")]
	[UnityDocumentation("MonoBehaviour.OnBecameInvisible")]
	internal sealed class MonoBehaviour_OnBecameInvisible : OnEvent
	{
		private void OnBecameInvisible() => Invoke();
	}
}