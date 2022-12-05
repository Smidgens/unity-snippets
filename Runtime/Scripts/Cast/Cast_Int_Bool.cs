// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;

	[AddComponentMenu(Constants.ACM.CONVERT_INT + "→ Bool")]
	internal sealed class Cast_Int_Bool : Cast<int, bool>
	{
		protected override bool TryParse(int x, out bool y)
		{
			y = x == 0 ? false : true;
			return true;
		}
	}
}