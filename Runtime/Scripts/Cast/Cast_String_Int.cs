// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;

	[AddComponentMenu(Constants.ACM.CAST_STRING + "→ Int")]
	internal sealed class Cast_String_Int : Cast<string, int>
	{
		protected override bool TryParse(string x, out int y) => int.TryParse(x, out y);
	}
}