// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;

	[AddComponentMenu(Constants.ACM.EVENT_INIT + "Start")]
	[UnityDocumentation("MonoBehaviour.Start")]
	internal sealed class MonoBehaviour_Start : OnEvent
	{
		private void Start() => Invoke();
	}
}