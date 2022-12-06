// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;

	[AddComponentMenu(Constants.ACM.EVENT_CUSTOM + "Emit")]
	internal sealed class CustomEvent_Emit : Snippet
	{
		public void Invoke() => CustomEvent.Emit(_event);
		[SerializeField] internal string _event = "";
	}
}