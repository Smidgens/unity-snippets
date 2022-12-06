// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;

	[AddComponentMenu(Constants.ACM.PLAYER_PREFS_STRING + "Set String")]
	[UnityDocumentation("PlayerPrefs.SetString")]
	internal sealed class PlayerPrefs_Set_String : PlayerPrefs_Set<string>
	{
		protected override Setter GetSetter() => PlayerPrefs.SetString;
	}
}