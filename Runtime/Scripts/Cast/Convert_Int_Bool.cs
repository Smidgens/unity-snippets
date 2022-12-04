// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;

	[AddComponentMenu(Constants.ACM.CONVERT_INT + "→ Bool")]
	internal sealed class Convert_Int_Bool : Convert<int, bool>
	{
		protected override bool TryParse(int x, out bool y)
		{
			y = x == 0 ? false : true;
			return true;
		}
	}
}