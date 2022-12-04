// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;

	[AddComponentMenu(Constants.ACM.EVENT_UPDATE + "Late Update")]
	internal sealed class Script_LateUpdate : OnEvent
	{
		private void LateUpdate() => Invoke();
	}
}