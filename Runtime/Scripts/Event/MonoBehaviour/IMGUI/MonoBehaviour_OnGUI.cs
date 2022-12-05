// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;

	[AddComponentMenu(Constants.ACM.EVENT_ON_GUI + "On GUI")]
	[UnityDocumentation("MonoBehaviour.OnGUI")]
	internal sealed class MonoBehaviour_OnGUI : OnEvent
	{
		private void OnGUI() => Invoke();
	}
}