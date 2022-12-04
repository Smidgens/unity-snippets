// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;

	[AddComponentMenu(Constants.ACM.EVENT_INIT + "Start")]
	internal sealed class Script_Start : OnEvent
	{
		private void Start() => Invoke();
	}
}