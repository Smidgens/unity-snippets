// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;

	[AddComponentMenu(Constants.ACM.PLAYER_PREFS_INT + "Get Int")]
	[UnityDocumentation("PlayerPrefs.GetInt")]
	internal sealed class PlayerPrefs_Get_Int : PlayerPrefs_Get<int>
	{
		protected override Getter GetGetter() => PlayerPrefs.GetInt;
	}
}
