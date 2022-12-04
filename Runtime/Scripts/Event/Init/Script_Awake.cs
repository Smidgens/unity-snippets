// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;

	[AddComponentMenu(Constants.ACM.EVENT_INIT + "Awake")]
	internal sealed class Script_Awake : OnEvent
	{
		private void Awake() => Invoke();
	}
}