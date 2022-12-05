// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;

	[AddComponentMenu(Constants.ACM.EVENT_INIT + "Awake")]
	[UnityDocumentation("MonoBehaviour.Awake")]
	internal sealed class MonoBehaviour_Awake : OnEvent
	{
		private void Awake() => Invoke();
	}
}