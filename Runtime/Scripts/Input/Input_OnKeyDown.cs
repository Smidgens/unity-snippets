// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;

	[AddComponentMenu(Constants.ACM.INPUT_KEY + "Key Down")]
	internal sealed class Input_OnKeyDown : OnKeyCode
	{
		protected override bool IsActive(KeyCode key) => Input.GetKeyDown(key);
	}
}