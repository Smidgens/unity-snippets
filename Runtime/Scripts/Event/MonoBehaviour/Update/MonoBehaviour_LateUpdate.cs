// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;

	[AddComponentMenu(Constants.ACM.EVENT_UPDATE + "Late Update")]
	[UnityDocumentation("MonoBehaviour.LateUpdate")]
	internal sealed class MonoBehaviour_LateUpdate : OnEvent
	{
		private void LateUpdate() => Invoke();
	}
}