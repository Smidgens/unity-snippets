// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;

	[AddComponentMenu(Constants.ACM.INPUT_KEY + "Key")]
	internal sealed class Input_OnKey : OnKeyCode
	{
		protected override bool IsActive(KeyCode key) => Input.GetKey(key);
	}
}