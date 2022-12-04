// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;

	[AddComponentMenu(Constants.ACM.INPUT_KEY + "Key Up")]
	internal sealed class Input_OnKeyUp : OnKeyCode
	{
		protected override bool IsActive(KeyCode key) => Input.GetKeyUp(key);
	}
}