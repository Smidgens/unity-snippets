// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;

	[AddComponentMenu(Constants.ACM.STORAGE_PREFS + "Float/Player Prefs : Get Float")]
	internal sealed class PlayerPrefs_Get_Float : PlayerPrefs_Get<float>
	{
		protected override Getter GetGetter() => PlayerPrefs.GetFloat;
	}
}
