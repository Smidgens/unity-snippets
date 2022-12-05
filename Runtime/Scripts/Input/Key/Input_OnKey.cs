// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;

	[AddComponentMenu(Constants.ACM.INPUT_KEY + "Key")]
	[UnityDocumentation("Input.GetKey")]
	internal sealed class Input_OnKey : OnKeyCode
	{
		protected override bool Get(KeyCode key) => Input.GetKey(key);
	}
}