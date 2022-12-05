// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;

	[AddComponentMenu(Constants.ACM.EVENT_ON_APPLICATION + "Pause")]
	[UnityDocumentation("MonoBehaviour.OnApplicationPause")]
	internal sealed class MonoBehaviour_OnApplicationPause : OnEvent<bool>
	{
		private void OnApplicationPause(bool pause) => Invoke(pause);
	}
}