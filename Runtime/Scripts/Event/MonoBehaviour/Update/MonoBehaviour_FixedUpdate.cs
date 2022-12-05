// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;

	[AddComponentMenu(Constants.ACM.EVENT_UPDATE + "Fixed Update")]
	[UnityDocumentation("MonoBehaviour.FixedUpdate")]
	internal sealed class MonoBehaviour_FixedUpdate : OnEvent
	{
		private void FixedUpdate() => Invoke();
	}
}