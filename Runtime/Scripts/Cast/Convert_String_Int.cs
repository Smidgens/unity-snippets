// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;

	[AddComponentMenu(Constants.ACM.CAST_STRING + "→ Int")]
	internal sealed class Convert_String_Int : Convert<string, int>
	{
		protected override bool TryParse(string x, out int y) => int.TryParse(x, out y);
	}
}