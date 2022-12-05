// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;

	[AddComponentMenu(Constants.ACM.EVENT_ON_APPLICATION + "Quit")]
	[UnityDocumentation("MonoBehaviour.OnApplicationQuit")]
	internal sealed class MonoBehaviour_OnApplicationQuit : OnEvent
	{
		private void OnApplicationQuit() => Invoke();
	}
}