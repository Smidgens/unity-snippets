// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;

	[AddComponentMenu(Constants.ACM.PLAYER_PREFS_INT + "Set Int")]
	[UnityDocumentation("PlayerPrefs.SetInt")]
	internal sealed class PlayerPrefs_Set_Int : PlayerPrefs_Set<int>
	{
		protected override Setter GetSetter() => PlayerPrefs.SetInt;
	}
}