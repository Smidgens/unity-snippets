// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;

	[AddComponentMenu(Constants.ACM.INPUT_KEY + "Key Down")]
	[UnityDocumentation("Input.GetKeyDown")]
	internal sealed class Input_OnKeyDown : OnKeyCode
	{
		protected override bool Get(KeyCode key) => Input.GetKeyDown(key);
	}
}