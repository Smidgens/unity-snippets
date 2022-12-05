// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;

	[AddComponentMenu(Constants.ACM.INPUT_KEY + "Key Up")]
	[UnityDocumentation("Input.GetKeyUp")]
	internal sealed class Input_OnKeyUp : OnKeyCode
	{
		protected override bool Get(KeyCode key) => Input.GetKeyUp(key);
	}
}