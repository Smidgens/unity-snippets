// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;

	[AddComponentMenu(Constants.ACM.PLAYER_PREFS_STRING + "Get String")]
	[UnityDocumentation("PlayerPrefs.GetString")]
	internal sealed class PlayerPrefs_Get_String : PlayerPrefs_Get<string>
	{
		protected override Getter GetGetter() => PlayerPrefs.GetString;
	}
}