// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;

	[AddComponentMenu(Constants.ACM.EVENT_INIT + "On Enable")]
	[UnityDocumentation("MonoBehaviour.OnEnable")]
	internal sealed class MonoBehaviour_OnEnable : OnEvent
	{
		private void OnEnable() => Invoke();
	}
}