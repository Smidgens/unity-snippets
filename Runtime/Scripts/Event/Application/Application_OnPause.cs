// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;

	[AddComponentMenu(Constants.ACM.EVENT_APPLICATION + "On Application Pause")]
	internal sealed class Application_OnPause : OnEvent<bool>
	{
		private void OnApplicationPause(bool pause) => Invoke(pause);
	}
}