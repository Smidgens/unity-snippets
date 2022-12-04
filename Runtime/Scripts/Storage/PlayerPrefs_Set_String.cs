// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;

	[AddComponentMenu(Constants.ACM.STORAGE_PREFS + "String/Player Prefs : Set String")]
	internal sealed class PlayerPrefs_Set_String : PlayerPrefs_Set<string>
	{
		protected override Setter GetSetter() => PlayerPrefs.SetString;
	}
}