// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;

	[AddComponentMenu(Constants.ACM.EVENT_UPDATE + "Update")]
	[UnityDocumentation("MonoBehaviour.Update")]
	internal sealed class MonoBehaviour_Update : OnEvent
	{
		private void Update() => Invoke();
	}
}