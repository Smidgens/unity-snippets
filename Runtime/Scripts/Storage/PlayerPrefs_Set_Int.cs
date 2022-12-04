// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;

	[AddComponentMenu(Constants.ACM.STORAGE_PREFS + "Int/Player Prefs : Set Int")]
	internal sealed class PlayerPrefs_Set_Int : PlayerPrefs_Set<int>
	{
		protected override Setter GetSetter() => PlayerPrefs.SetInt;
	}
}