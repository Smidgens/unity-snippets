// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;

	[AddComponentMenu(Constants.ACM.EVENT_ON_APPLICATION + "Focus")]
	[UnityDocumentation("MonoBehaviour.OnApplicationFocus")]
	internal sealed class MonoBehaviour_OnApplicationFocus : OnEvent<bool>
	{
		private void OnApplicationFocus(bool focus) => Invoke(focus);

	}
}