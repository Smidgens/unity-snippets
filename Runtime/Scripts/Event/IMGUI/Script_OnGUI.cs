// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;

	[AddComponentMenu(Constants.ACM.EVENT + "IMGUI/IMGUI : On GUI")]
	internal sealed class Script_OnGUI : OnEvent
	{
		private void OnGUI() => Invoke();
	}
}