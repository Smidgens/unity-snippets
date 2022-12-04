// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;

	[AddComponentMenu(Constants.ACM.EVENT_APPLICATION + "On Application Focus")]
	internal sealed class Application_OnFocus : OnEvent<bool>
	{
		private void OnApplicationFocus(bool focus) => Invoke(focus);

	}
}