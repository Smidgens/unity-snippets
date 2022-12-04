// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;

	[AddComponentMenu(Constants.ACM.STORAGE_PREFS + "Int/Player Prefs : Get Int")]
	internal sealed class PlayerPrefs_Get_Int : PlayerPrefs_Get<int>
	{
		protected override Getter GetGetter() => PlayerPrefs.GetInt;
	}
}
