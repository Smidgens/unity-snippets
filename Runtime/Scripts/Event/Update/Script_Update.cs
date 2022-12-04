// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;

	[AddComponentMenu(Constants.ACM.EVENT_UPDATE + "Update")]
	internal sealed class Script_Update : OnEvent
	{
		private void Update() => Invoke();
	}
}