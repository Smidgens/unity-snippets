// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;

	[AddComponentMenu(Constants.ACM.EVENT_APPLICATION + "On Application Quit")]
	internal sealed class Application_OnQuit : OnEvent
	{
		private void OnApplicationQuit() => Invoke();
	}
}