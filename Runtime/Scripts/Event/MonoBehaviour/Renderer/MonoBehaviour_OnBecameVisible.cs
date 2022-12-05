// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;

	[AddComponentMenu(Constants.ACM.EVENT_ON_RENDERER + "On Became Visible")]
	[UnityDocumentation("MonoBehaviour.OnBecameVisible")]
	internal sealed class MonoBehaviour_OnBecameVisible : OnEvent
	{
		private void OnBecameVisible() => Invoke();
	}
}