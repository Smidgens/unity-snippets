// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;

	[AddComponentMenu(Constants.ACM.EVENT_UPDATE + "Fixed Update")]
	internal sealed class Script_FixedUpdate : OnEvent
	{
		private void FixedUpdate() => Invoke();
	}
}