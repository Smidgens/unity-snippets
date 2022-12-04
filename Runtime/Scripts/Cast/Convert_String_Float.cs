// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;

	[AddComponentMenu(Constants.ACM.CAST_STRING + "→ Float")]
	internal class Convert_String_Float : Convert<string, float>
	{
		protected override bool TryParse(string x, out float y)
		{
			return float.TryParse(x, out y);
		}
	}
}