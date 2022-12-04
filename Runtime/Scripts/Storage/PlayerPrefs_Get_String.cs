// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;

	[AddComponentMenu(Constants.ACM.STORAGE_PREFS + "String/Player Prefs : Get String")]
	internal sealed class PlayerPrefs_Get_String : PlayerPrefs_Get<string>
	{
		protected override Getter GetGetter() => PlayerPrefs.GetString;
	}
}